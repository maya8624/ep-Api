namespace ep.Framework
{
    public class Constants
    {
        public const int DefaultTokenExpireMins = 1;
        public const int DefaultTokenExpireDays = 7;
        public const int MessageTypeSMS = 1;
        public const int MessageTypeBuzz = 2;
    }

    public class ErrorCodeConstants
    {
        public const int Undefined = 0;
        public const int BusinessError = 1000;
        public const int NotFoundError = 1001;
        public const int CredentialError = 1002;
        public const int TokenExpiredError = 1003;
    }

    public class ErrorMessageConstants
    {
        public const string UserNotCorrect = " User or password not correct";
        public const string InvalidUser = "Invalid user";
        public const string InvalidRefreshToken = "Invalid refresh token";
        public const string TokenExpired = "Token Expired";
        public const string RefreshTokenExpired = "RefreshToken Expired";
    }
}
