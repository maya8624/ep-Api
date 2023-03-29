namespace ep.Service.Interfaces
{
    public interface IAuthService
    {
        string CreateToken(UserRequest request);
        Task<UserTokenView> GetTokenAsync(UserRequest request);
        Task<string> GetRefreshTokenAsync(string refreshToken);
    }
}
