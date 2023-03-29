namespace ep.Domain.Models
{
    public class UserToken
    {
        public int Id { get; set; }
        public string? RefreshToken { get; set; }
        public DateTimeOffset TokenExpires { get; set; }
        public int UserId { get; set; }
        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset UpdatedOn { get; set; } = DateTimeOffset.UtcNow;
        public User? User { get; set; }
    }
}
