using ep.Contract.ViewModels;

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

        [ProducesResponseType(typeof(BusinessView), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("GetBusinessesAsync")]
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Business>>> GetBusinessesAsync()
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
    }
}
