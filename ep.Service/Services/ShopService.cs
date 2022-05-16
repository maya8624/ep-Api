using ep.Data.Wrappers;
using ep.Domain.ResponseModels;
using ep.Service.Cryptograph;
using ep.Service.Interfaces;

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

        public async Task<ShopResponse> CreateShopAsync(ShopCreateDto dto)
        {
            try
            {
                var shop = _mapper.Map<Shop>(dto);
                var crypto = new CryptoService();
                shop.Key = crypto.GetKey();
                await _repository.Shop.CreateAsync(shop);
                await _repository.UnitOfWork.CompleteAsync();
                var respones = new ShopResponse(shop.Key, shop.Id);
                return respones;
            }
            catch (Exception ex)
            {
                Console.WriteLine(nameof(CreateShopAsync), ex);
                throw;
            }
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
