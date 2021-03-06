﻿namespace NatureShot.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using LumenWorks.Framework.IO.Csv;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using NatureShot.Data;
    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;
    using NatureShot.Scraping;
    using NatureShot.Services.Data;
    using NatureShot.Services.Data.PhotoPosts;
    using NatureShot.Web.ViewModels.Images;
    using NatureShot.Services.Data.Contracts;
    using NatureShot.Services.Data.PhotoPosts.Contracts;

    public class PhotoPostsController : Controller
    {
        private readonly IPostsService postsService;
        private readonly IPhotoPostsNewest photoNewestService;
        private readonly IPhotoPostsOldest photoOldestService;
        private readonly IPhotoPostsLeastLikes photoLeastLikesService;
        private readonly IPhotoPostsMostLikes photoMostLikesService;
        private readonly IPhotoPostsMostDislikes photoMostDislikesService;
        private readonly IPhotoPostsLeastDislikes photoLeastDislikesService;

        public PhotoPostsController(IPostsService postsService,
                               IPhotoPostsNewest photoNewestService,
                               IPhotoPostsOldest photoOldestService,
                               IPhotoPostsLeastLikes photoLeastLikesService,
                               IPhotoPostsMostLikes photoMostLikesService,
                               IPhotoPostsMostDislikes photoMostDislikesService,
                               IPhotoPostsLeastDislikes photoLeastDislikesService)
        {
            this.postsService = postsService;
            this.photoNewestService = photoNewestService;
            this.photoOldestService = photoOldestService;
            this.photoLeastLikesService = photoLeastLikesService;
            this.photoMostLikesService = photoMostLikesService;
            this.photoMostDislikesService = photoMostDislikesService;
            this.photoLeastDislikesService = photoLeastDislikesService;
        }

        [Authorize]
        public IActionResult PhotosNewest(string searchBy, string searchInput)
        {
            if (searchBy != null && searchInput != null)
            {
                return this.RedirectToAction("SearchByNewest", new { searchBy = searchBy, searchInput = searchInput });
            }

            var viewModel = this.photoNewestService.GetImagePostsNewest(0);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult PhotosOldest(string searchBy, string searchInput)
        {
            if (searchBy != null && searchInput != null)
            {
                return this.RedirectToAction("SearchByOldest", new { searchBy = searchBy, searchInput = searchInput });
            }

            var viewModel = this.photoOldestService.GetImagePostsOldest(0);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult PhotosLikesMost(string searchBy, string searchInput)
        {
            if (searchBy != null && searchInput != null)
            {
                return this.RedirectToAction("SearchByMostLikes", new { searchBy = searchBy, searchInput = searchInput });
            }

            var viewModel = this.photoMostLikesService.GetImagePostsMostLikes(0);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult PhotosLikesLeast(string searchBy, string searchInput)
        {
            if (searchBy != null && searchInput != null)
            {
                return this.RedirectToAction("SearchByLeastLikes", new { searchBy = searchBy, searchInput = searchInput });
            }

            var viewModel = this.photoLeastLikesService.GetImagePostsLeastLikes(0);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult PhotosDislikesMost(string searchBy, string searchInput)
        {
            if (searchBy != null && searchInput != null)
            {
                return this.RedirectToAction("SearchByMostDislikes", new { searchBy = searchBy, searchInput = searchInput });
            }

            var viewModel = this.photoMostDislikesService.GetImagePostsMostDislikes(0);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult PhotosDislikesLeast(string searchBy, string searchInput)
        {
            if (searchBy != null && searchInput != null)
            {
                return this.RedirectToAction("SearchByLeastDislikes", new { searchBy = searchBy, searchInput = searchInput });
            }

            var viewModel = this.photoLeastDislikesService.GetImagePostsLeastDislikes(0);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult SearchByNewest(string searchBy, string searchInput)
        {
            var viewModel = new List<ImagePostViewModel>();
            switch (searchBy)
            {
                case "Name":
                    viewModel = this.photoNewestService.SearchByUsername(0, searchInput).ToList();
                    break;
                case "Tag":
                    viewModel = this.photoNewestService.SearchByTags(0, searchInput).ToList();
                    break;
                case "Location":
                    viewModel = this.photoNewestService.SearchByLocation(0, searchInput).ToList();
                    break;
                case "Camera":
                    viewModel = this.photoNewestService.SearchByCamera(0, searchInput).ToList();
                    break;
                case "Caption":
                    viewModel = this.photoNewestService.SearchByCaption(0, searchInput).ToList();
                    break;
                case "Liked":
                    viewModel = this.photoNewestService.SearchByLikedPosts(0, searchInput).ToList();
                    break;
                case "Disliked":
                    viewModel = this.photoNewestService.SearchByDislikedPosts(0, searchInput).ToList();
                    break;
                case "Commented":
                    viewModel = this.photoNewestService.SearchByCommentedPosts(0, searchInput).ToList();
                    break;
                default:
                    break;
            }

            return this.View("PhotosNewest", viewModel);
        }

        [Authorize]
        public IActionResult SearchByOldest(string searchBy, string searchInput)
        {
            var viewModel = new List<ImagePostViewModel>();
            switch (searchBy)
            {
                case "Name":
                    viewModel = this.photoOldestService.SearchByUsername(0, searchInput).ToList();
                    break;
                case "Tag":
                    viewModel = this.photoOldestService.SearchByTags(0, searchInput).ToList();
                    break;
                case "Location":
                    viewModel = this.photoOldestService.SearchByLocation(0, searchInput).ToList();
                    break;
                case "Camera":
                    viewModel = this.photoOldestService.SearchByCamera(0, searchInput).ToList();
                    break;
                case "Caption":
                    viewModel = this.photoOldestService.SearchByCaption(0, searchInput).ToList();
                    break;
                case "Liked":
                    viewModel = this.photoOldestService.SearchByLikedPosts(0, searchInput).ToList();
                    break;
                case "Disliked":
                    viewModel = this.photoOldestService.SearchByDislikedPosts(0, searchInput).ToList();
                    break;
                case "Commented":
                    viewModel = this.photoOldestService.SearchByCommentedPosts(0, searchInput).ToList();
                    break;
                default:
                    break;
            }

            return this.View("PhotosOldest", viewModel);
        }

        [Authorize]
        public IActionResult SearchByMostLikes(string searchBy, string searchInput)
        {
            var viewModel = new List<ImagePostViewModel>();
            switch (searchBy)
            {
                case "Name":
                    viewModel = this.photoMostLikesService.SearchByUsername(0, searchInput).ToList();
                    break;
                case "Tag":
                    viewModel = this.photoMostLikesService.SearchByTags(0, searchInput).ToList();
                    break;
                case "Location":
                    viewModel = this.photoMostLikesService.SearchByLocation(0, searchInput).ToList();
                    break;
                case "Camera":
                    viewModel = this.photoMostLikesService.SearchByCamera(0, searchInput).ToList();
                    break;
                case "Caption":
                    viewModel = this.photoMostLikesService.SearchByCaption(0, searchInput).ToList();
                    break;
                case "Liked":
                    viewModel = this.photoMostLikesService.SearchByLikedPosts(0, searchInput).ToList();
                    break;
                case "Disliked":
                    viewModel = this.photoMostLikesService.SearchByDislikedPosts(0, searchInput).ToList();
                    break;
                case "Commented":
                    viewModel = this.photoMostLikesService.SearchByCommentedPosts(0, searchInput).ToList();
                    break;
                default:
                    break;
            }

            return this.View("PhotosLikesMost", viewModel);
        }

        [Authorize]
        public IActionResult SearchByLeastLikes(string searchBy, string searchInput)
        {
            var viewModel = new List<ImagePostViewModel>();
            switch (searchBy)
            {
                case "Name":
                    viewModel = this.photoLeastLikesService.SearchByUsername(0, searchInput).ToList();
                    break;
                case "Tag":
                    viewModel = this.photoLeastLikesService.SearchByTags(0, searchInput).ToList();
                    break;
                case "Location":
                    viewModel = this.photoLeastLikesService.SearchByLocation(0, searchInput).ToList();
                    break;
                case "Camera":
                    viewModel = this.photoLeastLikesService.SearchByCamera(0, searchInput).ToList();
                    break;
                case "Caption":
                    viewModel = this.photoLeastLikesService.SearchByCaption(0, searchInput).ToList();
                    break;
                case "Liked":
                    viewModel = this.photoLeastLikesService.SearchByLikedPosts(0, searchInput).ToList();
                    break;
                case "Disliked":
                    viewModel = this.photoLeastLikesService.SearchByDislikedPosts(0, searchInput).ToList();
                    break;
                case "Commented":
                    viewModel = this.photoLeastLikesService.SearchByCommentedPosts(0, searchInput).ToList();
                    break;
                default:
                    break;
            }

            return this.View("PhotosLikesLeast", viewModel);
        }

        [Authorize]
        public IActionResult SearchByMostDislikes(string searchBy, string searchInput)
        {
            var viewModel = new List<ImagePostViewModel>();
            switch (searchBy)
            {
                case "Name":
                    viewModel = this.photoMostDislikesService.SearchByUsername(0, searchInput).ToList();
                    break;
                case "Tag":
                    viewModel = this.photoMostDislikesService.SearchByTags(0, searchInput).ToList();
                    break;
                case "Location":
                    viewModel = this.photoMostDislikesService.SearchByLocation(0, searchInput).ToList();
                    break;
                case "Camera":
                    viewModel = this.photoMostDislikesService.SearchByCamera(0, searchInput).ToList();
                    break;
                case "Caption":
                    viewModel = this.photoMostDislikesService.SearchByCaption(0, searchInput).ToList();
                    break;
                case "Liked":
                    viewModel = this.photoMostDislikesService.SearchByLikedPosts(0, searchInput).ToList();
                    break;
                case "Disliked":
                    viewModel = this.photoMostDislikesService.SearchByDislikedPosts(0, searchInput).ToList();
                    break;
                case "Commented":
                    viewModel = this.photoMostDislikesService.SearchByCommentedPosts(0, searchInput).ToList();
                    break;
                default:
                    break;
            }

            return this.View("PhotosDislikesMost", viewModel);
        }

        [Authorize]
        public IActionResult SearchByLeastDislikes(string searchBy, string searchInput)
        {
            var viewModel = new List<ImagePostViewModel>();
            switch (searchBy)
            {
                case "Name":
                    viewModel = this.photoLeastDislikesService.SearchByUsername(0, searchInput).ToList();
                    break;
                case "Tag":
                    viewModel = this.photoLeastDislikesService.SearchByTags(0, searchInput).ToList();
                    break;
                case "Location":
                    viewModel = this.photoLeastDislikesService.SearchByLocation(0, searchInput).ToList();
                    break;
                case "Camera":
                    viewModel = this.photoLeastDislikesService.SearchByCamera(0, searchInput).ToList();
                    break;
                case "Caption":
                    viewModel = this.photoLeastDislikesService.SearchByCaption(0, searchInput).ToList();
                    break;
                case "Liked":
                    viewModel = this.photoLeastDislikesService.SearchByLikedPosts(0, searchInput).ToList();
                    break;
                case "Disliked":
                    viewModel = this.photoLeastDislikesService.SearchByDislikedPosts(0, searchInput).ToList();
                    break;
                case "Commented":
                    viewModel = this.photoLeastDislikesService.SearchByCommentedPosts(0, searchInput).ToList();
                    break;
                default:
                    break;
            }

            return this.View("PhotosDislikesLeast", viewModel);
        }
    }
}
