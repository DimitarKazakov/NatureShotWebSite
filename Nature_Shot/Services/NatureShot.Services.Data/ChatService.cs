namespace NatureShot.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;
    using NatureShot.Web.ViewModels.SignalR.Chat;

    public class ChatService : IChatService
    {
        private readonly IDeletableEntityRepository<ChatGroup> chatRepository;
        private readonly IUserService userService;
        private readonly IDeletableEntityRepository<NatureShot.Data.Models.Message> messageRepository;

        public ChatService(IDeletableEntityRepository<ChatGroup> chatRepository,
                           IUserService userService,
                           IDeletableEntityRepository<NatureShot.Data.Models.Message> messageRepository)
        {
            this.chatRepository = chatRepository;
            this.userService = userService;
            this.messageRepository = messageRepository;
        }

        public string CheckGroupExists(string firstUsername, string secondUsername)
        {
            var chatName = this.chatRepository.AllAsNoTracking()
                                              .FirstOrDefault(x =>
                                                    x.Members.Select(x => x.User.UserName).Contains(firstUsername) &&
                                                    x.Members.Select(x => x.User.UserName).Contains(firstUsername));

            return chatName?.Name;
        }

        public async Task CreateGroup(string firstUsername, string secondUsername)
        {
            var group = new ChatGroup
            {
                Name = firstUsername + secondUsername,
            };

            await this.chatRepository.AddAsync(group);
            await this.chatRepository.SaveChangesAsync();
        }

        public async Task AddToGroup(string firstUsername, string secondUsername)
        {
            var firstUser = this.userService.GetUser(firstUsername);
            var secondUser = this.userService.GetUser(secondUsername);
            var group = this.chatRepository.All().FirstOrDefault(x => x.Name == firstUsername + secondUsername ||
                                                          x.Name == secondUsername + firstUsername);
            group.Members.Add(new GroupMembers
            {
                ChatGroupId = group.Id,
                User = firstUser,
            });

            group.Members.Add(new GroupMembers
            {
                ChatGroupId = group.Id,
                User = secondUser,
            });

            await this.chatRepository.SaveChangesAsync();
        }

        public async Task<ICollection<MessagesForChatViewModel>> GetMessagesForChat(string firstUsername, string secondUsername)
        {
            var messages = this.messageRepository
                                .All()
                                .Where(x => x.ChatGroup.Name == firstUsername + secondUsername ||
                                            x.ChatGroup.Name == secondUsername + firstUsername);
            foreach (var message in messages)
            {
                message.HasBeenRead = true;
            }

            await this.messageRepository.SaveChangesAsync();
            return messages.OrderBy(x => x.CreatedOn)
                                .Select(x => new MessagesForChatViewModel
                                {
                                    Message = x.Content,
                                    TimePosted = x.CreatedOn.ToString("dddd, dd MMMM yyyy"),
                                    Username = x.SendByUsername,
                                }).ToList();
        }

        public async Task<ICollection<MessagesForChatViewModel>> GetNewMessagesForChat(string firstUsername, string secondUsername)
        {
            var messages = this.messageRepository
                                .All()
                                .Where(x => (x.ChatGroup.Name == firstUsername + secondUsername ||
                                            x.ChatGroup.Name == secondUsername + firstUsername) && x.HasBeenRead == false && x.SendByUsername == secondUsername).ToList();
            foreach (var message in messages)
            {
                message.HasBeenRead = true;
            }

            await this.messageRepository.SaveChangesAsync();
            return messages.OrderBy(x => x.CreatedOn)
                                .Select(x => new MessagesForChatViewModel
                                {
                                    Message = x.Content,
                                    TimePosted = x.CreatedOn.ToString("dddd, dd MMMM yyyy"),
                                    Username = x.SendByUsername,
                                }).ToList();
        }

        public async Task<MessagesForChatViewModel> PostMessage(ChatMessageInput input)
        {
            var group = this.chatRepository.All().FirstOrDefault(x => x.Name == input.Receiver + input.Sender ||
                                                          x.Name == input.Sender + input.Receiver);
            group.Messages.Add(new NatureShot.Data.Models.Message
            {
                SendByUsername = input.Sender,
                ChatGroupId = group.Id,
                Content = input.Message,
            });

            await this.chatRepository.SaveChangesAsync();
            return new MessagesForChatViewModel
            {
                Message = input.Message,
                TimePosted = input.TimePosted.ToString("dddd, dd MMMM yyyy"),
                Username = input.Sender,
            };
        }
    }
}
