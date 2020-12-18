using System;
namespace NatureShot.Web.ViewModels.SignalR.Chat
{
    public class MessagesForChatViewModel
    {
        public MessagesForChatViewModel()
        {
        }

        public string Username { get; set; }

        public string Message { get; set; }

        public string TimePosted { get; set; }
    }
}
