using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartApi.Models;
using ShoppingCartApi.Services;

namespace ShoppingCartApi.Controllers
{
    [Produces("application/json")]
    [Route("api/CheckoutOption")]
    [Authorize]
    public class CheckoutOptionController : Controller
    {
        private IRepository<PaymentMethod> _paymentMethodsManager;
        private IRepository<ShipmentMethod> _shipmentMethodManager;
        public CheckoutOptionController(IRepository<PaymentMethod> paymentMethodsManager, 
            IRepository<ShipmentMethod> shipmentMethodManager)
        {
            this._paymentMethodsManager = paymentMethodsManager;
            this._shipmentMethodManager = shipmentMethodManager;
        }
        [HttpGet]
        public IActionResult Get() {
            var shipmentmethods = this._shipmentMethodManager.GetAll();
            var paymentmethods = this._paymentMethodsManager.GetAll();
            return new OkObjectResult(new {paymentMethods=paymentmethods, shipmentMethods=shipmentmethods });
        }

    }
}