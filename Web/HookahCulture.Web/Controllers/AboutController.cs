using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public IActionResult Contact()
        {
            return this.View();
        }
    }
}
