namespace ep.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : CustomControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _service;

        public UserController(ILogger<UserController> logger, IUserService service)
        {
            _logger = logger;
            _service = service;
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("register")]
        [HttpPost()]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            try
            {
                await _service.RegisterAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {nameof(RegisterAsync)}, message| {ex.Message}", ex);
                return HandleException(ex);
            }
        }


        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("user/{id:int}")]
        [HttpGet()]
        public async Task<IActionResult> GetUserAsync(int id)
        {
            try
            {
                await _service.GetUserAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {nameof(GetUserAsync)}, message| {ex.Message}", ex);
                return HandleException(ex);
            }
        }
    }
}
