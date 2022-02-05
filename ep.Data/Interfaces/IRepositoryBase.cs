using System.Linq.Expressions;

namespace ep.Data.Interfaces
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetById(int id);

        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);

        Task CreateAsync(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
