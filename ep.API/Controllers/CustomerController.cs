using ep.Service.Interfaces;

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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpGet("{id}", Name = "customer")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            try
            {
                return await _service.GetCustomerById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("customers")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var result = await _service.GetCustomers();
            result.Count();
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("raw-customers/{shopId:int}/")]
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Customer>>> GetTodaysRawCustomers(int shopId)
        {
            try
            {
                if (shopId == 0)
                {
                    return BadRequest();
                }

                var result = await _service.GetTodaysRawCustomers(shopId);                
                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("customer-by-shopid/{shopId}/{orderNo}")]
        [HttpGet()]
        public async Task<ActionResult<Customer>> GetCustomerByShopId(int shopId, string orderNo)
        {
            return await _service.GetCustomerByShopIdAndOrderNo(shopId, orderNo);
        }

        [ProducesResponseType(typeof(ShopCreateDto), StatusCodes.Status201Created)]
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
                _logger.LogError(ex.Message, ex);
                return StatusCode(500, ex.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPatch("update")]
        public async Task<IActionResult> PatchCustomer([FromBody] ShopCreateDto customerCreateDto)
        {
            try
            {
                
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, ex);
                throw;
            }
        }
    }
}
