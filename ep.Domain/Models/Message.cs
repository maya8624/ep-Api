using ep.Domain.Enums;

namespace ep.Domain.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string? Icon { get; set; }

        public MessageStatus Status { get; set; }

        public string? OrderNo { get; set; }

        public int ShopId { get; set; }

        public string? Text { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
    }
}