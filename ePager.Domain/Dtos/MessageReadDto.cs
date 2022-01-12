namespace ePager.Domain.Dtos
{
    public class MessageReadDto
    {
        public string? Mobile { get; set; }        
        public string? Recipient { get; set; }
        public string? OrderNo { get; set; }
        public int ShopId { get; set; }
    }
}
