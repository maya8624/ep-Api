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

        public async Task<Customer> GetCustomerByShopIdAndOrderNo(int shopId, string orderNo)            
            => await _context.Customers
                    .FirstOrDefaultAsync(c => c.ShopId == shopId && c.OrderNo == orderNo);

        public async Task<IEnumerable<Customer>> GetTodaysRawCustomers(int shopId)
        {            
            return await _context.Customers
                .Where(c => c.ShopId == shopId &&
                            c.CreatedOn.Date == DateTimeOffset.UtcNow.Date &&
                            c.MessageId == null)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
