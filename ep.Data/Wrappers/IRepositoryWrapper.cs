namespace ep.Data.Wrappers
{
    public interface IRepositoryWrapper
    {
        ICustomerRepository Customer { get; }
        IMessageRepository Message { get; }
        IShopRepository Shop { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}
