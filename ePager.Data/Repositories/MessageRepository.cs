using ePager.Data.Interfaces;
using ePager.Data.Persistant;
using ePager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ePager.Data.Repositories
{
    public class MessageRepository : RepositoryBase<Message>, IMessageRepository
    {
        private readonly EPagerDbContext _context;

        public MessageRepository(EPagerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task CreateMessage(Message message)
        {
            await _context.AddAsync(message);
        }

        public async Task<Message> GetByOrderNoAsync(int shopId, string orderNo)
        {
            return await _context.Messages.FirstOrDefaultAsync(m => m.ShopId == shopId && m.OrderNo == orderNo);
        }

        public void UpdateMessage(Message message)
        {
            _context.Update(message);
        }
    }
}
