namespace ep.Data.Repositories
{
    public class UserTokenRepository : RepositoryBase<UserToken>, IUserTokenRepository
    {
        private readonly EPDbContext _context;

        public UserTokenRepository(EPDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserToken?> GetLatestUserTokenByUserId(int userId)
        {
            return await _context
                .UserTokens
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<UserToken?> GetUserTokenByRefreshToken(string refreshToken, int userId)
        {
            return await _context
                .UserTokens
                .Where(x => x.UserId == userId && x.RefreshToken == refreshToken)
                .FirstOrDefaultAsync();
        }
    }
}
