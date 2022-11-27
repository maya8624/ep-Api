using ep.Contract.Dtos;
using ep.Domain.ResponseModels;

namespace ep.Service.Interfaces
{
    public interface IShopService
    {
        Task<ShopResponse> CreateShopAsync(ShopCreateDto shop);
        Task<int> PutShopAsync(ShopEditDto shop);
    }
}
