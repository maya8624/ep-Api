namespace ep.Service.Interfaces
{
    public interface IUserService
    {
        Task<UserView> GetUserAsync(int id);
        Task RegisterAsync(RegisterRequest request);
    }
}
