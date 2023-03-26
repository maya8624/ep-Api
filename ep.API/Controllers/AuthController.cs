namespace ep.API.Controllers
{

    [ApiController]
    [Produces("application/json")]

    public class AuthController : CustomControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        public IActionResult Login(UserRequest request)
        {
            try
            {
                var token = _authService.GetToken(request);
                return Ok(token);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {nameof(Login)}, message| {ex.Message}", ex);
                return HandleException(ex);
            }
        }

        //public IActionResult<string> GetToken()
        //{
        //    CreateToken
        //}
    }
}
