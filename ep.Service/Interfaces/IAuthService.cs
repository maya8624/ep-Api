namespace ep.Service.Interfaces
{
    public interface IAuthService
    {
        string CreateToken(List<Claim> claims);
        Task<UserTokenView> GetTokenAsync(UserRequest request);
        Task<UserTokenView> SilentLoginAsync(SilentLoginRequest request);
    }
}
