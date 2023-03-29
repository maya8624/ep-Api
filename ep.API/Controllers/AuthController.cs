namespace ep.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("auth/[controller]")]
    public class AuthController : CustomControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [Route("login")]
        [HttpPost()]
        public IActionResult Login(UserRequest request)
        {
            try
            {
                var token = _authService.GetTokenAsync(request);
                return Ok(token);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {nameof(Login)}, message| {ex.Message}", ex);
                return HandleException(ex);
            }
        }

        [Route("refresh")]
        [HttpPost()]
        public async Task<IActionResult> GetRefreshToken(string refreshToken)
        {
            try
            {
                var token = await _authService.GetRefreshTokenAsync(refreshToken);
                return Ok(token);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {nameof(GetRefreshToken)}, message: {ex.Message}", ex);
                return HandleException(ex);
            }
        }
    }
}
