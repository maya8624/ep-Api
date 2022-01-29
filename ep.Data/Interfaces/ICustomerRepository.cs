
using ePager.Domain.Models;

namespace ePager.Data.Interfaces
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        Task<bool> CheckAnyAsync(int shopId, string orderNo);

        Task<Customer> GetCustomerByShopIdAndOrderNo(int shopId, string orderNo);
    }
}
