using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ep.Domain.Dtos
{
    public class ShopCreateDto
    {
        [Required]
        public string? ABN { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Owner { get; set; }

        [Required]
        public string? Name { get; set; }
        
        [Required]
        public string? Telephone { get; set; }
    }
}
