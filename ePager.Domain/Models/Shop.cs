namespace ePager.Domain.Models
{
    public class Shop
    {
        public int Id { get; set; }
        
        public string? Name { get; set; }
        
        public DateTimeOffset CreatedOn { get; set; }
        
        public ICollection<Message> Messages { get; set; } = new List<Message>();
        
        public ICollection<Visitor> Visitors { get; set; } = new List<Visitor>();

        public ICollection<Message>? Mesage { get; set; }
    }
}
