namespace ep.Service.Interfaces
{
    public interface IAuthService
    {
        string CreateToken(List<Claim> claims);
        Task<UserTokenView> GetTokenAsync(LogInRequest request);
        Task<UserTokenView> SilentLoginAsync(SilentLoginRequest request);
    }
}
