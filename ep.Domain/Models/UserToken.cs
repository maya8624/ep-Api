namespace ep.Domain.Models
{
    public class UserToken
    {
        public int Id { get; set; }
        public string? RefreshToken { get; set; }
        public string? Token { get; set; }
        public int UserId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public User? User { get; set; }
    }
}
