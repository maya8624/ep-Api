using ep.Service.Interfaces;
using ep.Data.Wrappers;
//using Microsoft.AspNetCore.SignalR;
using ep.API.Service.Hubs;
using Newtonsoft.Json;
//using Newtonsoft.Json;

namespace ep.Service.Services
{
    public class CustomerService : ICustomerService
    {
        //private readonly IHubContext<CustomerHub> _hub;
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repository;

        //public CustomerService(IHubContext<CustomerHub> hub, IMapper mapper, IRepositoryWrapper repository)
        //{
        //    _hub = hub;
        //    _mapper = mapper;
        //    _repository = repository;
        //}

        public CustomerService(IMapper mapper, IRepositoryWrapper repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<Customer> GetCustomerById(int id)
        { 
            return await _repository.Customer.GetById(id);
        }        
        
        public async Task<Customer> GetCustomerByShopIdAndOrderNo(int shopId, string orderNo)
        {
            // CHECK: check possibility of duplicate order numbers.
            return await _repository.Customer.GetCustomerByShopIdAndOrderNo(shopId, orderNo);
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _repository.Customer.GetAllAsync();
        }

        public async Task<IEnumerable<Customer>> GetTodaysRawCustomers(int shopId)
        {
            return await _repository.Customer.GetTodaysRawCustomers(shopId);
        }

        public Task PatchCustomerAsync(CustomerCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        public async Task CreateCustomerAsync(CustomerCreateDto createDto)
        {
            try
            {
                var customer = _mapper.Map<Customer>(createDto);
                customer.CreatedOn = DateTimeOffset.UtcNow;
                var json = JsonConvert.SerializeObject(createDto);
                //await _hub.Clients.All.SendAsync("NewCustomer", createDto.Name);
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
