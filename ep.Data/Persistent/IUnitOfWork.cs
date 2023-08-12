namespace ep.Data.Persistent
{
    public interface IUnitOfWork
    {
        Task<int> CompleteAsync();
    }
}
