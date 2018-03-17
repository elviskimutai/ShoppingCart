using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartApi.Models;

namespace ShoppingCartApi.Controllers
{
    [Produces("application/json")]
    [Route("api/ShipmentMethod")]
    public class ShipmentMethodsController : Controller
    {
        // GET: api/ShipmentMethod
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ShipmentMethod/5
        [HttpGet("{id}", Name = "GetShipmentMethod")]
        public IActionResult Get(int id)
        {
            return null;
        }
        
        // POST: api/ShipmentMethod
        [HttpPost]
        public IActionResult Post([FromBody]ShipmentMethod value)
        {
            return null;
        }
        
        // PUT: api/ShipmentMethod/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ShipmentMethod value)
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
