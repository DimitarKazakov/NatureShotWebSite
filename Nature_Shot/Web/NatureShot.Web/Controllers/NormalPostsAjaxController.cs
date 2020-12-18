namespace NatureShot.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Encodings.Web;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NatureShot.Services.Data;
    using NatureShot.Services.Data.NormalPosts;
    using NatureShot.Web.ViewModels.NormalPosts;
    using NatureShot.Services.Data.Contracts;
    using NatureShot.Services.Data.NormalPosts.Contracts;

    [Route("api/[controller]")]
    [ApiController]
    public class NormalPostsAjaxController : BaseController
    {
        private readonly HtmlEncoder encoder;
        private readonly INormalPostsNewest normalPostNewestService;
        private readonly INormalPostsOldest normalPostOldestService;
        private readonly INormalPostsMostLikes normalPostMostLikesService;
        private readonly INormalPostsLeastLikes normalPostLeastLikesService;
        private readonly INormalPostsMostDislikes normalPostMostDislikesService;
        private readonly INormalPostsLeastDislikes normalPostLeastDislikesService;

        public NormalPostsAjaxController(HtmlEncoder encoder,
                                     INormalPostsNewest normalPostNewestService,
                                     INormalPostsOldest normalPostOldestService,
                                     INormalPostsMostLikes normalPostMostLikesService,
                                     INormalPostsLeastLikes normalPostLeastLikesService,
                                     INormalPostsMostDislikes normalPostMostDislikesService,
                                     INormalPostsLeastDislikes normalPostLeastDislikesService)
        {
            this.encoder = encoder;
            this.normalPostNewestService = normalPostNewestService;
            this.normalPostOldestService = normalPostOldestService;
            this.normalPostMostLikesService = normalPostMostLikesService;
            this.normalPostLeastLikesService = normalPostLeastLikesService;
            this.normalPostMostDislikesService = normalPostMostDislikesService;
            this.normalPostLeastDislikesService = normalPostLeastDislikesService;
        }

        [Authorize]
        [HttpGet("{page}")]
        public ICollection<NormalPostViewModel> LoadMoreImages(int page, string order, string searchBy, string searchInput)
        {
            var postList = new List<NormalPostViewModel>();

            switch (order)
            {
                case "Date (Newest)":
                    switch (searchBy)
                    {
                        case "Name":
                            postList = this.normalPostNewestService.SearchByUsername(page, searchInput).ToList();
                            break;
                        case "Tag":
                            postList = this.normalPostNewestService.SearchByTags(page, searchInput).ToList();
                            break;
                        case "Caption":
                            postList = this.normalPostNewestService.SearchByCaption(page, searchInput).ToList();
                            break;
                        case "Liked":
                            postList = this.normalPostNewestService.SearchByLikedPosts(0, searchInput).ToList();
                            break;
                        case "Disliked":
                            postList = this.normalPostNewestService.SearchByDislikedPosts(0, searchInput).ToList();
                            break;
                        case "Commented":
                            postList = this.normalPostNewestService.SearchByCommentedPosts(0, searchInput).ToList();
                            break;
                        default:
                            postList = this.normalPostNewestService.GetNormalPostsNewest(page).ToList();
                            break;
                    }

                    break;
                case "Date (Oldest)":
                    switch (searchBy)
                    {
                        case "Name":
                            postList = this.normalPostOldestService.SearchByUsername(page, searchInput).ToList();
                            break;
                        case "Tag":
                            postList = this.normalPostOldestService.SearchByTags(page, searchInput).ToList();
                            break;
                        case "Caption":
                            postList = this.normalPostOldestService.SearchByCaption(page, searchInput).ToList();
                            break;
                        case "Liked":
                            postList = this.normalPostOldestService.SearchByLikedPosts(0, searchInput).ToList();
                            break;
                        case "Disliked":
                            postList = this.normalPostOldestService.SearchByDislikedPosts(0, searchInput).ToList();
                            break;
                        case "Commented":
                            postList = this.normalPostOldestService.SearchByCommentedPosts(0, searchInput).ToList();
                            break;
                        default:
                            postList = this.normalPostOldestService.GetNormalPostsOldest(page).ToList();
                            break;
                    }

                    break;
                case "Likes (Most)":
                    switch (searchBy)
                    {
                        case "Name":
                            postList = this.normalPostMostLikesService.SearchByUsername(page, searchInput).ToList();
                            break;
                        case "Tag":
                            postList = this.normalPostMostLikesService.SearchByTags(page, searchInput).ToList();
                            break;
                        case "Caption":
                            postList = this.normalPostMostLikesService.SearchByCaption(page, searchInput).ToList();
                            break;
                        case "Liked":
                            postList = this.normalPostMostLikesService.SearchByLikedPosts(0, searchInput).ToList();
                            break;
                        case "Disliked":
                            postList = this.normalPostMostLikesService.SearchByDislikedPosts(0, searchInput).ToList();
                            break;
                        case "Commented":
                            postList = this.normalPostMostLikesService.SearchByCommentedPosts(0, searchInput).ToList();
                            break;
                        default:
                            postList = this.normalPostMostLikesService.GetNormalPostsMostLikes(page).ToList();
                            break;
                    }

                    break;
                case "Likes (Least)":
                    switch (searchBy)
                    {
                        case "Name":
                            postList = this.normalPostLeastLikesService.SearchByUsername(page, searchInput).ToList();
                            break;
                        case "Tag":
                            postList = this.normalPostLeastLikesService.SearchByTags(page, searchInput).ToList();
                            break;
                        case "Caption":
                            postList = this.normalPostLeastLikesService.SearchByCaption(page, searchInput).ToList();
                            break;
                        case "Liked":
                            postList = this.normalPostLeastLikesService.SearchByLikedPosts(0, searchInput).ToList();
                            break;
                        case "Disliked":
                            postList = this.normalPostLeastLikesService.SearchByDislikedPosts(0, searchInput).ToList();
                            break;
                        case "Commented":
                            postList = this.normalPostLeastLikesService.SearchByCommentedPosts(0, searchInput).ToList();
                            break;
                        default:
                            postList = this.normalPostLeastLikesService.GetNormalPostsLeastLikes(page).ToList();
                            break;
                    }

                    break;
                case "Dislikes (Most)":
                    switch (searchBy)
                    {
                        case "Name":
                            postList = this.normalPostMostDislikesService.SearchByUsername(page, searchInput).ToList();
                            break;
                        case "Tag":
                            postList = this.normalPostMostDislikesService.SearchByTags(page, searchInput).ToList();
                            break;
                        case "Caption":
                            postList = this.normalPostMostDislikesService.SearchByCaption(page, searchInput).ToList();
                            break;
                        case "Liked":
                            postList = this.normalPostMostDislikesService.SearchByLikedPosts(0, searchInput).ToList();
                            break;
                        case "Disliked":
                            postList = this.normalPostMostDislikesService.SearchByDislikedPosts(0, searchInput).ToList();
                            break;
                        case "Commented":
                            postList = this.normalPostMostDislikesService.SearchByCommentedPosts(0, searchInput).ToList();
                            break;
                        default:
                            postList = this.normalPostMostDislikesService.GetNormalPostsMostDislikes(page).ToList();
                            break;
                    }

                    break;
                case "Dislikes (Least)":
                    switch (searchBy)
                    {
                        case "Name":
                            postList = this.normalPostLeastDislikesService.SearchByUsername(page, searchInput).ToList();
                            break;
                        case "Tag":
                            postList = this.normalPostLeastDislikesService.SearchByTags(page, searchInput).ToList();
                            break;
                        case "Caption":
                            postList = this.normalPostLeastDislikesService.SearchByCaption(page, searchInput).ToList();
                            break;
                        case "Liked":
                            postList = this.normalPostLeastDislikesService.SearchByLikedPosts(0, searchInput).ToList();
                            break;
                        case "Disliked":
                            postList = this.normalPostLeastDislikesService.SearchByDislikedPosts(0, searchInput).ToList();
                            break;
                        case "Commented":
                            postList = this.normalPostLeastDislikesService.SearchByCommentedPosts(0, searchInput).ToList();
                            break;
                        default:
                            postList = this.normalPostLeastDislikesService.GetNormalPostsLeastDislikes(page).ToList();
                            break;
                    }

                    break;
                default:
                    break;
            }

            foreach (var post in postList)
            {
                if (this.User.Identity.Name == post.Username)
                {
                    post.UsersOwnPhoto = true;
                }

                post.Caption = this.encoder.Encode(post.Caption);
            }

            return postList;
        }
    }
}
