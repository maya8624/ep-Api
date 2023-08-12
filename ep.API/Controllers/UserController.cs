using ep.API.Controllers.Base;
using ep.Logic.Logics;
using Microsoft.AspNetCore.Authorization;

namespace ep.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : CustomControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserLogic _user;

        public UserController(ILogger<UserController> logger, IUserLogic user)
        {
            _logger = logger;
            _user = user;
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
                await _user.Register(request);
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
                var user = await _user.GetUser(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {nameof(GetUserAsync)}, message| {ex.Message}", ex);
                return HandleException(ex);
            }
        }
    }
}
