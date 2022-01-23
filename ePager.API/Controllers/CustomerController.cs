namespace WebAPIePager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _wrapper;

        public CustomerController(ILogger<CustomerController> logger, IMapper mapper, IRepositoryWrapper wrapper)
        {
            _logger = logger;
            _mapper = mapper;
            _wrapper = wrapper;
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{shopId}&{orderNo}", Name = "customer-by-shopid-orderno")]
        public async Task<ActionResult<Customer>> GetCustomerByShopIdAndOrderNo(int shopId, string orderNo)
        {
            // CHECK: check possibility of duplicate order numbers.
            return await _wrapper.Customer.GetCustomerByShopIdAndOrderNo(shopId, orderNo);

        }

        [HttpPost("create-visitor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PostCustomer([FromBody] CustomerCreateDto customerCreateDto)
        {
            try
            {
                var customer = _mapper.Map<Customer>(customerCreateDto);
                customer.CreatedOn = DateTimeOffset.UtcNow;
    
                var message = new Message
                {
                    CreatedOn = DateTimeOffset.UtcNow,
                    Icon = "create",
                    ShopId = customer.ShopId,
                    Status = MessageStatus.Created,
                    Text = "Order: 1 - 2022011 has been received"
                };

                await _wrapper.Customer.CreateAsync(customer);
                await _wrapper.Message.CreateAsync(message);
                await _wrapper.UnitOfWork.CompleteAsync();

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
