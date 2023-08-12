namespace ep.Data.Persistent
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EPDbContext _context;

        public UnitOfWork(EPDbContext context)
        {
            _context = context;
        }

        public async Task<int> CompleteAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
