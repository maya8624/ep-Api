using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ep.Domain.Models
{
    public class RequestLimit
    {
        public int Id { get; set; }

        public int Limits { get; set; }
        
        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;
        
        public DateTimeOffset UpdatedOn { get; set; } = DateTimeOffset.UtcNow;
    }
}
