namespace ep.Data.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        private readonly EPDbContext _context;

        public CustomerRepository(EPDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CheckAnyAsync(int shopId, string orderNo) 
            => await _context.Customers
                    .AnyAsync(c => c.ShopId == shopId && c.OrderNo == orderNo);

        public async Task<IEnumerable<Customer>> GetTodaysCustomers(int shopId)
        {
            //TODO: check comparing dates
            var result = await _context.Customers
                .AsNoTracking()
                .Where(c => c.ShopId == shopId &&
                            c.CreatedOn.Date == DateTimeOffset.UtcNow.Date)
                .ToListAsync();
            return result;
        }
    }
}
