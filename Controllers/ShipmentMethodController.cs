using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartApi.Models;
using ShoppingCartApi.Services;

namespace ShoppingCartApi.Controllers
{
    [Produces("application/json")]
    [Route("api/ShipmentMethod")]
    public class ShipmentMethodsController : Controller
    {        
        private ShipmentMethodManager _shipmentMethodManager;
        public ShipmentMethodsController(ShoppingCartDbContext _dbContext)
        {
            this._shipmentMethodManager = new ShipmentMethodManager(_dbContext);
        }
        // GET: api/ShipmentMethod
        [HttpGet]
        [ResponseType(typeof(ShipmentMethod))]
        public IActionResult Get()
        {
          var shipmentMethods=  this._shipmentMethodManager.GetAll();
          return new OkObjectResult(shipmentMethods);
        }

        // GET: api/ShipmentMethod/5
        [HttpGet("{id}", Name = "GetShipmentMethod")]
        public IActionResult Get(int id)
        {
            return null;
        }
        
        // POST: api/ShipmentMethod
        [HttpPost]
        public IActionResult Post([FromBody]ShipmentMethod shipmentMethod)
        {
            if (ModelState.IsValid)
            {
                var result = this._shipmentMethodManager.Add(shipmentMethod);
                if (result)
                {
                    return StatusCode(201);
                }
                return StatusCode(500, "Object could not be created");
            }
            return BadRequest(this.ModelState);

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
