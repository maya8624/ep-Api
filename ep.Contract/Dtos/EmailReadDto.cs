using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ep.Contract.Dtos
{
    public class EmailReadDto
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

    }
}
