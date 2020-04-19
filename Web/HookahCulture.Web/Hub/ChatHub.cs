using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HookahCulture.Web.Hub
{
    using System.Threading.Tasks;
    using HookahCulture.Data.Models.Chat;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.SignalR;

    [Authorize]
    public class ChatHub : Hub
    {
        public async Task Send(string name, string message, string profilePicturePath)
        {
            await this.Clients.All.SendAsync(
                "NewMessage",
                new Message { Name = name, Text = message, ProfilePicturePath = profilePicturePath });
        }
    }
}
