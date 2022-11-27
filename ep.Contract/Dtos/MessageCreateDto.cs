using ep.Domain.Enums;

namespace ep.Contract.Dtos
{
    public class MessageCreateDto
    {
        public int CustomerId { get; set; }
        public string? Icon { get; set; }
        public string? OrderNo { get; set; }
        public int ShopId { get; set; }
        public MessageStatus Status { get; set; }
        public string? Text { get; set; }
    }
}
