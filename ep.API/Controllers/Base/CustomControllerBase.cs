using ep.Framework.Interfaces;

namespace ep.API.Controllers.Base
{
    public class CustomControllerBase : ControllerBase
    {
        protected IActionResult HandleException<T>(T exception) where T : Exception
        {
            if (exception is IBaseException baseException)
            {
                return BadRequest(new ErrorViewModel
                {
                    ErrorCode = baseException.ErrorCode,
                    Message = exception.Message,
                    Details = baseException.Details,
                });
            }

            return StatusCode(500);
        }
    }
}
