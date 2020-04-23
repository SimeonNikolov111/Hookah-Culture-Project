using HookahCulture.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HookahCulture.Web.ViewModels.Chat
{
    public class ChatViewModel
    {
        public ICollection<ChatMessage> ChatMessages { get; set; }
    }
}
