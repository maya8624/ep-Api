using System.ComponentModel.DataAnnotations;

namespace ePager.Domain.Models
{
    public class Visitor
    {
        public int Id { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        [Required]
        public string Mobile { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string OrderNo { get; set; } = string.Empty;

        public int ShopId { get; set; }
    }   
}
