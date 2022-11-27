namespace ep.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly EPDbContext _context;

        public RepositoryBase(EPDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
            => await _context.Set<T>().AddAsync(entity);

        public void Delete(T entity)
            => _context.Set<T>().Remove(entity);

        public async Task<IEnumerable<T>> GetAllAsync() 
            => await _context.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> expression)
        => await _context.Set<T>().Where(expression).ToListAsync();

        public async Task<T> GetById(int id) 
            => await _context.Set<T>().FindAsync(id);

        public void Update(T entity) 
            => _context.Set<T>().Update(entity);
    }
}
