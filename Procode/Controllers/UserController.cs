using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procode.Controllers
{
    [Route("{Username}/[action]")]
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Settings()
        {
            return View();
        }
    }
}
