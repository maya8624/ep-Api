using ep.API.Controllers;
using ep.Data.Interfaces;
using ep.Domain.Dtos;
using ep.Service.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ep.Tests.Controllers
{
    public class ShopControllerTests
    {
        private readonly ShopController _controller;
        private readonly Mock<ILogger<ShopController>> _logger;
        private readonly Mock<IShopService> _service;

        public ShopControllerTests()
        {
            _logger = new Mock<ILogger<ShopController>>();
            _service= new Mock<IShopService>();
            _controller = new ShopController(_logger.Object, _service.Object);
        }

        //[Fact]
        //public async Task PostShopAsync_WhenCalled_ShouldSaveShop()
        //{
        //    // Arrange
        //    var shop = new ShopCreateDto
        //    {
        //        ABN = "123 456",
        //        Address = "Sydney",
        //        Owner = "Owner",
        //        Name = "Charllet",
        //        Telephone = "789 102"
        //    };
        //    _service.Setup(x => x.PostShopAsync(shop)).ReturnsAsync(1);

        //    // Act
        //    var result = await _controller.PostShopAsync(shop);
            
        //    // Assert
        //    _service.Verify(x => x.PostShopAsync(shop), Times.Once());
        //    Assert.NotNull(result);
        //}
    }
}
