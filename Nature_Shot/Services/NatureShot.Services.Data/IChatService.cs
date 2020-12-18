namespace NatureShot.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using NatureShot.Web.ViewModels.SignalR.Chat;

    public interface IChatService
    {
        string CheckGroupExists(string firstUsername, string secondUsername);

        Task CreateGroup(string firstUsername, string secondUsername);

        Task AddToGroup(string firstUsername, string secondUsername);

        Task<ICollection<MessagesForChatViewModel>> GetNewMessagesForChat(string firstUsername, string secondUsername);

        Task<ICollection<MessagesForChatViewModel>> GetMessagesForChat(string firstUsername, string secondUsername);

        Task<MessagesForChatViewModel> PostMessage(ChatMessageInput input);
    }
}
