using ePager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePager.Domain.Models
{
    public class MessageHistory
    {
        public int Id { get; set; }
                
        [Column("5")]
        public DateTimeOffset CreatedOn { get; set; }

        public string? Icon { get; set; }

        public MessageStatus Status { get; set; }
        
        public string? Text { get; set; }
    }
}
