namespace NatureShot.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NatureShot.Services.Data.Contracts;

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

        [Authorize]
        public IActionResult MyChats()
        {
            var chats = this.chatService.GetUserChats(this.User.Identity.Name);
            return this.View(chats);
        }

        [Authorize]
        public IActionResult SearchByUsername(string searchInput)
        {
            var chats = this.chatService.SearchByUsername(this.User.Identity.Name, searchInput);
            return this.View(nameof(this.MyChats), chats);
        }

        [Authorize]
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
