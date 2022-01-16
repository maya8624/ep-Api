using ePager.Data.Interfaces;
using ePager.Data.Persistant;
using ePager.Domain.Enums;
using ePager.Domain.Models;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIePager.Controllers;
using Xunit;

namespace ePagerTests.Controllers
{
    public class MessageControllerTests
    {
        private readonly Mock<ILogger<MessageController>> _logger;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<IMessageRepository> _repository;
        private readonly MessageController _controller;
        private readonly Message _message;
        private readonly List<MessageHistory> _histories;

        public MessageControllerTests()
        {
            _logger = new Mock<ILogger<MessageController>>();
            _repository = new Mock<IMessageRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _controller = new MessageController(_logger.Object, _repository.Object, _unitOfWork.Object);

            _histories = new()
            {
                new MessageHistory
                {
                    Id = 1,
                    CreatedOn = DateTimeOffset.UtcNow,
                    Icon = "prep",
                    Status = MessageStatus.Prep,
                    Text = "Order: 1-20220115 has been received",
                },
            };

            _message = new()
            {
                Id = 1,
                Count = 0,
                CreatedOn = DateTimeOffset.UtcNow,
                Mobile = "0422 230 861",
                Name = "Andy",
                OrderNo = "1-20220115",
                ShopId = 1,
                History = _histories
            };
        }

        [Fact]
        public async Task GetMessage_WhenCalled_ShouldReturnMessage()
        {
            // Arrange
            _repository.Setup(x => x.GetByShopIdAndOrderNo(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(_message);

            // Act
            var result = await _controller.GetByShopIdAndOrderNo(It.IsAny<int>(), It.IsAny<string>());
            var model = result.Value as Message;

            // Assert
            Assert.NotNull(model);
            Assert.Contains("andy", model!.Name.ToLower());
            Assert.Equal(1, model.History!.Count);
        }

        //[Fact]
        //public async Task CreateMessage_WhenCalled_ShouldCreateMessage()
        //{
        //    // Arrange

        //    // Act

        //    // Assert
        //}

        //[Fact]
        //public async Task UpdateMessage_WhenCalled_ShouldCreateMessage()
        //{
        //    // Arrange

        //    // Act

        //    // Assert
        //}
    }
}
