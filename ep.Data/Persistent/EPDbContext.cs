namespace ep.Data.Persistent
{
    public class EPDbContext : DbContext
    {
        public EPDbContext(DbContextOptions<EPDbContext> options) : base(options)
        {
        }

        public DbSet<Business> Business { get; set; }
        public DbSet<Customer> Customers{ get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<RequestDetail> RequestDetails{ get; set; }
        public DbSet<RequestLimit> RequestLimit{ get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
