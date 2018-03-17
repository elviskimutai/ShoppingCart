using ShoppingCartApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApi.Services
{
    public class PaymentMethodsManager:IRepository<PaymentMethod>
    {
        private readonly ShoppingCartDbContext _dbContext;
        public PaymentMethodsManager(ShoppingCartDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Add(PaymentMethod paymentMethod)
        {
            try
            {
                this._dbContext.PaymentMethods.Add(paymentMethod);
                this._dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            
           
        }

        public IEnumerable<PaymentMethod> GetAll() {
            var paymentMethods = this._dbContext.PaymentMethods.ToList();
            return paymentMethods;
        }

        public PaymentMethod GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
