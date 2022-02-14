﻿using System;
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

        [ProducesResponseType(typeof(ShopCreateDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("create")]
        public async Task<ActionResult<int>> PostShopAsync([FromBody] ShopCreateDto shopCreateDto)
        {
            try
            {
                var shopId = await _service.PostShopAsync(shopCreateDto);
                return Ok(shopId);
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
        public async Task<ActionResult<int>> PutShopAsync([FromBody] ShopEditDto editDto)
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