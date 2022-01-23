using System.Linq.Expressions;

namespace ePager.Data.Interfaces
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> GetAllAsync();

        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);

        Task CreateAsync(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
