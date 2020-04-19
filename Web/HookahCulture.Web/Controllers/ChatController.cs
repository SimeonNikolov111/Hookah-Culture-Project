namespace HookahCulture.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ChatController : Controller
    {
        [Authorize]
        public IActionResult Chat()
        {
            return this.View();
        }
    }
}
