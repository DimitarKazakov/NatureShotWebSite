﻿namespace NatureShot.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;
    using System.Web.Http.Cors;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using NatureShot.Data.Models;
    using NatureShot.Services.Data;
    using NatureShot.Services.Data.PhotoPosts;
    using NatureShot.Web.ViewModels;
    using NatureShot.Web.ViewModels.Images;
    using NatureShot.Services.Data.Contracts;
    using NatureShot.Services.Data.PhotoPosts.Contracts;

    [Route("api/[controller]")]
    [ApiController]
    public class ImagePostsAjaxController : BaseController
    {
        private readonly HtmlEncoder encoder;
        private readonly IPostsService postsService;
        private readonly IPhotoPostsNewest photoNewestService;
        private readonly IPhotoPostsOldest photoOldestService;
        private readonly IPhotoPostsLeastLikes photoLeastLikesService;
        private readonly IPhotoPostsMostLikes photoMostLikesService;
        private readonly IPhotoPostsMostDislikes photoMostDislikesService;
        private readonly IPhotoPostsLeastDislikes photoLeastDislikesService;
        private readonly ICommentService commentService;
        private readonly UserManager<ApplicationUser> userManager;

        public ImagePostsAjaxController(IPostsService postsService, HtmlEncoder encoder,
                                        IPhotoPostsNewest photoNewestService,
                                        IPhotoPostsOldest photoOldestService,
                                        IPhotoPostsLeastLikes photoLeastLikesService,
                                        IPhotoPostsMostLikes photoMostLikesService,
                                        IPhotoPostsMostDislikes photoMostDislikesService,
                                        IPhotoPostsLeastDislikes photoLeastDislikesService,
                                        ICommentService commentService,
                                        UserManager<ApplicationUser> userManager)
        {
            this.postsService = postsService;
            this.encoder = encoder;
            this.photoNewestService = photoNewestService;
            this.photoOldestService = photoOldestService;
            this.photoLeastLikesService = photoLeastLikesService;
            this.photoMostLikesService = photoMostLikesService;
            this.photoMostDislikesService = photoMostDislikesService;
            this.photoLeastDislikesService = photoLeastDislikesService;
            this.commentService = commentService;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> LikeDislike([FromBody] LikeDislikeModel model)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            if (model.Type == "Like")
            {
                await this.postsService.LikeAsync(int.Parse(model.Id), user.Id);
                return this.Json(true);
            }
            else
            {
                await this.postsService.DislikeAsync(int.Parse(model.Id), user.Id);
                return this.Json(false);
            }

            return this.Ok();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Comment([FromBody] CommentInputModel model)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            await this.commentService.AddComment(user.Id, int.Parse(model.Id), model.Comment);
            return this.Ok();
        }

        [Authorize]
        [HttpGet("{page}")]
        public ICollection<ImagePostViewModel> LoadMoreImages(int page, string order, string searchBy, string searchInput)
        {
            var imageList = new List<ImagePostViewModel>();

            switch (order)
            {
                case "Date (Newest)":
                    switch (searchBy)
                    {
                        case "Name":
                            imageList = this.photoNewestService.SearchByUsername(page, searchInput).ToList();
                            break;
                        case "Tag":
                            imageList = this.photoNewestService.SearchByTags(page, searchInput).ToList();
                            break;
                        case "Location":
                            imageList = this.photoNewestService.SearchByLocation(page, searchInput).ToList();
                            break;
                        case "Camera":
                            imageList = this.photoNewestService.SearchByCamera(page, searchInput).ToList();
                            break;
                        case "Caption":
                            imageList = this.photoNewestService.SearchByCaption(page, searchInput).ToList();
                            break;
                        case "Liked":
                            imageList = this.photoNewestService.SearchByLikedPosts(page, searchInput).ToList();
                            break;
                        case "Disliked":
                            imageList = this.photoNewestService.SearchByDislikedPosts(page, searchInput).ToList();
                            break;
                        case "Commented":
                            imageList = this.photoNewestService.SearchByCommentedPosts(page, searchInput).ToList();
                            break;
                        default:
                            imageList = this.photoNewestService.GetImagePostsNewest(page).ToList();
                            break;
                    }

                    break;
                case "Date (Oldest)":
                    switch (searchBy)
                    {
                        case "Name":
                            imageList = this.photoOldestService.SearchByUsername(page, searchInput).ToList();
                            break;
                        case "Tag":
                            imageList = this.photoOldestService.SearchByTags(page, searchInput).ToList();
                            break;
                        case "Location":
                            imageList = this.photoOldestService.SearchByLocation(page, searchInput).ToList();
                            break;
                        case "Camera":
                            imageList = this.photoOldestService.SearchByCamera(page, searchInput).ToList();
                            break;
                        case "Caption":
                            imageList = this.photoOldestService.SearchByCaption(page, searchInput).ToList();
                            break;
                        case "Liked":
                            imageList = this.photoOldestService.SearchByLikedPosts(page, searchInput).ToList();
                            break;
                        case "Disliked":
                            imageList = this.photoOldestService.SearchByDislikedPosts(page, searchInput).ToList();
                            break;
                        case "Commented":
                            imageList = this.photoOldestService.SearchByCommentedPosts(page, searchInput).ToList();
                            break;
                        default:
                            imageList = this.photoOldestService.GetImagePostsOldest(page).ToList();
                            break;
                    }

                    break;
                case "Likes (Most)":
                    switch (searchBy)
                    {
                        case "Name":
                            imageList = this.photoMostLikesService.SearchByUsername(page, searchInput).ToList();
                            break;
                        case "Tag":
                            imageList = this.photoMostLikesService.SearchByTags(page, searchInput).ToList();
                            break;
                        case "Location":
                            imageList = this.photoMostLikesService.SearchByLocation(page, searchInput).ToList();
                            break;
                        case "Camera":
                            imageList = this.photoMostLikesService.SearchByCamera(page, searchInput).ToList();
                            break;
                        case "Caption":
                            imageList = this.photoMostLikesService.SearchByCaption(page, searchInput).ToList();
                            break;
                        case "Liked":
                            imageList = this.photoMostLikesService.SearchByLikedPosts(page, searchInput).ToList();
                            break;
                        case "Disliked":
                            imageList = this.photoMostLikesService.SearchByDislikedPosts(page, searchInput).ToList();
                            break;
                        case "Commented":
                            imageList = this.photoMostLikesService.SearchByCommentedPosts(page, searchInput).ToList();
                            break;
                        default:
                            imageList = this.photoMostLikesService.GetImagePostsMostLikes(page).ToList();
                            break;
                    }

                    break;
                case "Likes (Least)":
                    switch (searchBy)
                    {
                        case "Name":
                            imageList = this.photoLeastLikesService.SearchByUsername(page, searchInput).ToList();
                            break;
                        case "Tag":
                            imageList = this.photoLeastLikesService.SearchByTags(page, searchInput).ToList();
                            break;
                        case "Location":
                            imageList = this.photoLeastLikesService.SearchByLocation(page, searchInput).ToList();
                            break;
                        case "Camera":
                            imageList = this.photoLeastLikesService.SearchByCamera(page, searchInput).ToList();
                            break;
                        case "Caption":
                            imageList = this.photoLeastLikesService.SearchByCaption(page, searchInput).ToList();
                            break;
                        case "Liked":
                            imageList = this.photoLeastLikesService.SearchByLikedPosts(page, searchInput).ToList();
                            break;
                        case "Disliked":
                            imageList = this.photoLeastLikesService.SearchByDislikedPosts(page, searchInput).ToList();
                            break;
                        case "Commented":
                            imageList = this.photoLeastLikesService.SearchByCommentedPosts(page, searchInput).ToList();
                            break;
                        default:
                            imageList = this.photoLeastLikesService.GetImagePostsLeastLikes(page).ToList();
                            break;
                    }

                    break;
                case "Dislikes (Most)":
                    switch (searchBy)
                    {
                        case "Name":
                            imageList = this.photoMostDislikesService.SearchByUsername(page, searchInput).ToList();
                            break;
                        case "Tag":
                            imageList = this.photoMostDislikesService.SearchByTags(page, searchInput).ToList();
                            break;
                        case "Location":
                            imageList = this.photoMostDislikesService.SearchByLocation(page, searchInput).ToList();
                            break;
                        case "Camera":
                            imageList = this.photoMostDislikesService.SearchByCamera(page, searchInput).ToList();
                            break;
                        case "Caption":
                            imageList = this.photoMostDislikesService.SearchByCaption(page, searchInput).ToList();
                            break;
                        case "Liked":
                            imageList = this.photoMostDislikesService.SearchByLikedPosts(page, searchInput).ToList();
                            break;
                        case "Disliked":
                            imageList = this.photoMostDislikesService.SearchByDislikedPosts(page, searchInput).ToList();
                            break;
                        case "Commented":
                            imageList = this.photoMostDislikesService.SearchByCommentedPosts(page, searchInput).ToList();
                            break;
                        default:
                            imageList = this.photoMostDislikesService.GetImagePostsMostDislikes(page).ToList();
                            break;
                    }

                    break;
                case "Dislikes (Least)":
                    switch (searchBy)
                    {
                        case "Name":
                            imageList = this.photoLeastDislikesService.SearchByUsername(page, searchInput).ToList();
                            break;
                        case "Tag":
                            imageList = this.photoLeastDislikesService.SearchByTags(page, searchInput).ToList();
                            break;
                        case "Location":
                            imageList = this.photoLeastDislikesService.SearchByLocation(page, searchInput).ToList();
                            break;
                        case "Camera":
                            imageList = this.photoLeastDislikesService.SearchByCamera(page, searchInput).ToList();
                            break;
                        case "Caption":
                            imageList = this.photoLeastDislikesService.SearchByCaption(page, searchInput).ToList();
                            break;
                        case "Liked":
                            imageList = this.photoLeastDislikesService.SearchByLikedPosts(page, searchInput).ToList();
                            break;
                        case "Disliked":
                            imageList = this.photoLeastDislikesService.SearchByDislikedPosts(page, searchInput).ToList();
                            break;
                        case "Commented":
                            imageList = this.photoLeastDislikesService.SearchByCommentedPosts(page, searchInput).ToList();
                            break;
                        default:
                            imageList = this.photoLeastDislikesService.GetImagePostsLeastDislikes(page).ToList();
                            break;
                    }

                    break;
                default:
                    break;
            }

            foreach (var image in imageList)
            {
                if (this.User.Identity.Name == image.Username)
                {
                    image.UsersOwnPhoto = true;
                }

                image.Tags = this.encoder.Encode(image.Tags);
                image.Camera = this.encoder.Encode(image.Camera);
                image.Location = this.encoder.Encode(image.Location);
                image.Caption = this.encoder.Encode(image.Caption);
            }

            return imageList;
        }
    }
}
