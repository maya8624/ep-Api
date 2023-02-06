using System.Dynamic;

namespace ep.Data.Repositories
{
    public class BusinessRepository : RepositoryBase<Business>, IBusinessRepository
    {
        private EPDbContext _context;

        public BusinessRepository(EPDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IList<Business>> GetBusinessesAsync(string? name, int skip, int take)
        {
            var data = _context.Business?.AsNoTracking();

            if (string.IsNullOrEmpty(name) is false)
                data = data?.Where(x => x.Name!.Contains(name));

            return await data
                ?.Skip(skip)
                ?.Take(take)
                ?.ToListAsync();
        }
    }
}
