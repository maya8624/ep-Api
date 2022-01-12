using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ePager.Domain.Models;

namespace ePagerWeAPI.Persistant
{
    public class EPagerDbContext : DbContext
    {
        public EPagerDbContext(DbContextOptions<EPagerDbContext> options) : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
    }
}
