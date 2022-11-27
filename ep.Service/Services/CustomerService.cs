using ep.Service.Interfaces;
using ep.Data.Wrappers;
using Microsoft.AspNetCore.SignalR;
using ep.API.Service.Hubs;
using Newtonsoft.Json;
using ep.Service.Cryptograph;
using ep.Contract.Dtos;

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

        public async Task CreateCustomerAsync(CustomerCreateDto dto)
        {
            try
            {
                var shop = await _repository.Shop.GetById(dto.Qi);
                var orderNo = CryptoService.Decrypt(shop.Key, dto.Qv, dto.Qo);
                var customer = _mapper.Map<Customer>(dto);
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
