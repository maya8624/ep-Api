using ep.Domain.Dtos;

namespace ep.Service.Interfaces
{
    public interface IShopService
    {
        Task<int> PostShopAsync(ShopCreateDto shop);
        Task<int> PutShopAsync(ShopEditDto shop);
    }
}
