namespace ePager.Domain.Models
{
    public class Visitor
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string? Mobile { get; set; }
        public string? Name { get; set; }
        public string? OrderNo { get; set; }
        public int ShopId { get; set; }
    }   
}
