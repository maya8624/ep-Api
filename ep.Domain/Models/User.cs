namespace ep.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string Role { get; set; } = string.Empty;
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }

    }
}
