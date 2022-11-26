using Microsoft.EntityFrameworkCore;

namespace ep.Domain.Models
{
    public class Business
    {
        public int Id { get; set; }
        public string? ABN { get; set; }
        public string? Address { get; set; }
        public string? Owner { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? Name { get; set; }
        public string? Phone { get; set; }
        [Precision(14, 2)]
        public decimal Latitude { get; set; }
        [Precision(14, 2)]
        public decimal Longitude { get; set; }
        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? UpdatedOn { get; set; }
    }
}
