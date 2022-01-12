using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePagerWeAPI.Persistant
{
    public class UnifOfWork : IUnitOfWork
    {
        private readonly EPagerDbContext _context;

        public UnifOfWork(EPagerDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
