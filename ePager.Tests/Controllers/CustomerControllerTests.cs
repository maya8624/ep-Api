using AutoMapper;
using ePager.Data.Interfaces;
using ePager.Data.Persistant;
using ePager.Data.Wrappers;
using ePager.Domain.Dtos;
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

namespace ePager.Tests.Controllers
{
    public class CustomerControllerTests
    {
        private readonly Mock<ILogger<CustomerController>> _logger;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IRepositoryWrapper> _wrapper;

        private readonly Customer _customer;
        private readonly CustomerController _controller;
        private readonly CustomerCreateDto _customerDto;
        private readonly List<Message> _messages;

        public CustomerControllerTests()
        {
            _mapper = new Mock<IMapper>();
            _logger = new Mock<ILogger<CustomerController>>();
            _wrapper = new Mock<IRepositoryWrapper>();
            _controller = new CustomerController(_logger.Object, _mapper.Object, _wrapper.Object);

            _customerDto = new()
            {               
                Mobile = "0422230861",
                Name = "Andy",
                OrderNo = "1-20220115",
                ShopId = 2
            };

            _messages = new()
            {
                new()
                {
                    Id = 1,
                    CreatedOn = DateTimeOffset.UtcNow,
                    Icon = "prep",
                    Status = MessageStatus.Prep,
                    Text = "Order: 1-20220115 has been received"
                },
                new()
                {
                    Id = 2,
                    CreatedOn = DateTimeOffset.UtcNow,
                    Icon = "ready",
                    Status = MessageStatus.Sent,
                    Text = "Order: 1-20220115 is ready to pick up"
                }
            };

            _customer = new()
            {
                Mobile = "0422230861",
                Name = "Andy",
                OrderNo = "1-20220115",
                ShopId = 2,
                Messages = _messages
            };
            
        }

        [Fact]
        public async Task GetCustomer_WhenCalled_ShouldReturnCustomer()
        {
            // Arrange
            _wrapper.Setup(x => x.Customer.GetCustomerByShopIdAndOrderNo(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(_customer);

            // Act
            var result = await _controller.GetCustomerByShopIdAndOrderNo(It.IsAny<int>(), It.IsAny<string>());
            var model = result.Value;

            // Assert
            Assert.NotNull(model);
            Assert.Contains("andy", model!.Name!.ToLower());
            Assert.Equal(2, model!.Messages!.Count);
        }

        [Fact]
        public async Task PostCustomer_WhenCalled_SaveDataToDatase()
        {
            // Arrange
            _mapper.Setup(m => m.Map<Customer>(It.IsAny<CustomerCreateDto>())).Returns(_customer);
            _wrapper.Setup(w => w.Customer.CreateAsync(It.IsAny<Customer>()));
            _wrapper.Setup(w => w.Message.CreateAsync(It.IsAny<Message>()));
            _wrapper.Setup(w => w.UnitOfWork.CompleteAsync());

            // Act
            await _controller.PostCustomer(_customerDto);

            // Assert
            _wrapper.Verify(w => w.Customer.CreateAsync(It.IsAny<Customer>()));
            _wrapper.Verify(w => w.Message.CreateAsync(It.IsAny<Message>()));
        }
    }
}
