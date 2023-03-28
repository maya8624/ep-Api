namespace ep.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly EPDbContext _context;

        public UserRepository(EPDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
