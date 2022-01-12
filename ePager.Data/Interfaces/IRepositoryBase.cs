using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
