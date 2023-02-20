using ep.Contract.RequestModels;
using ep.Contract.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ep.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]

    public class BusinessController : CustomControllerBase
    {
        private readonly ILogger<BusinessController> _logger;
        private readonly IBusinessService _service;

        public BusinessController(ILogger<BusinessController> logger, IBusinessService service)
        {
            _logger = logger;
            _service = service;
        }

        [ProducesResponseType(typeof(ResponseView<IEnumerable<BusinessView>>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("businesses")]
        [HttpPost()]
        public async Task<IActionResult> GetBusinessesAsync(BusinessSearchRequest request)
        {
            try
            {
                var result = await _service.GetBusinessesAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {nameof(GetBusinessesAsync)}, message| {ex.Message}", ex);
                return HandleException(ex);
            }
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("create")]
        [HttpPost()]
        public async Task<IActionResult> SaveBusinessAsync(BusinessRequest request)
        {
            try
            {
                await _service.SaveBusinessAsync(request);
                return Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {nameof(SaveBusinessAsync)}, message| {ex.Message}", ex);
                return StatusCode(500, ex.Message);
            }
        }

        //[ProducesResponseType(typeof(ShopRequest), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[HttpPut("update")]
        //public async Task<IActionResult> PutShopAsync([FromBody] ShopEditDto editDto)
        //{
        //    try
        //    {
        //        var shopId = await _service.PutShopAsync(editDto);
        //        if (shopId == 0)
        //        {
        //            return BadRequest("no shop.");
        //        }
        //        return Ok(shopId);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        return StatusCode(500, ex.Message);
        //    }
        //}
    }
}
