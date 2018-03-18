using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartApi.Services;

namespace ShoppingCartApi.Controllers
{
    [Produces("application/json")]
    [Route("api/CheckoutOption")]
    public class CheckoutOptionController : Controller
    {
        private ShipmentMethodManager _shipmentMethodManager;
        public CheckoutOptionController()
        {

        }
    }
}