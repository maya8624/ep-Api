namespace ep.Domain.Models
{
    public class Business
    {
        public int Id { get; set; }
        public string? ABN { get; set; }
        public string? Address { get; set; }
        public string? Owner { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string? Key { get; set; }
        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? UpdatedOn { get; set; }
    }
}
