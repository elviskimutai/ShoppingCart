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
    [Route("api/Manufacturer")]    
    public class ManufacturerController : Controller
    {
        private IRepository<Manufacturer> _manufacturersManager;
        public ManufacturerController(IRepository<Manufacturer> _manufacturersManager)
        {

        }
    }
}