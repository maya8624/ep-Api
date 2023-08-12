using AutoMapper;
using ep.Contract.RequestModels;
using ep.Contract.ViewModels;
using ep.Data.Persistent;
using ep.Data.Wrappers;
using ep.Domain.Models;
using ep.Framework.Exceptions;
using ep.Logic.Interfaces;
using ep.Logic.Logics;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ep.Tests.Logics
{
    public class AuthLogicTests
    {
        private readonly IAuthLogic _auth;
        private readonly Mock<IConfiguration> _configuration;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IRepositoryWrapper> _repository;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly LogInRequest _logInRequest;

        public AuthLogicTests()
        {
            _configuration = new Mock<IConfiguration>();
            _mapper = new Mock<IMapper>();
            _repository = new Mock<IRepositoryWrapper>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _auth = new AuthLogic(_configuration.Object, _mapper.Object, _repository.Object, _unitOfWork.Object);

            _logInRequest = new LogInRequest
            {
                Email = "test@example.com",
                Password = "Pa$$w0rd",
            };
        }

        [Fact]
        public async Task GetTokenAsync_ReturnsUserTokenView_WhenUserExistsAndCredentialsAreValid()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                Email = _logInRequest.Email,
                Password = "XH4u3UzY/wabRFSTFrR9WPesKkLBE5h/7tuHMxk9F/M=",
                Role = "user",
                Salt = "oqhceXKsBB/aLQeZlq27gg=="
            };

            var userToken = new UserToken
            {
                RefreshToken = "random_key",
                TokenExpires = DateTime.UtcNow.AddDays(1),
                UserId = 1
            };

            _repository.Setup(x => x.User.GetUserByEmailAsync(_logInRequest.Email!)).ReturnsAsync(user);
            _mapper.Setup(x => x.Map<UserView>(user)).Returns(new UserView { Id = user.Id });
            _configuration.Setup(x => x.GetSection("AppSettings:Secret").Value).Returns("GMr2Gmhk4IZcTp0lLelxYWLoncGAa8bFwZDCdSLct6M=");
            _repository.Setup(x => x.UserToken.Create(userToken));

            // Act
            var result = await _auth.GetTokenAsync(_logInRequest);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.Id, result.User!.Id);
            Assert.NotNull(result.AccessToken);
            Assert.NotNull(result.RefreshToken);
        }

        [Fact]
        public async Task GetTokenAsync_ThrowsBusinessException_WhenUserDoesNotExist()
        {
            // Arrange
            _repository.Setup(x => x.User.GetUserByEmailAsync(It.IsAny<string>())).ReturnsAsync((User)null);

            // Act & Assert
            await Assert.ThrowsAsync<AuthorizedException>(() => _auth.GetTokenAsync(_logInRequest));
        }

        [Fact]
        public async Task GetTokenAsync_ThrowsBusinessException_WhenCredentialsAreInvalid()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                Email = "test@example.com",
                Password = "password",
                Role = "user",
                Salt = "oqhceXKsBB/aLQeZlq27gg==",
            };

            _repository.Setup(x => x.User.GetUserByEmailAsync(_logInRequest.Email)).ReturnsAsync(user);

            // Act & Assert
            await Assert.ThrowsAsync<AuthorizedException>(() => _auth.GetTokenAsync(_logInRequest));
        }

        //[Fact]
        //public void RefreshToken_ReturnRefreshToken_WhenCalled()
        //{
        //    // Arrange
        //    var oldRefreshToken = "old_refresh_token";
        //    var userToken = new UserToken
        //    {
        //        RefreshToken = "refresh_token_string",
        //        TokenExpires = DateTime.UtcNow.AddDays(1),
        //        UserId = 1
        //    };

        //    _repository.Setup(x => x.UserToken.GetLatestUserTokenByUserId(It.IsAny<int>())).ReturnsAsync(userToken);

        //    // Act
        //    var result = _auth.RefreshToken(oldRefreshToken, userToken.UserId);

        //}

        // create a test for refresh token
        //[Fact]


        // Get average runtime of successful runs in seconds



    }
}

