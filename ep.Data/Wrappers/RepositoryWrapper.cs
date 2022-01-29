namespace ePager.Data.Wrappers
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly EPDbContext _context;
        private ICustomerRepository? _customer;
        private IMessageRepository? _message;
        private IUnitOfWork? _unitOfWork;

        public RepositoryWrapper(EPDbContext context) => _context = context;

        public ICustomerRepository Customer 
            => _customer is null ? _customer = new CustomerRepository(_context) : _customer;

        public IMessageRepository Message 
            => _message is null ? _message = new MessageRepository(_context) : _message;

        public IUnitOfWork UnitOfWork 
            => _unitOfWork is null ? _unitOfWork = new UnitOfWork(_context) : _unitOfWork;
    }
}
