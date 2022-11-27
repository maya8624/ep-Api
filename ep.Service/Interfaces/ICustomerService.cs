using ep.Contract.Dtos;

namespace ep.Service.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetTodaysCustomers(int shopId);
        Task CreateCustomerAsync(CustomerCreateDto createDto);
    }
}
