using ShoppingCartApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApi.Services
{
    public class ManufacturersManager : IRepository<Manufacturer>
    {
        public bool Add(Manufacturer t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Manufacturer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Manufacturer GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
