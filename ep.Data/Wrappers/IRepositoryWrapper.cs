namespace ep.Data.Wrappers
{
    public interface IRepositoryWrapper
    {
        ICustomerRepository Customer { get; }
        IMessageRepository Message { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}
