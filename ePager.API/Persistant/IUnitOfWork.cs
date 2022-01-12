using System.Threading.Tasks;

namespace ePagerWeAPI.Persistant
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
