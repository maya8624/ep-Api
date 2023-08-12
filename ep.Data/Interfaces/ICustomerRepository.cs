
using ep.Domain.Models;

namespace ep.Data.Interfaces
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        Task<bool> CheckAny(int shopId);
        Task<IEnumerable<Customer>> GetCustomers(int shopId, DateTimeOffset date);
    }
}
