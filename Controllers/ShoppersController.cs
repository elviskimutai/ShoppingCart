using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingCartApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Shoppers")]
    [Authorize]
    public class ShoppersController : Controller
    {        
    }
}