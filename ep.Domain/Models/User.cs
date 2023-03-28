namespace ep.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public string? Password { get; set; }
        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset UpdatedOn { get; set; } = DateTimeOffset.UtcNow;
        public ICollection<UserToken>? UserTokens { get; set; }
    }
}
