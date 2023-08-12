using ep.API.Controllers.Base;
using ep.Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ep.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class CustomerController : CustomControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerLogic _customer;

        public CustomerController(ILogger<CustomerController> logger, ICustomerLogic customer)
        {
            _logger = logger;
            _customer = customer;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("customers/{shopId:int}")]
        [HttpGet()]
        public async Task<IActionResult> GetCustomers(int shopId)
        {
            try
            {
                var result = await _customer.GetCustomers(shopId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {nameof(GetCustomers)}, message| {ex.Message}", ex);
                return HandleException(ex);
            }
        }

        [ProducesResponseType(typeof(CustomerRequest), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("create")]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerRequest request)
        {
            try
            {
                await _customer.CreateCustomer(request);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {nameof(CreateCustomer)}, message| {ex.Message}", ex);
                return HandleException(ex);
            }
        }
    }
}
