using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ep.Data.Repositories
{
    public class ShopRepository : RepositoryBase<Shop>, IShopRepository
    {
        private readonly EPDbContext _context;

        public ShopRepository(EPDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
