using ep.Framework.Interfaces;

namespace ep.Framework.Exceptions
{
    public class BusinessException : Exception, IBaseException
    {
        public string? Details { get; set; }
        public int ErrorCode { get; set; }

        public BusinessException() { }

        public BusinessException(string message)
            : base(message) { }

        public BusinessException(int errorCode, string message)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        public BusinessException(string message, Exception inner)
            : base(message, inner) { }

        public BusinessException(int errorCode, string message, string? details)
            : this (message)
        {
            Details = details;
            ErrorCode = errorCode;
        }
    }
}
