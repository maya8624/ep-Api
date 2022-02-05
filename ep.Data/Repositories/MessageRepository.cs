namespace ep.Data.Repositories
{
    public class MessageRepository : RepositoryBase<Message>, IMessageRepository
    {
        private readonly EPDbContext _context;

        public MessageRepository(EPDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
