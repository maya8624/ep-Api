namespace ep.Logic.Interfaces
{
    public interface IAuthLogic
    {
        string CreateToken(List<Claim> claims);
        Task<UserTokenView> GetTokenAsync(LogInRequest request);
        Task<UserTokenView> SilentLoginAsync(SilentLoginRequest request);
    }
}
