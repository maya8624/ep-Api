using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ep.Service.Services
{
    public class ServiceBase
    {
        private static void ThrowAuthorizedException(string errorMessage = ErrorMessageConstants.UserNotCorrect)
        {
            throw new AuthorizedException(ErrorCodeConstants.CredentialError, errorMessage);
        }
    }
}
