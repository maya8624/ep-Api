using AutoMapper;
using ep.Service.Services;
using ep.Data.Wrappers;
using ep.Domain.Dtos;
using ep.Domain.Enums;
using ep.Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ep.Tests.Services
{
    public class CustomerServiceTests
    {
        private readonly CustomerService _service;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IRepositoryWrapper> _repository;
        private readonly Customer _customer;

        public CustomerServiceTests()
        {
            _mapper = new Mock<IMapper>();
            _repository = new Mock<IRepositoryWrapper>();
            _service = new CustomerService(_mapper.Object, _repository.Object);

            _customer = new Customer
            {
                Id = 2,
                CreatedOn = DateTimeOffset.UtcNow,
                Name = "Joseph J",
                Mobile = "0422230861",
                OrderNo = "02-01022022",
                ShopId = 2,
                Messages = new List<Message>
                {
                    new Message
                    {
                        Id = 2,
                        CreatedOn= DateTimeOffset.UtcNow,
                        Icon = "prep",
                        ShopId = 2,
                        Status = MessageStatus.Prep,
                        Text = "Order has been received"
                    },
                    new Message
                    {
                        Id = 3,
                        CreatedOn= DateTimeOffset.UtcNow,
                        Icon = "sent",
                        ShopId = 2,
                        Status = MessageStatus.Sent,
                        Text = "Your order: 02-01022022 is ready to pick up"
                    }
                }
            };
        }

        [Fact]
        public async Task GetCustomerById_WhenCallWithIdedReturnCustomer()
        {
            // Arrange
            _repository.Setup(x => x.Customer.GetById(It.IsAny<int>()))
                       .ReturnsAsync(_customer);

            // Act
            var result = await _service.GetCustomerById(2);

            // Assert
            Assert.NotNull(result);
            Assert.Contains("joseph", result.Name?.ToLower());
            Assert.Equal(2, result.Messages?.Count);
        }

        [Fact]
        public async Task GetCustomerByShopIdAndOrderNo_WhenCalledWithShopIdAndCustomerIdShouldReturnRightCustomer()
        {
            // Arrange
            _repository.Setup(x => x.Customer.GetCustomerByShopIdAndOrderNo(It.IsAny<int>(), It.IsAny<string>()))
                       .ReturnsAsync(_customer);

            // Act
            var result = await _service.GetCustomerByShopIdAndOrderNo(0, "1");

            // Assert
            Assert.NotNull(result);
            Assert.Contains("joseph", result.Name?.ToLower());
            Assert.Equal(2, result.Messages?.Count);
        }

        [Fact]
        public async Task PostCustomerAsync_WhenCalled_CreateNewCustomer()
        {
            // Arrange
            _mapper.Setup(m => m.Map<Customer>(It.IsAny<CustomerCreateDto>())).Returns(new Customer());
            _repository.Setup(x => x.Customer.CreateAsync(It.IsAny<Customer>()));
            _repository.Setup(x => x.Message.CreateAsync(It.IsAny<Message>()));
            _repository.Setup(x => x.UnitOfWork.CompleteAsync());

            var customerDto = new CustomerCreateDto
            {
                Mobile = "0422230861",
                Name = "Andy",
                OrderNo = "1-20220115",
                ShopId = 2
            };

            // Act
            await _service.PostCustomerAsync(customerDto);

            // Assert
            _repository.Verify(x => x.Customer.CreateAsync(It.IsAny<Customer>()), Times.Once);
            _repository.Verify(x => x.Message.CreateAsync(It.IsAny<Message>()), Times.Once);
            _repository.Verify(x => x.UnitOfWork.CompleteAsync());
        }
    }
}
