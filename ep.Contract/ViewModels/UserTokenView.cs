namespace ep.Contract.ViewModels
{
    public class UserTokenView
    {
        public UserView? User { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
