using ep.Contract.ViewModels;

namespace ep.Service.Interfaces
{
    public interface IBusinessService
    {
        Task<IEnumerable<BusinessView>> GetBusinessesAsync();
    }
}
