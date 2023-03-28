namespace ep.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IMapper mapper, IRepositoryWrapper repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<User> GetUserAsync(int id)
        {            
            var user = await _repository.User.GetByIdAsync(id);
            return user ?? throw new BusinessException(ErrorCodeConstants.NotFoundErrorCode, $"User [{id}] not found");
        }

        public async Task RegisterAsync(RegisterRequest request)
        {
            var user = _mapper.Map<User>(request);
            await _repository.User.CreateAsync(user);
            await _unitOfWork.CompleteAsync();
        }
    }
}
