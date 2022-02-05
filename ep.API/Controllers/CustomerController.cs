using ep.Service.Interfaces;

namespace ep.API.Controllers
{
    [ApiController]
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}", Name = "customer")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            return await _service.GetCustomerById(id);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("customers")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var result = await _service.GetCustomers();
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{shopId}&{orderNo}", Name = "customer-by-shopid-orderno")]
        public async Task<ActionResult<Customer>> GetCustomerByShopIdAndOrderNo(int shopId, string orderNo)
        {
            return await _service.GetCustomerByShopIdAndOrderNo(shopId, orderNo);
        }

        [ProducesResponseType(typeof(CustomerCreateDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("create")]
        public async Task<ActionResult> PostCustomer([FromBody] CustomerCreateDto customerCreateDto)
        {
            try
            {
                await _service.PostCustomerAsync(customerCreateDto);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, ex);
                throw new Exception();
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPatch("update")]
        public async Task<IActionResult> PatchCustomer([FromBody] CustomerCreateDto customerCreateDto)
        {
            try
            {
                
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, ex);
                throw new Exception();
            }
        }
    }
}
