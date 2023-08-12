using ep.API.Controllers;
using ep.API.Controllers.Base;

namespace ep.Api.Controllers
{
    public class ServiceBusController : CustomControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IServiceBusService _service;

        public ServiceBusController(ILogger<CustomerController> logger, IServiceBusService service)
        {
            _logger = logger;
            _service = service;
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("send-message")]
        public async Task<IActionResult> SendMessage(ServiceBusRequest request)
        {
            try
            {
                await _service.SendMessage(request);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {nameof(SendMessage)}, message| {ex.Message}", ex);
                return HandleException(ex);
            }
        }
    }
}
