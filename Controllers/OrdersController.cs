using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ShoppingCartApi.Models;
using ShoppingCartApi.Services;

namespace ShoppingCartApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Orders")]  
    [Authorize]
    public class OrdersController : Controller
    {

        private IRepository<Order> _ordersManager;
        
        public OrdersController(IRepository<Order> ordersManager) 
        {
            _ordersManager = ordersManager;
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
        [HttpGet("customer/{id}", Name = "GetCustomerOrders")]
        public IActionResult GetCustomerOrders([FromRoute]String id) {
            var result = ((OrdersManager)this._ordersManager).getCustomerOrders(id);
            return new OkObjectResult( result);
        }
        [HttpPost]
        public IActionResult Post([FromBody]CustomerOrder customerOrderModel) {
            var result =((OrdersManager) this._ordersManager).CreateNewOrder(customerOrderModel, User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            if (result) {
                return new OkObjectResult("your order has been recived");
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