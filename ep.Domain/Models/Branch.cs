﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ep.Domain.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string Mobile { get; set; }
        public string PostCode { get; set; }
    }
}
