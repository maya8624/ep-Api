using ePager.Domain.Models;
using System.Threading.Tasks;

namespace ePager.Data.Interfaces
{
    public interface IMessageRepository : IRepositoryBase<Message>
    {
        Task<Message> GetByShopIdAndOrderNo(int shopId, string orderNo);
    }
}
