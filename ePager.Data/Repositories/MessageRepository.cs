using ePager.Data.Interfaces;
using ePager.Data.Persistant;
using ePager.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ePager.Data.Repositories
{
    public class MessageRepository : RepositoryBase<Message>, IMessageRepository
    {
        private readonly EPagerDbContext _context;

        public MessageRepository(EPagerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Message> GetByShopIdAndOrderNo(int shopId, string orderNo)
        {
            return await _context.Messages.FirstOrDefaultAsync(m => m.ShopId == shopId && m.OrderNo == orderNo);
        }

        public void UpdateMessage(Message message)
        {
            _context.Update(message);
        }
    }
}
