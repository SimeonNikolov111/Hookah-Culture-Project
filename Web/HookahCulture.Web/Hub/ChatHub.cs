using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HookahCulture.Web.Hub
{
    using System.Threading.Tasks;
    using HookahCulture.Data;
    using HookahCulture.Data.Models;
    using HookahCulture.Data.Models.Chat;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.SignalR;

    [Authorize]
    public class ChatHub : Hub
    {
        private readonly ApplicationDbContext dbContext;

        public ChatHub(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Send(string name, string message, string profilePicturePath, string createdOn)
        {
            var chatMessage = new ChatMessage()
            {
                FullName = name,
                Message = message,
                ProfilePicturePath = profilePicturePath,
                CreatedOn = createdOn,
            };

            this.dbContext.ChatMessages.Add(chatMessage);
            this.dbContext.SaveChanges();

            await this.Clients.All.SendAsync(
                "NewMessage",
                new Message { Name = name, Text = message, ProfilePicturePath = profilePicturePath });
        }
    }
}
