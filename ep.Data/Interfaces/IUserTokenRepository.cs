namespace ep.Data.Interfaces
{
    public interface IUserTokenRepository : IRepositoryBase<UserToken>
    {
        Task<UserToken?> GetLatestUserTokenByUserId(int userId);
        Task<UserToken?> GetUserTokenByRefreshToken(string refreshToken, int userId);
    }
}
