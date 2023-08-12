namespace ep.Logic.Interfaces
{
    public interface ICustomerLogic
    {
        Task<IEnumerable<Customer>> GetCustomers(int shopId);
        Task CreateCustomer(CustomerRequest request);
    }
}
