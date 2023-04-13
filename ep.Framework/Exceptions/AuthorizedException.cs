using ep.Framework.Interfaces;

namespace ep.Framework.Exceptions
{
    public class AuthorizedException : Exception, IBaseException
    {
        public string? Details { get; set; }
        public int ErrorCode { get; set; }

        public AuthorizedException() { }

        public AuthorizedException(string message)
            : base(message) { }

        public AuthorizedException(int errorCode, string message)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        public AuthorizedException(int errorCode, string message, string? details)
            : base(message)
        {
            Details = details;
            ErrorCode = errorCode;
        }
    }
}
