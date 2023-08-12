using AutoMapper;
using ep.Contract.RequestModels;
using ep.Data.Wrappers;
using ep.Domain.Models;
using ep.Logic.Logics;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace ep.Tests.Logics
{
    public class BusinessServiceTests
    {
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IRepositoryWrapper> _repository;
        private readonly BusinessLogic _businessLogic;
        private readonly BusinessRequest _business;

        public BusinessServiceTests()
        {
            _mapper = new Mock<IMapper>();
            _repository = new Mock<IRepositoryWrapper>();
            _businessLogic = new BusinessLogic(_mapper.Object, _repository.Object);
            _business = new BusinessRequest
            {
                ABN = "123 456",
                Address = "Sydney",
                Owner = "Owner",
                Email = "andy@domain.com",
                Name = "Charllet",
                Phone = "789 102",
                Latitude = 52.26m,
                Longitude = 21.95m
            };
        }

        [Fact]
        public async Task SaveBusinessAsync_WhenCalled_ShouldCreateNewShop()
        {
            // Arrange
            _mapper.Setup(x => x.Map<Business>(It.IsAny<BusinessRequest>())).Returns(new Business());
            _repository.Setup(x => x.Business.Create(It.IsAny<Business>()));
            _repository.Setup(x => x.UnitOfWork.CompleteAsync());

            // Act
            await _businessLogic.SaveBusinessAsync(_business);

            // Assert
            _repository.Verify(x => x.Business.Create(It.IsAny<Business>()), Times.Once);
            _repository.Verify(x => x.UnitOfWork.CompleteAsync(), Times.Once());
        }
    }
}
