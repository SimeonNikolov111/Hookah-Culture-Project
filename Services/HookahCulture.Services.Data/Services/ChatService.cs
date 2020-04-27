using HookahCulture.Data;
using HookahCulture.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HookahCulture.Services.Data
{
    public class ChatService : IChatService
    {
        private readonly ApplicationDbContext dbContext;

        public ChatService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ICollection<ChatMessage> GetAllMessages()
        {
            var messages = this.dbContext.ChatMessages.ToList();

            return messages;
        }
    }
}
