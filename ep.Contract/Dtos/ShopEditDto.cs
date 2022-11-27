using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ep.Contract.Dtos
{
    public class ShopEditDto
    {
        [Required]
        public int ShopId { get; set; }
        
        [Required]
        public string? ABN { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public string? Owner { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Telephone { get; set; }
    }
}
