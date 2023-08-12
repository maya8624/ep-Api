namespace ep.Logic.Interfaces
{
    public interface IBusinessLogic
    {
        Task<ResponseView<IEnumerable<BusinessView>>> GetBusinessesAsync(BusinessSearchRequest request);
        Task SaveBusinessAsync(BusinessRequest request);
    }
}
