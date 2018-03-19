using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartApi.Models;
using ShoppingCartApi.Services;

namespace ShoppingCartApi.Controllers
{
    [Produces("application/json")]
    [Route("api/CheckoutOption")]    
    public class CheckoutOptionController : Controller
    {
        private ShipmentMethodManager _shipmentMethodManager;
        private PaymentMethodsManager _paymentMethodsManager; 
        public CheckoutOptionController(ShoppingCartDbContext dbContext)
        {
            this._paymentMethodsManager = new PaymentMethodsManager(dbContext);
            this._shipmentMethodManager = new ShipmentMethodManager(dbContext);
        }
        [HttpGet]
        public IActionResult Get() {
            var shipmentmethods = this._shipmentMethodManager.GetAll();
            var paymentmethods = this._paymentMethodsManager.GetAll();
            return new OkObjectResult(new {paymentMethods=paymentmethods, shipmentMethods=shipmentmethods });
        }

    }
}