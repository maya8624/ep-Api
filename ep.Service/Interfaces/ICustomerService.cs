using ep.Contract.RequestModels;

namespace ep.Service.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetTodaysCustomers(int shopId);
        Task CreateCustomerAsync(CustomerRequest request);
    }
}
