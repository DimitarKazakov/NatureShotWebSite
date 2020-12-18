using System;
namespace NatureShot.Web.ViewModels.SignalR.Chat
{
    public class ChatMessageInput
    {
        public ChatMessageInput()
        {
        }

        public string Message { get; set; }

        public string Receiver { get; set; }

        public string Sender { get; set; }

        public DateTime TimePosted { get; set; }
    }
}
