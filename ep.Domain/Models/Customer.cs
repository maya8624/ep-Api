namespace ep.Domain.Models
{
    public class Customer
    {
        public int Id { get; set; }
                
        public DateTimeOffset CreatedOn { get; set; }

        [Required]
        public string? Mobile { get; set; } = string.Empty;

        [Required]
        public string? Name { get; set; } = string.Empty;

        [Required]
        public string? OrderNo { get; set; } = string.Empty;

        public int ShopId { get; set; }

        public ICollection<Message>? Messages { get; set; }
    }   
}
