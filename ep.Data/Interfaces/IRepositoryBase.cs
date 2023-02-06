namespace ep.Data.Interfaces
{
    public interface IRepositoryBase<T>
    {
        Task CreateAsync(T entity);
        Task<IList<T>> GetAllAsync();
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> expression);
        void Update(T entity);
        void Delete(T entity);
    }
}
