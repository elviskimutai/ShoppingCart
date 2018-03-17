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
    [Route("api/products")]
    public class ProductsController : Controller
    {
        private ProductsManager _productsManager;
        private ShoppingCartDbContext _shoppingCartDbContext;

        public ProductsController(ShoppingCartDbContext shoppingCartDbContext)
        {
            _shoppingCartDbContext = shoppingCartDbContext;
            _productsManager = new ProductsManager(_shoppingCartDbContext);//  productsManager;
        }

        [Route("all")]
        [HttpGet]        
        public IActionResult GetAllProduct() {
            var products = this._productsManager.GetAll();
            return new OkObjectResult(products);
        }
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetProductById(Guid id) {
            var product = this._productsManager.GetById(id);
            if (product != null) {
                return new OkObjectResult(product);
            };
            return NotFound();
        }
        [HttpPost]
        public IActionResult CreateProduct([FromBody]Product product) {
            try
            {
                var result = this._productsManager.Add(product);
               
                    return new OkResult();
                
            } catch (Exception e) {
                return  StatusCode(500,e.InnerException);
                    }
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteProduct(Guid id) {
           var result= this._productsManager.Remove(id);
            if (result)
            {
                return new NoContentResult();
            }
            else return NotFound();
        }

    }
}