using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ep.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShopController : ControllerBase
    {
        private readonly ILogger<ShopController> _logger;
        private readonly IShopService _service;

        public ShopController(ILogger<ShopController> logger, IShopService service)
        {
            _logger = logger;
            _service = service;
        }

        [ProducesResponseType(typeof(ShopCreateDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("create")]
        public async Task<ActionResult> PostShopAsync([FromBody] ShopCreateDto shopCreateDto)
        {
            try
            {
                await _service.PostShopAsync(shopCreateDto);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new Exception();
            }
        }
    }
}
