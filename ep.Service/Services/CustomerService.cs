namespace ep.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IHubContext<CustomerHub> _hub;
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repository;

        public CustomerService(IHubContext<CustomerHub> hub, IMapper mapper, IRepositoryWrapper repository)
        {
            _hub = hub;
            _mapper = mapper;
            _repository = repository;
        }
          
        public async Task<IEnumerable<Customer>> GetTodaysCustomers(int shopId)
        {
            return await _repository.Customer.GetTodaysCustomers(shopId);
        }

        public async Task CreateCustomerAsync(CustomerRequest request)
        {
            try
            {
                var shop = await _repository.Business.GetById(request.Qi);
                var orderNo = CryptoService.Decrypt(shop.Key, request.Qv, request.Qo);

                var customer = _mapper.Map<Customer>(request);
                customer.OrderNo = orderNo;
                var json = JsonConvert.SerializeObject(customer);
                
                await _hub.Clients.All.SendAsync($"NewCustomerShop{shop.Id}", json);
                //await _repository.Customer.CreateAsync(customer);
                //await _repository.UnitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
