namespace NatureShot.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using NatureShot.Web.ViewModels;

    public interface ICommentService
    {
        Task AddComment(string userId, int postId, string comment);

        IEnumerable<PeopleReactedViewModel> GetCommentsForPost(int postId);
    }
}
