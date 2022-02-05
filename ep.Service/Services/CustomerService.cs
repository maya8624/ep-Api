using AutoMapper;
using ep.Service.Interfaces;
using ep.Data.Wrappers;
using ep.Domain.Dtos;
using ep.Domain.Enums;
using ep.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ep.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repository;

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

        public Task PatchCustomerAsync(CustomerCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        public async Task PostCustomerAsync(CustomerCreateDto createDto)
        {
            var customer = _mapper.Map<Customer>(createDto);
            customer.CreatedOn = DateTimeOffset.UtcNow;

            var message = new Message
            {
                CreatedOn = DateTimeOffset.UtcNow,
                Icon = "create",
                ShopId = customer.ShopId,
                Status = MessageStatus.Created,
                Text = $"Order: {createDto.OrderNo} has been received."
            };

            await _repository.Customer.CreateAsync(customer);
            await _repository.Message.CreateAsync(message);
            await _repository.UnitOfWork.CompleteAsync();
        }
    }
}
