namespace NatureShot.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using NatureShot.Data.Models;
    using NatureShot.Web.ViewModels;

    public interface IReactionService
    {
        PostReact GetPostReact(int postId, string userId);

        Task ChangeReactionAsync(int postId, string userId, string type);

        Task CreateReact(int postId, string userId, bool isLiked);

        IEnumerable<PeopleReactedViewModel> GetUsersWhoLikedPost(int postId);

        IEnumerable<PeopleReactedViewModel> GetUsersWhoDislikedPost(int postId);
    }
}
