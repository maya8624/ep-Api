using AutoMapper;
using ep.Data.Wrappers;
using ep.Service.Services;
using Moq;
using ep.Contract.RequestModels;

namespace ep.Tests.Services
{
    public class BusinessServiceTests
    {
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IRepositoryWrapper> _repository;
        private readonly BusinessService _service;
        private readonly BusinessRequest _business;

        public BusinessServiceTests()
        {
            _mapper = new Mock<IMapper>();
            _repository = new Mock<IRepositoryWrapper>();
            _service = new BusinessService(_mapper.Object, _repository.Object);
            _business = new BusinessRequest
            {
                ABN = "123 456",
                Address = "Sydney",
                Owner = "Owner",
                Name = "Charllet",
                Phone = "789 102",
                Email = "andy@domain.com",
                Latitude = "",
                Longitude = ""
            };
        }

        //[Fact]
        //public async Task PostShopAsync_WhenCalled_ShouldCreateNewShop()
        //{
        //    // Arrange
        //    _mapper.Setup(m => m.Map<Shop>(It.IsAny<ShopCreateDto>())).Returns(new Shop());
        //    _repository.Setup(r => r.Shop.CreateAsync(It.IsAny<Shop>()));
        //    _repository.Setup(r => r.UnitOfWork.CompleteAsync());

        //    // Act
        //    await _service.PostShopAsync(_createDto);

        //    // Assert
        //    _repository.Verify(r => r.Shop.CreateAsync(It.IsAny<Shop>()), Times.Once);
        //    _repository.Verify(r => r.UnitOfWork.CompleteAsync(), Times.Once());
        //}
    }
}
