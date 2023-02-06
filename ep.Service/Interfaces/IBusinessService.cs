using ep.Contract.RequestModels;
using ep.Contract.ViewModels;

namespace ep.Service.Interfaces
{
    public interface IBusinessService
    {
        Task<ResponseView<IEnumerable<BusinessView>>> GetBusinessesAsync(BusinessSearchRequest request);
        Task SaveBusinessAsync(BusinessRequest request);
    }
}
