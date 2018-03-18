using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartApi.Models;
using ShoppingCartApi.Services;

namespace ShoppingCartApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Orders")]
    public class OrdersController : Controller
    {
        private OrdersManager _ordersManager;
        
        public OrdersController(ShoppingCartDbContext dbContext)
        {           
            _ordersManager = new OrdersManager(dbContext);
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Order>), 200)]
        public IActionResult Get() {
            var orders = this._ordersManager.GetAll();
            return new OkObjectResult(orders);
        }

        [HttpGet("{id}", Name = "GetOrder")]
        public IActionResult Get(Guid id)
        {
            var orders = this._ordersManager.GetById(id);
            return new OkObjectResult(orders);
        }
        [HttpPost]
        public IActionResult Post([FromBody]Order order) {
            var result = this._ordersManager.Add(order);
            if (result) {
                return new OkResult();
            }
            return StatusCode(500, "could not create order");
        }
       [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) {
            var result = this._ordersManager.Remove(id);
            if (result) {
                return new OkResult();
            }
            return StatusCode(500, "could not remove order");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Order order)
        {
            return null;
        }

        // DELETE: api/ApiWithActions/5
        


    }
}