using Microsoft.AspNetCore.Authorization;

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
        [AllowAnonymous]
        public async Task<IActionResult> Login(LogInRequest request)
        {
            try
            {            
                var userToken = await _authService.GetTokenAsync(request);
                return Ok(userToken);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {nameof(Login)}, message| {ex.Message}", ex);
                return HandleException(ex);
            }
        }

        [Route("refresh")]
        [HttpPost()]
        public async Task<IActionResult> SilentLogin(SilentLoginRequest request)
        {
            try
            {
                var token = await _authService.SilentLoginAsync(request);
                return Ok(token);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {nameof(SilentLogin)}, message: {ex.Message}", ex);
                return HandleException(ex);
            }
        }
    }
}
