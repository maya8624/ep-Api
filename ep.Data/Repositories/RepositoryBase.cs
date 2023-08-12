namespace ep.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly EPDbContext _context;

        public RepositoryBase(EPDbContext context)
        {
            _context = context;
        }

        public async Task Create(T entity)
            => await _context.Set<T>().AddAsync(entity);

        public async Task CreateRange(IEnumerable<T> entities)
            => await _context.Set<T>().AddRangeAsync(entities);

        public void Delete(T entity)
            => _context.Set<T>().Remove(entity);

        public async Task<IList<T>> GetAll() 
            => await _context.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> expression)
        => await _context.Set<T>().Where(expression).ToListAsync();

        public async Task<T> GetById(int id) 
            => await _context.Set<T>().FindAsync(id);

        public void Update(T entity) 
            => _context.Set<T>().Update(entity);
    }
}
