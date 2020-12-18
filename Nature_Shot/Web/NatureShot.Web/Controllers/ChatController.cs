namespace NatureShot.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NatureShot.Services.Data;
    using NatureShot.Web.ViewModels.SignalR.Chat;

    public class ChatController : Controller
    {
        private readonly IChatService chatService;

        public ChatController(IChatService chatService)
        {
            this.chatService = chatService;
        }

        [Authorize]
        public IActionResult Messaging()
        {
            return this.View();
        }

        public IActionResult MyChats()
        {
            var chats = new List<UserChats>();
            return this.View(chats);
        }

        public async Task<IActionResult> OpenChat(string username)
        {
            var firstUsername = this.User.Identity.Name;
            var groupName = this.chatService.CheckGroupExists(firstUsername, username);
            if (groupName == null)
            {
                await this.chatService.CreateGroup(firstUsername, username);
                await this.chatService.AddToGroup(firstUsername, username);
            }

            var viewModel = await this.chatService.GetMessagesForChat(firstUsername, username);

            return this.View(viewModel);
        }
    }
}
