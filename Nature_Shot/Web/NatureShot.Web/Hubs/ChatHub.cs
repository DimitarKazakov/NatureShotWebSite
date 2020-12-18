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
        public async Task Send(string message)
        {
            await this.Clients.All.SendAsync(
                "NewMessage",
                new SignalrMessage { User = this.Context.User.Identity.Name, Text = message, TimePosted = DateTime.Now.ToString("h:mm tt") });
        }
    }
}
