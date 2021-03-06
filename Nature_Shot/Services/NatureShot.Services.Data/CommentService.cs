﻿namespace NatureShot.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;
    using NatureShot.Web.ViewModels;
    using NatureShot.Services.Data.Contracts;

    public class CommentService : ICommentService
    {
        private readonly IDeletableEntityRepository<Comment> commentRepository;

        public CommentService(IDeletableEntityRepository<Comment> commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public async Task AddComment(string userId, int postId, string comment)
        {
            var commentData = new Comment
            {
                Content = comment,
                PostId = postId,
                UserPostedId = userId,
            };

            await this.commentRepository.AddAsync(commentData);
            await this.commentRepository.SaveChangesAsync();
        }

        public IEnumerable<PeopleReactedViewModel> GetCommentsForPost(int postId)
        {
            var comments = this.commentRepository.AllAsNoTracking()
                                         .Where(x => x.PostId == postId)
                                         .Select(x => new PeopleReactedViewModel
                                         {
                                             User = x.UserPosted.UserName,
                                             Content = x.Content,
                                         })
                                         .ToList();

            return comments;
        }
    }
}
