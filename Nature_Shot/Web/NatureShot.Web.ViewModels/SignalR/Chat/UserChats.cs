namespace NatureShot.Web.ViewModels.SignalR.Chat
{
    public class UserChats
    {
        public UserChats()
        {
        }

        public string Username { get; set; }

        public bool NewMessages { get; set; }

        public string TimePosted { get; set; }

        public string Message { get; set; }
    }
}
