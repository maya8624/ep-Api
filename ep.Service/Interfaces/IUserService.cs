namespace ep.Service.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserAsync(int id);
        Task RegisterAsync(RegisterRequest request);
    }
}
