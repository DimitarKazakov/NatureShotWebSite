﻿namespace NatureShot.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Encodings.Web;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NatureShot.Services.Data;
    using NatureShot.Web.ViewModels;

    [Route("api/[controller]")]
    [ApiController]
    public class ReactionPostsAjax : BaseController
    {
        private readonly HtmlEncoder encoder;
        private readonly IReactionService reactionService;
        private readonly ICommentService commentService;

        public ReactionPostsAjax(HtmlEncoder encoder,
                                 IReactionService reactionService,
                                 ICommentService commentService)
        {
            this.encoder = encoder;
            this.reactionService = reactionService;
            this.commentService = commentService;
        }

        [Authorize]
        [HttpGet]
        public ICollection<PeopleReactedViewModel> LoadMoreImages(int postId, string reaction)
        {
            var peopleList = new List<PeopleReactedViewModel>();

            switch (reaction)
            {
                case "likeModalTrigger":
                    peopleList = this.reactionService.GetUsersWhoLikedPost(postId).ToList();
                    break;
                case "dislikeModalTrigger":
                    peopleList = this.reactionService.GetUsersWhoDislikedPost(postId).ToList();
                    break;
                case "commentModalTrigger":
                    peopleList = this.commentService.GetCommentsForPost(postId).ToList();
                    break;
                default:
                    break;
            }

            if (reaction == "commentModalTrigger")
            {
                foreach (var people in peopleList)
                {
                    people.Content = this.encoder.Encode(people.Content);
                }
            }

            return peopleList;
        }
    }
}
