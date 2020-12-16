namespace NatureShot.Web.Controllers
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NatureShot.Web.ViewModels.SignalR.Chat;

    public class ChatController : Controller
    {
        public ChatController()
        {
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
    }
}
