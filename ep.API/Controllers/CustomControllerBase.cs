using ep.Contract.ViewModels;
using ep.Framework.Interfaces;

namespace ep.API.Controllers
{
    public class CustomControllerBase : ControllerBase
    {
        protected IActionResult HandleException<T>(T exception) where T : Exception
        {
            if (exception is IBusinessException)
            {
                return BadRequest(new ErrorViewModel
                {
                    ErrorCode = ((IBusinessException)exception).ErrorCode,
                    Message = exception.Message,
                    Details = ((IBusinessException)exception).Details,
                });
            }

            return StatusCode(500);
        }
    }
}
