namespace ep.Service.Interfaces
{
    public interface IAuthService
    {
        string CreateToken(UserRequest request);
        string GetToken(UserRequest request);
        string RefreshToken();
    }
}
