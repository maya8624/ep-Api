using AutoMapper;
using ep.Contract.RequestModels;
using ep.Contract.ViewModels;
using ep.Data.Persistent;
using ep.Data.Wrappers;
using ep.Domain.Models;
using ep.Framework.Exceptions;
using ep.Logic.Logics;
using ep.Service.Interfaces;
using ep.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ep.Tests.Logics
{
    public class UserServiceTests
    {
        private readonly Mock<IHttpContextAccessor> _httpContextAccessor;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IRepositoryWrapper> _repository;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly UserLogic _userService;

        public UserServiceTests()
        {
            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            _mapper = new Mock<IMapper>();
            _repository = new Mock<IRepositoryWrapper>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _userService = new UserLogic(_mapper.Object, _repository.Object, _unitOfWork.Object, _httpContextAccessor.Object);
        }

        [Fact]
        public async Task GetUserAsync_ReturnUser_WhenUserExists()
        {
            // Arrange
            var userId = 1;
            var user = new User { Id = userId, Name = "John Doe" };
            var expectedUserView = new UserView { Id = userId, Name = "John Doe" };

            _repository.Setup(x => x.User.GetById(userId)).ReturnsAsync(user);
            _mapper.Setup(x => x.Map<UserView>(user)).Returns(expectedUserView);

            // Act
            var result = await _userService.GetUser(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedUserView, result);
        }

        [Fact]
        public async Task GetUserAsync_ThrowsBusinessException_WhenUserDoesNotExist()
        {
            // Arrange
            var userId = 1;
            _repository.Setup(x => x.User.GetById(userId)).ReturnsAsync((User)null);

            // Act & Assert
            await Assert.ThrowsAsync<BusinessException>(() => _userService.GetUser(userId));
        }

        [Fact]
        public async Task RegisterAsync_CreatesUser_WhenRequestIsValid()
        {
            // Arrange
            var request = new RegisterRequest
            {
                Email = "johndoe@example.com",
                Password = "Pa$$w0rd",
                Name = "John Doe"
            };

            var salt = "generated_salt";
            var hashedPassword = "hashed_password";

            var user = new User
            {
                Email = "johndoe@example.com",
                Password = hashedPassword,
                Salt = salt
            };

            _mapper.Setup(x => x.Map<User>(request)).Returns(user);
            _repository.Setup(x => x.UnitOfWork.CompleteAsync());
            _repository.Setup(x => x.User.Create(user));

            // Act
            await _userService.Register(request);

            // Assert
            _repository.Verify(x => x.User.Create(user), Times.Once);
            _unitOfWork.Verify(x => x.CompleteAsync(), Times.Once);
        }
    }
}
