namespace ep.Data.Interfaces
{
    public interface IBusinessRepository : IRepositoryBase<Business>
    {
        Task<IList<Business>> GetBusinessesAsync(int skip, int take);
    }
}
