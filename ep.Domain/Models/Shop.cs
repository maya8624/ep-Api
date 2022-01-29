namespace ePager.Domain.Models
{
    public class Shop
    {
        public int Id { get; set; }
        
        public string? Name { get; set; }
        
        public DateTimeOffset CreatedOn { get; set; }
      
        public ICollection<Message>? Messages { get; set; }

        public ICollection<Customer>? Customers { get; set; }
    }
}
