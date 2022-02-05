using ep.Domain.Dtos;
using ep.Domain.Models;

namespace ep.Service.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomerById(int id);
        Task<Customer> GetCustomerByShopIdAndOrderNo(int shopId, string orderNo);
        Task PostCustomerAsync(CustomerCreateDto createDto);
        Task PatchCustomerAsync(CustomerCreateDto createDto);
    }
}
