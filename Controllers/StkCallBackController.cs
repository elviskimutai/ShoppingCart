using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartApi.Models;

namespace ShoppingCartApi.Controllers
{
    [Produces("application/json")]
    [Route("api/StkCallBack")]
    [Authorize]
    public class StkCallBackController : Controller
    {
        public StkCallBackController()
        {

        }
        [HttpPost]
        public IActionResult Post([FromBody]StkCallBackViewModel stkCallBackViewModel) {
           var userId= User.FindFirst("sub")?.Value;

            return new OkResult();
        }
        [HttpGet]
        public IActionResult Get()
        {
            var user = HttpContext.User;
            var ID = user.Identity.Name;
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return new OkObjectResult("Dummy Values");
        }
    }
}