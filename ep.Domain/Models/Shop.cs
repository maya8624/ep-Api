namespace ep.Domain.Models
{
    public class Shop
    {
        public int Id { get; set; }

        [Required]
        public string? ABN { get; set; }
        
        [Required]
        public string? Address { get; set; }

        [Required]
        public string? Owner { get; set; }
        
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Telephone { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset UpdatedOn { get; set; }
      
        public ICollection<Message>? Messages { get; set; }

        public ICollection<Customer>? Customers { get; set; }
    }
}
