using ep.API.Service.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace ep.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _service;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService service)
        {
            _logger = logger;
            _service = service;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("GetTodaysCustomers/{shopId:int}/")]
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Customer>>> GetTodaysCustomers(int shopId)
        {
            try
            {
                if (shopId == 0)
                {
                    return BadRequest();
                }

                var result = await _service.GetTodaysCustomers(shopId);                
                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ex.Message);
            }
        }

        [ProducesResponseType(typeof(CustomerCreateDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("create")]
        public async Task<ActionResult> CreateCustomer([FromBody] CustomerCreateDto customerCreateDto)
        {
            try
            {
                await _service.CreateCustomerAsync(customerCreateDto);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
