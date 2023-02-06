namespace ep.Data.Interfaces
{
    public interface IBusinessRepository : IRepositoryBase<Business>
    {
        Task<IList<Business>> GetBusinessesAsync(string? name, int skip, int take);
    }
}
