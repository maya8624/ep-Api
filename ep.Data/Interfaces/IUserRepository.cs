namespace ep.Data.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User?> GetUserByEmailAsync(string email, string password);
    }
}
