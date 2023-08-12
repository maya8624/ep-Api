namespace ep.Logic.Logics
{
    public interface IUserLogic
    {
        Task<UserView> GetUser(int id);
        Task Register(RegisterRequest request);
    }
}
