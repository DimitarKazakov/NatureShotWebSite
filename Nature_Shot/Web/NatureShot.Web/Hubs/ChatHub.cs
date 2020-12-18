namespace NatureShot.Web.Hubs
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.SignalR;
    using NatureShot.Services.Data;
    using NatureShot.Web.ViewModels.SignalR.Chat;

    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IChatService chatService;

        public ChatHub(IChatService chatService)
        {
            this.chatService = chatService;
        }

        public async Task Send(string message, string groupName = "chat1")
        {
            await this.Groups.AddToGroupAsync(this.Context.ConnectionId, groupName);
            await this.Clients.Group(groupName).SendAsync(
                "NewMessage",
                new Message { User = this.Context.User.Identity.Name, Text = message, });
        }

        public async Task CreateGroup(string firstUsername, string secondUsername)
        {

        }
    }
}
