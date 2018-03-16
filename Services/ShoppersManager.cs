using ShoppingCartApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApi.Services
{
    public class ShoppersManager
    {
        private readonly ShoppingCartDbContext _dbContext;
        public ShoppersManager(ShoppingCartDbContext dbContext )
        {
            this._dbContext = dbContext;

        }

        public IEnumerable<Shopper> GetAllShopper() {
            return null;
        }
    }
}
