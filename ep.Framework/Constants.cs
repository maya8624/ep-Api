namespace ep.Framework
{
    public class Constants
    {
        public const int DefaultTokenExpireMins = 1;
        public const int DefaultTokenExpireDays = 7;
    }

    public class ErrorCodeConstants
    {
        public const int Undefined = 0;
        public const int BusinessErrorCode = 1000;
        public const int NotFoundErrorCode = 1001;
        public const int CredentialErrorCode = 1002;
    }

    public class ErrorMessageConstants
    {
        public const string UserNotCorrect = " User or password not correct";
    }
}
