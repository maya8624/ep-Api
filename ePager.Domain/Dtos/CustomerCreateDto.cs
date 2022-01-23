using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePager.Domain.Dtos
{
    public class CustomerCreateDto
    {           
        [Required]
        public string? Mobile { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? OrderNo { get; set; }

        [Required]
        public int? ShopId { get; set; }
    }
}
