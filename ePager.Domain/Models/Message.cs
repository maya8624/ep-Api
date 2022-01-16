using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ePager.Domain.Models
{
    public class Message
    {
        public int Id { get; set; }

        public int Count { get; set; }

        [Column("7")]
        public DateTimeOffset CreatedOn { get; set; }

        [Required]
        public string Mobile { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string OrderNo { get; set; } = string.Empty;

        public int ShopId { get; set; }

        public ICollection<MessageHistory>? History { get; set; }
    }
}