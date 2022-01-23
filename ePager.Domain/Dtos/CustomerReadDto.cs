using ePager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePager.Domain.Dtos
{
    public class CustomerReadDto
    { 
        public string? Mobile { get; set; }
        public string? Name { get; set; }
        public string? OrderNo { get; set; }
        public int? ShopId { get; set; }
        public Message? Message { get; set; }
    }
}
