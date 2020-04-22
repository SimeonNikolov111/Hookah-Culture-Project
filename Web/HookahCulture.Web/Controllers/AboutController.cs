using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahCulture.Web.Controllers
{
    public class AboutController : Controller
    {
        [HttpGet]
        public IActionResult Contact()
        {
            return this.View();
        }
    }
}
