namespace NatureShot.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NatureShot.Services.Data;
    using NatureShot.Web.ViewModels.SignalR.Chat;

    [Route("api/[controller]")]
    [ApiController]
    public class ChatAjaxController : BaseController
    {
        private readonly IChatService chatService;
        private readonly HtmlEncoder encoder;

        public ChatAjaxController(IChatService chatService, HtmlEncoder encoder)
        {
            this.chatService = chatService;
            this.encoder = encoder;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostMessage([FromBody] ChatMessageInput model)
        {
            model.Sender = this.User.Identity.Name;
            model.TimePosted = DateTime.UtcNow;
            var result = await this.chatService.PostMessage(model);
            return this.Json(result);
        }

        [Authorize]
        [HttpGet]
        public async Task<ICollection<MessagesForChatViewModel>> GetNewMessages(string username)
        {
            var result = await this.chatService.GetNewMessagesForChat(this.User.Identity.Name, username);
            foreach (var message in result)
            {
                this.encoder.Encode(message.Message);
            }

            return result;
        }
    }
}
