using AutoMapper;
using ep.Data.Interfaces;
using ep.Data.Wrappers;
using ep.Domain.Dtos;
using ep.Domain.Models;
using ep.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ep.Service.Services
{
    public class ShopService : IShopService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repository;

        public ShopService(IMapper mapper, IRepositoryWrapper repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<int> PostShopAsync(ShopCreateDto createDto)
        {
            var shop = _mapper.Map<Shop>(createDto);
            shop.CreatedOn = DateTimeOffset.UtcNow;
            await _repository.Shop.CreateAsync(shop);
            await _repository.UnitOfWork.CompleteAsync();
            return shop.Id;
        }

        public async Task<int> PutShopAsync(ShopEditDto editDto)
        {
            var existingShop = _repository.Shop.GetById(editDto.ShopId);
            if (existingShop == null)
            {
                return 0;
            }

            var shop = _mapper.Map<Shop>(editDto);
            shop.UpdatedOn = DateTimeOffset.UtcNow;
            await _repository.UnitOfWork.CompleteAsync();
            return shop.Id;
        }
    }
}
