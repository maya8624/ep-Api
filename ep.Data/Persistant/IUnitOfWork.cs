namespace ep.Data.Persistant
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
