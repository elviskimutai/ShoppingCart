using Microsoft.EntityFrameworkCore;
using ShoppingCartApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApi.Services
{
    public class OrdersManager : IRepository<Order>
    {
        private readonly ShoppingCartDbContext _dbContext;
        public OrdersManager(ShoppingCartDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Add(Order order)
        {
            try
            {
                this._dbContext.Orders.Add(order);
                this._dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IEnumerable<Order> GetAll()
        {
            var orders = this._dbContext.Orders.ToList();
            return orders;
        }

        public Order GetById(Guid id)
        {
            var order = this._dbContext.Orders.Find(id);
            return order;
        }

        public bool Remove(Guid id)
        {
            try
            {
                var order = this._dbContext.Orders.Find(id);
                this._dbContext.Remove(order);
                this._dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
           

        }
    }
}
