
using ep.Domain.Models;

namespace ep.Data.Interfaces
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        Task<bool> CheckAnyAsync(int shopId, string orderNo);

        Task<Customer> GetCustomerByShopIdAndOrderNo(int shopId, string orderNo);
    }
}
