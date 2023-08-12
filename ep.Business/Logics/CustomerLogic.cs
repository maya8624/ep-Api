
namespace ep.Logic.Logics
{
    public class CustomerLogic : ICustomerLogic
    {
        private readonly IConfiguration _config;
        private readonly IHubContext<CustomerHub> _hub;
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repository;

        public CustomerLogic(IConfiguration config, IHubContext<CustomerHub> hub, IMapper mapper, IRepositoryWrapper repository)
        {
            _config = config;
            _hub = hub;
            _mapper = mapper;
            _repository = repository;
        }
          
        public async Task CreateCustomers(IEnumerable<Customer> customers)
        {
            await _repository.Customer.CreateRange(customers);
        }        

        public async Task CreateCustomer(CustomerRequest request)
        {
            try
            {
                var shop = await _repository.Business.GetById(request.Qi);
                var orderNo = CryptoService.Decrypt(shop.Key, request.Qv, request.Qo);

                var customer = _mapper.Map<Customer>(request);
                var json = JsonConvert.SerializeObject(customer);
                
                await _hub.Clients.All.SendAsync($"NewCustomerShop{shop.Id}", json);
                //await _repository.Customer.Create(customer);
                //await _repository.UnitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Customer>> GetCustomers(int shopId)
        {
            var date = DateTimeOffset.UtcNow;
            return await _repository.Customer.GetCustomers(shopId, date);
        }    
    }
}
