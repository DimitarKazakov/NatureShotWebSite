namespace NatureShot.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using NatureShot.Data;
    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;
    using NatureShot.Web.ViewModels;
    using NatureShot.Services.Data.Contracts;

    public class ReactionService : IReactionService
    {
        private readonly IRepository<PostReact> reactRepository;

        public ReactionService(IRepository<PostReact> reactRepository)
        {
            this.reactRepository = reactRepository;
        }

        public async Task ChangeReactionAsync(int postId, string userId, string type)
        {
            var react = this.reactRepository.All().FirstOrDefault(x => x.PostId == postId && x.UserId == userId);
            if (type == "Like")
            {
                react.IsLiked = true;
            }
            else
            {
                react.IsLiked = false;
            }

            await this.reactRepository.SaveChangesAsync();
        }

        public async Task CreateReact(int postId, string userId, bool isLiked)
        {
            await this.reactRepository.AddAsync(new PostReact
            {
                IsLiked = isLiked,
                PostId = postId,
                UserId = userId,
            });

            await this.reactRepository.SaveChangesAsync();
        }

        public PostReact GetPostReact(int postId, string userId)
        {
            return this.reactRepository.All().FirstOrDefault(x => x.PostId == postId && x.UserId == userId);
        }

        public IEnumerable<PeopleReactedViewModel> GetUsersWhoDislikedPost(int postId)
        {
            return this.reactRepository.AllAsNoTracking()
                                       .Where(x => x.PostId == postId && x.IsLiked == false)
                                       .Select(x => new PeopleReactedViewModel
                                       {
                                           User = x.User.UserName,
                                       })
                                       .ToList();
        }

        public IEnumerable<PeopleReactedViewModel> GetUsersWhoLikedPost(int postId)
        {
            return this.reactRepository.AllAsNoTracking()
                                       .Where(x => x.PostId == postId && x.IsLiked == true)
                                       .Select(x => new PeopleReactedViewModel
                                       {
                                           User = x.User.UserName,
                                       })
                                       .ToList();
        }
    }
}
