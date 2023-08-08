namespace ep.Domain.Models
{
    public class Message
    {
        public int Id { get; set; }

        public DateTimeOffset SentAt { get; set; }

        public int MessageType { get; set; }

        public string? Mobile { get; set; }

        public string? Name { get; set; }

        public int ShopId { get; set; }

        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;
    }
}