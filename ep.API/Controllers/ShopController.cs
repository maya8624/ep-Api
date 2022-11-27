using ep.Contract.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ep.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
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

        [ProducesResponseType(typeof(ShopCreateDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("create")]
        [HttpPost()]
        public async Task<IActionResult> CreateShopAsync([FromBody] ShopCreateDto dto)
        {
            try
            {
                var resposne = await _service.CreateShopAsync(dto);
                return Ok(resposne);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(ShopCreateDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("update")]
        public async Task<IActionResult> PutShopAsync([FromBody] ShopEditDto editDto)
        {
            try
            {
                var shopId = await _service.PutShopAsync(editDto);
                if (shopId == 0)
                {
                    return BadRequest("no shop.");
                }
                return Ok(shopId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
