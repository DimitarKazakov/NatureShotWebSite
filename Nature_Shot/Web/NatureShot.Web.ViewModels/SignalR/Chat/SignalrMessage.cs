namespace NatureShot.Web.ViewModels.SignalR.Chat
{
    using System;

    public class SignalrMessage
    {
        public SignalrMessage()
        {
        }

        public string User { get; set; }

        public string Text { get; set; }

        public string TimePosted { get; set; }
    }
}
