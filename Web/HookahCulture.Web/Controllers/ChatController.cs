namespace HookahCulture.Web.Controllers
{
    using HookahCulture.Data.Models;
    using HookahCulture.Services.Data;
    using HookahCulture.Web.ViewModels.Chat;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ChatController : Controller
    {
        private readonly IChatService chatService;

        public ChatController(IChatService chatService)
        {
            this.chatService = chatService;
        }

        [Authorize]
        public IActionResult Chat()
        {
            var messages = this.chatService.GetAllMessages();

            var viewModel = new ChatViewModel()
            {
                ChatMessages = messages,
            };

            return this.View(viewModel);
        }
    }
}
