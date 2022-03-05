using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ep.Domain.Dtos
{
    public class MessageCreateDto
    {
        public string? Icon { get; set; }
        public string? OrderNo { get; set; }
        public int ShopId { get; set; }
        public MessageStatus Status { get; set; }
        public string? Text { get; set; }
    }
}
