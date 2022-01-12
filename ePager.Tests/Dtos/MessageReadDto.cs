using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIePager.Dtos
{
    public class MessageReadDto
    {
        public string Mobile { get; set; }        
        public string Recipient { get; set; }
        public string OrderNo { get; set; }
        public int ShopId { get; set; }
    }
}
