namespace ePager.Domain.Models
{
    public class Message
    {
        public int Id { get; set; }
                
        [Column(Order = 5)]
        public DateTimeOffset CreatedOn { get; set; }

        public string? Icon { get; set; }

        public MessageStatus Status { get; set; }

        public int ShopId { get; set; }

        public string? Text { get; set; }
    }
}