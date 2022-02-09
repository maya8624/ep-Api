using ep.Domain.Dtos;

namespace ep.Service.Interfaces
{
    public interface IShopService
    {
        Task PostShopAsync(ShopCreateDto shop);
    }
}
