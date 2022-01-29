namespace ePager.Data.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        private readonly EPDbContext _context;

        public CustomerRepository(EPDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CheckAnyAsync(int shopId, string orderNo) 
            => await _context.Customers.AnyAsync(m => m.ShopId == shopId && m.OrderNo == orderNo);

        public async Task<Customer> GetCustomerByShopIdAndOrderNo(int shopId, string orderNo)            
            => await _context.Customers.FirstOrDefaultAsync(m => m.ShopId == shopId && m.OrderNo == orderNo);
    }
}
