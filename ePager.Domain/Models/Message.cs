

namespace ePager.Domain.Models
{
    public class Message
    {
        public int Id { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public int Count { get; set; }

        public string Image { get; set; }

        public string Name { get; set; }
        
        public string OrderNo { get; set; }
        
        public string Recipient { get; set; }

        public MessageStatus Status { get; set; }

        public string Text { get; set; }

        public DateTimeOffset UpdatedOn { get; set; }

        public int ShopId { get; set; }

    }
    public enum MessageStatus
    {
        Created,
        Sent,
        Resent,
        Completed,
        Other
    }
}
