namespace ep.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IMapper mapper, IRepositoryWrapper repository, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserView> GetUserAsync(int id)
        {            
            var user = await _repository.User.GetByIdAsync(id);
            var respond = _mapper.Map<UserView>(user);
            return respond ?? throw new BusinessException(ErrorCodeConstants.NotFoundError, $"User [{id}] not found");
        }

        public async Task RegisterAsync(RegisterRequest request)
        {
            var salt = CryptoService.GenerateSalt();
            var hashedText = CryptoService.HashPassword(request.Password!, salt);
            
            var user = _mapper.Map<User>(request);
            user.Password = hashedText;
            user.Salt = salt;

            await _repository.User.CreateAsync(user);
            await _unitOfWork.CompleteAsync();
        }

        public string GetMyName()
        {
            var result = string.Empty;
            var role = string.Empty;
            var email = string.Empty;

            if (_httpContextAccessor.HttpContext != null)
            {
                email = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
                role = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
            }
            return result;
        }
    }
}
