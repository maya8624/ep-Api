namespace ep.Domain.Models
{
    public class Customer
    {
        public int Id { get; set; }                

        [Required]
        public string? Mobile { get; set; } = string.Empty;

        [Required]
        public string? Name { get; set; } = string.Empty;
                
        public string? OrderNo { get; set; } = string.Empty;

        public int? MessageId { get; set; }

        [Required]
        public int ShopId { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public ICollection<Message>? Messages { get; set; }
    }   
}
