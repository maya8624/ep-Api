using ep.Domain.Dtos;
using ep.Domain.Models;

namespace ep.Service.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetTodaysCustomers(int shopId);
        Task CreateCustomerAsync(CustomerCreateDto createDto);
    }
}
