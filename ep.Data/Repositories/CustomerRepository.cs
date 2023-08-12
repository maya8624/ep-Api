namespace ep.Data.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        private readonly EPDbContext _context;

        public CustomerRepository(EPDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CheckAny(int shopId) 
            => await _context.Customers
                    .AnyAsync(c => c.ShopId == shopId);

        public async Task<IEnumerable<Customer>> GetCustomers(int shopId, DateTimeOffset date)
        {
            //TODO: class for this query
            var result = await _context.Customers
                .Where(x => x.ShopId == shopId)
                .Where(x => x.CreatedOn.Date == date)
                .ToListAsync();

            return result;
        }
    }
}
