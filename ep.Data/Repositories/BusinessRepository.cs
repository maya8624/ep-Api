namespace ep.Data.Repositories
{
    public class BusinessRepository : RepositoryBase<Business>, IBusinessRepository
    {
        private EPDbContext _context;
        public BusinessRepository(EPDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
