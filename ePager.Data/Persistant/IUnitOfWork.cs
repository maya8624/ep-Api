using System.Threading.Tasks;

namespace ePager.Data.Persistant
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
