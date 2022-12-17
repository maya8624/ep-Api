namespace ep.Data.Wrappers
{
    public interface IRepositoryWrapper
    {
        ICustomerRepository Customer { get; }
        IMessageRepository Message { get; }
        IBusinessRepository Business { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}
