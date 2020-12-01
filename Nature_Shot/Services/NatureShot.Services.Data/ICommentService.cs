using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NatureShot.Web.ViewModels;

namespace NatureShot.Services.Data
{
    public interface ICommentService
    {
        Task AddComment(string userId, int postId, string comment);

        IEnumerable<PeopleReactedViewModel> GetCommentsForPost(int postId);
    }
}
