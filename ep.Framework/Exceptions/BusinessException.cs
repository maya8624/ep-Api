using ep.Framework.Interfaces;

namespace ep.Framework.Exceptions
{
    public class BusinessException : Exception, IBusinessException
    {
        public string? Details { get; set; }
        public int ErrorCode { get; set; }

        public BusinessException() { }
        
        public BusinessException(string message)
            : base(message) { }
        
        public BusinessException(string message, Exception inner)
            : base(message, inner) { }

        public BusinessException(string details, int errorCode, string message)
            : this (message)
        {
            Details = details;
            ErrorCode = errorCode;
        }
    }
}
