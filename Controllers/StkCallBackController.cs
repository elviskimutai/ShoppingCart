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
    [Route("api/StkCallBack")]
    public class StkCallBackController : Controller
    {
        public StkCallBackController()
        {

        }
        [HttpPost]
        public IActionResult Post([FromBody]StkCallBackViewModel stkCallBackViewModel) {


            return new OkResult();
        }
        [HttpGet]
        public IActionResult Get()
        {


            return new OkObjectResult("Dummy Values");
        }
    }
}