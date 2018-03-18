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
    [Route("api/PaymentMethods")]
    public class PaymentMethodsController : Controller
    {
        // GET: api/PaymentMethods
        private PaymentMethodsManager _paymentMethodsManager;        
        public PaymentMethodsController(ShoppingCartDbContext shoppingCartDbContext)
        {
            _paymentMethodsManager = new PaymentMethodsManager(shoppingCartDbContext);
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PaymentMethod>), 200)]
        public IActionResult  Get()
        {
          var paymentMethods= this._paymentMethodsManager.GetAll();
            return new OkObjectResult(paymentMethods);
        }

        // GET: api/PaymentMethods/5
        [HttpGet("{id}", Name = "GetPaymentMethod")]
        public IActionResult Get(int id)
        {
            return null;
        }
        
        // POST: api/PaymentMethods
        [HttpPost]
        public IActionResult Post([FromBody]PaymentMethod paymentMethod)
        {
          var result=  this._paymentMethodsManager.Add(paymentMethod);

            if (result) {
                return new  StatusCodeResult(201);
            }
            else return new StatusCodeResult(500);
        }
        
        // PUT: api/PaymentMethods/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return null;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return null;
        }
    }
}
