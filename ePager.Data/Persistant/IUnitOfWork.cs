namespace ePager.Data.Persistant
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
