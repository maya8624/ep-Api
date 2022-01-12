using ePager.Data.Interfaces;
using ePager.Data.Persistant;
using ePager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePager.Data.Repositories
{
    public class VisitorRepository : RepositoryBase<Visitor>, IVisitorRepository
    {
        public VisitorRepository(EPagerDbContext context) : base(context)
        {
        }
    }
}
