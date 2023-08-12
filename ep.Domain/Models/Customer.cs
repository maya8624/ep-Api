namespace ep.Domain.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string Mobile { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int ShopId { get; set; }

        [Required]
        public DateTimeOffset DateVisited { get; set; }

        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;

        public DateTimeOffset UpdatedOn { get; set; } = DateTimeOffset.UtcNow;
    }   
}
