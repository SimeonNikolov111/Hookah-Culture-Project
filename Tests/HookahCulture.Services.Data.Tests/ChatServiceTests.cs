using HookahCulture.Data.Models;
using HookahCulture.Services.Data.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace HookahCulture.Services.Data.Tests
{
    public class ChatServiceTests
    {
        [Fact]
        public void TestingIfChatMessagesCountIsReturnedCorrectly()
        {
            var context = InMemoryDbContextInitializer.InitializeContext();
            ChatService chatService = new ChatService(context);

            context.ChatMessages.Add(new ChatMessage { Message = "Hello" });
            context.SaveChanges();

            var messages = chatService.GetAllMessages();

            int expectedCount = 1;

            Assert.Equal(expectedCount, messages.Count());
        }
    }
}
