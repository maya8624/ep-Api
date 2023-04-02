namespace ep.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repository;
        private readonly IUnitOfWork _unitOfWork;
        
        public AuthService(IConfiguration configuration, IMapper mapper, IRepositoryWrapper repository, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public string CreateToken(UserRequest user)
        {
            // TODO: if a user is authenticated
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.Role, user.Role!),
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Secret").Value));

            var creditionals = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(Constants.DefaultTokenExpireMins), 
                signingCredentials: creditionals);

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }

        private void ThrowBusinessException()
        {
            throw new BusinessException(
                ErrorCodeConstants.CredentialErrorCode, ErrorMessageConstants.UserNotCorrect);
        }

        public async Task<UserTokenView> GetTokenAsync(UserRequest request)
        {
            var user = await _repository.User.GetUserByEmailAsync(request.Email!);
            if (user == null) ThrowBusinessException();
            user!.Role = request.Role;

            var isVerified = VerifyPasswordHash(request.Password!, user);
            if (!isVerified) ThrowBusinessException();

            var accessToken = CreateToken(request);
            var refreshToken = await CreateRefreshTokenAsync(id: user.Id);

            var response = new UserTokenView
            {
                User = _mapper.Map<UserView>(user),
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            };
            return response;
        }

        public async Task<string> GetRefreshTokenAsync(string refeshToken)
        {
            //TODO: implement get a refreshtoken
            //var latestUserToken = await _repository.UserToken.GetLatestUserTokenByUserId(user.Id);
            //if (latestUserToken != null)
            //{
            //    var isValidRefreshToken = await VerifyRefreshToken(request.RefreshToken!, user.Id);
            //}

            //var accessToken = CreateToken(request);
            //var refreshToken = await CreateRefreshTokenAsync(id: user.Id);
            throw new NotImplementedException();
        }
     
        private async Task<string> CreateRefreshTokenAsync(int id, int days = Constants.DefaultTokenExpireDays)
        {
            var userToken = new UserToken
            {
                RefreshToken = CryptoService.GenerateRandomKey(),
                TokenExpires = DateTime.UtcNow.AddDays(days),
                UserId = id
            };

            await _repository.UserToken.CreateAsync(userToken);
            await _unitOfWork.CompleteAsync();

            return userToken.RefreshToken;
        }

        private bool VerifyPasswordHash(string password, User user)
        {
            var hash = CryptoService.HashPassword(password, user.Salt!);
            return hash.SequenceEqual(user.Password!);
        }

        private async Task<UserToken> VerifyRefreshToken(string refreshToken, int userId)
        {
            var userToken = await _repository.UserToken.GetUserTokenByRefreshToken(refreshToken, userId);
            return userToken;            
        }
    }
}
