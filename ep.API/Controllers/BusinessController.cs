using ep.Contract.RequestModels;
using ep.Contract.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ep.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]

    public class BusinessController : ControllerBase
    {
        private readonly ILogger<BusinessController> _logger;
        private readonly IBusinessService _service;

        public BusinessController(ILogger<BusinessController> logger, IBusinessService service)
        {
            _logger = logger;
            _service = service;
        }

        [ProducesResponseType(typeof(IEnumerable<BusinessView>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("GetBusinessesAsync")]
        [HttpGet()]
        public async Task<IActionResult> GetBusinessesAsync()
        {
            try
            {
                var result = await _service.GetBusinessesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {nameof(GetBusinessesAsync)}, message| {ex.Message}", ex);
                return StatusCode(500, ex.Message);
            }
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("SaveBusiness")]
        [HttpPost()]
        public async Task<IActionResult> SaveBusiness(BusinessRequest request)
        {
            try
            {
                await _service.SaveBusinessAsync(request);
                return Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {nameof(SaveBusiness)}, message| {ex.Message}", ex);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
