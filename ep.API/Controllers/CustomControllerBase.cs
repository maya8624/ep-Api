using ep.Contract.ViewModels;
using ep.Framework.Interfaces;

namespace ep.API.Controllers
{
    public class CustomControllerBase : ControllerBase
    {
        protected IActionResult HandleException<T>(T exception) where T : Exception
        {
            if (exception is IBaseException)
            {
                return BadRequest(new ErrorViewModel
                {
                    ErrorCode = ((IBaseException)exception).ErrorCode,
                    Message = exception.Message,
                    Details = ((IBaseException)exception).Details,
                });
            }

            return StatusCode(500);
        }
    }
}
