using AutoMapper;
using ep.Data.Wrappers;
using ep.Domain.Dtos;
using ep.Domain.Models;
using ep.Service.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ep.Tests.Services
{
    public class ShopServiceTests
    {
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IRepositoryWrapper> _repository;
        private readonly ShopService _service;
        private readonly ShopCreateDto _createDto;

        public ShopServiceTests()
        {
            _mapper = new Mock<IMapper>();
            _repository = new Mock<IRepositoryWrapper>();
            _service = new ShopService(_mapper.Object, _repository.Object);
            _createDto = new ShopCreateDto
            {
                ABN = "123 456",
                Address = "Sydney",
                Owner = "Owner",
                Name = "Charllet",
                Telephone = "789 102"
            };
        }

        [Fact]
        public async Task PostShopAsync_WhenCalled_ShouldCreateNewShop()
        {
            // Arrange
            _mapper.Setup(m => m.Map<Shop>(It.IsAny<ShopCreateDto>())).Returns(new Shop());
            _repository.Setup(r => r.Shop.CreateAsync(It.IsAny<Shop>()));
            _repository.Setup(r => r.UnitOfWork.CompleteAsync());

            // Act
            await _service.PostShopAsync(_createDto);

            // Assert
            _repository.Verify(r => r.Shop.CreateAsync(It.IsAny<Shop>()), Times.Once);
            _repository.Verify(r => r.UnitOfWork.CompleteAsync(), Times.Once());
        }
    }
}
