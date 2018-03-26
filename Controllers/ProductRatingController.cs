using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartApi.Models;

namespace ShoppingCartApi.Controllers
{
    [Produces("application/json")]
    [Route("api/ProductRating")]
    [Authorize]
    public class ProductRatingController : Controller
    {
        private readonly ShoppingCartDbContext _dbContext;
        public ProductRatingController(ShoppingCartDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductRating productRating)
        {
            try
            {
                this._dbContext.ProductRatings.Add(productRating);
                return new OkResult();
            }
            catch (Exception)
            {

                throw;
            }
           

        }
    }
}