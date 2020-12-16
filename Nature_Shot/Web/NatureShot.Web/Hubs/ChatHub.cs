namespace NatureShot.Web.Hubs
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.SignalR;
    using NatureShot.Web.ViewModels.SignalR.Chat;

    [Authorize]
    public class ChatHub : Hub
    {
        public ChatHub()
        {
        }

        public async Task Send(string message)
        {
            await this.Clients.All.SendAsync(
                "NewMessage",
                new Message { User = this.Context.User.Identity.Name, Text = message, });
        }
    }
}
