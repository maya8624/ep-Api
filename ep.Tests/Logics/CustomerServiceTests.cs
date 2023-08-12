using AutoMapper;
using ep.Data.Wrappers;
using ep.Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using ep.API.Service.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using ep.Logic.Logics;

namespace ep.Tests.Logics
{
    public class CustomerServiceTests
    {
        private readonly Customer _customer;
        private readonly CustomerLogic _customerLogic;
        private readonly Mock<IConfiguration> _config;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IRepositoryWrapper> _repository;
        private readonly Mock<IHubContext<CustomerHub>> _hub;

        public CustomerServiceTests()
        {
            _config = new Mock<IConfiguration>();
            _mapper = new Mock<IMapper>();
            _repository = new Mock<IRepositoryWrapper>();
            _hub = new Mock<IHubContext<CustomerHub>>();
            //_customer = new CustomerService(_mapper.Object, _repository.Object);
            _customerLogic = new CustomerLogic(_config.Object, _hub.Object, _mapper.Object, _repository.Object);

            _customer = new Customer
            {
                Id = 2,
                CreatedOn = DateTimeOffset.UtcNow,
                Name = "Joseph J",
                Mobile = "0422230861",
                //OrderNo = "02-01022022",
                ShopId = 2,
                //Messages = new List<Message>
                //{
                //    new Message
                //    {
                //        Id = 2,
                //        CreatedOn = DateTimeOffset.UtcNow,
                //        MessageType = 1,
                //        MessageSentOn = DateTime.UtcNow,
                //        ShopId = 2,
                //        Name = "John Doe"
                //    },
                //    new Message
                //    {
                //        Id = 3,
                //        CreatedOn= DateTimeOffset.UtcNow,
                //        MessageType = 1,
                //        MessageSentOn = DateTime.UtcNow.AddMinutes(2),
                //        Name = "Sam Hooray",
                //        ShopId = 2,
                //    }
                //}
            };
        }

        //[Fact]
        //public async Task GetCustomerById_WhenCallWithIdedReturnCustomer()
        //{
        //    // Arrange
        //    _repository.Setup(x => x.Customer.GetById(It.IsAny<int>()))
        //               .ReturnsAsync(_customer);

        //    // Act
        //    var result = await _customer.GetCustomerById(2);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Contains("joseph", result.Name?.ToLower());
        //    Assert.Equal(2, result.Messages?.Count);
        //}

        //[Fact]
        //public async Task GetCustomerByShopIdAndOrderNo_WhenCalledWithShopIdAndCustomerIdShouldReturnRightCustomer()
        //{
        //    // Arrange
        //    _repository.Setup(x => x.Customer.GetCustomerByShopIdAndOrderNo(It.IsAny<int>(), It.IsAny<string>()))
        //               .ReturnsAsync(_customer);

        //    // Act
        //    var result = await _customer.GetCustomerByShopIdAndOrderNo(0, "1");

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Contains("joseph", result.Name?.ToLower());
        //    Assert.Equal(2, result.Messages?.Count);
        //}

        //[Fact]
        //public async Task CreateCustomerAsync_WhenCalled_CreateNewCustomer()
        //{
        //    // Arrange
        //    _mapper.Setup(m => m.Map<Customer>(It.IsAny<CustomerCreateDto>())).Returns(new Customer());
        //    _repository.Setup(x => x.Customer.Create(It.IsAny<Customer>()));
        //    _repository.Setup(x => x.Message.Create(It.IsAny<Message>()));
        //    _repository.Setup(x => x.UnitOfWork.CompleteAsync());

        //    var customerDto = new CustomerCreateDto
        //    {
        //        Mobile = "0422230861",
        //        Name = "Andy",
        //        OrderNo = "1-20220115",
        //        ShopId = 2
        //    };

        //    // Act
        //    await _customer.CreateCustomerAsync(customerDto);

        //    // Assert
        //    _repository.Verify(x => x.Customer.Create(It.IsAny<Customer>()), Times.Once);
        //    //_repository.Verify(x => x.Message.Create(It.IsAny<Message>()), Times.Once);
        //    _repository.Verify(x => x.UnitOfWork.CompleteAsync());
        //}

        [Fact]
        public async Task GetTodaysRawCustomers_WhenCalled_ReturnTodaysRawCustomers()
        {
            // Arrange
            var customers = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    CreatedOn = DateTime.UtcNow,
                    //MessageId = null,
                    Mobile = "0422230861",
                    Name = "Andy",
                    ShopId = 2,
                    //OrderNo = "1-20220115"
                },
                new Customer
                {
                    Id = 2,
                    CreatedOn = DateTime.UtcNow,
                    //MessageId = 23,
                    Mobile = "0422230861",
                    Name = "Jimmy",
                    ShopId = 2,
                }
            };

            //_repository.Setup(x => x.Customer.GetTodaysRawCustomers(It.IsAny<int>())).ReturnsAsync(customers);

            // Act
            //var result = await _customer.GetTodaysRawCustomers(It.IsAny<int>());

            // Assert
            //Assert.NotNull(result);
            //Assert.Contains("andy", result.FirstOrDefault(c => c.ShopId == 2 && c.MessageId == null).Name.ToLower());
            //Assert.Equal(1, result.Count(c => c.ShopId == 2 && c.MessageId != null));
        }
    }
}
