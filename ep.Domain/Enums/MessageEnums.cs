using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ep.Domain.Enums
{
    public enum MessageStatus
    {
        Created,
        Prep,
        Sent,
        Resent,
        Completed,
        Other
    }
}
