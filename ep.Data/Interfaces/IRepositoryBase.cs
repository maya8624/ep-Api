namespace ep.Data.Interfaces
{
    public interface IRepositoryBase<T>
    {
        Task Create(T entity);
        Task CreateRange(IEnumerable<T> entities);
        Task<IList<T>> GetAll();
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> expression);
        void Update(T entity);
        void Delete(T entity);
    }
}
