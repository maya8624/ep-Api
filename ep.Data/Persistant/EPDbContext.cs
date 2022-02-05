namespace ep.Data.Persistant
{
    public class EPDbContext : DbContext
    {
        public EPDbContext(DbContextOptions<EPDbContext> options) : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Customer> Customers{ get; set; }
    }
}
