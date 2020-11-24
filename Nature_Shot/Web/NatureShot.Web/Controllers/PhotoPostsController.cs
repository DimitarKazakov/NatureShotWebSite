namespace NatureShot.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using LumenWorks.Framework.IO.Csv;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NatureShot.Data;
    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;
    using NatureShot.Scraping;
    using NatureShot.Services.Data;
    using NatureShot.Services.Data.PhotoPosts;
    using NatureShot.Web.ViewModels.Images;

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
        public IActionResult NormalPosts()
        {
            var viewModel = this.postsService.GetNormalPosts(0);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult PhotosNewest()
        {
            var viewModel = this.photoNewestService.GetImagePostsNewest(0);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult PhotosOldest()
        {
            var viewModel = this.photoOldestService.GetImagePostsOldest(0);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult PhotosLikesMost()
        {
            var viewModel = this.photoMostLikesService.GetImagePostsMostLikes(0);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult PhotosLikesLeast()
        {
            var viewModel = this.photoLeastLikesService.GetImagePostsLeastLikes(0);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult PhotosDislikesMost()
        {
            var viewModel = this.photoMostDislikesService.GetImagePostsMostDislikes(0);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult PhotosDislikesLeast()
        {
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
                case "Location Name":
                    viewModel = this.photoNewestService.SearchByLocation(0, searchInput).ToList();
                    break;
                case "Camera Model":
                    viewModel = this.photoNewestService.SearchByCamera(0, searchInput).ToList();
                    break;
                case "Caption":
                    viewModel = this.photoNewestService.SearchByCaption(0, searchInput).ToList();
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
                case "Location Name":
                    viewModel = this.photoOldestService.SearchByLocation(0, searchInput).ToList();
                    break;
                case "Camera Model":
                    viewModel = this.photoOldestService.SearchByCamera(0, searchInput).ToList();
                    break;
                case "Caption":
                    viewModel = this.photoOldestService.SearchByCaption(0, searchInput).ToList();
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
                case "Location Name":
                    viewModel = this.photoMostLikesService.SearchByLocation(0, searchInput).ToList();
                    break;
                case "Camera Model":
                    viewModel = this.photoMostLikesService.SearchByCamera(0, searchInput).ToList();
                    break;
                case "Caption":
                    viewModel = this.photoMostLikesService.SearchByCaption(0, searchInput).ToList();
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
                case "Location Name":
                    viewModel = this.photoLeastLikesService.SearchByLocation(0, searchInput).ToList();
                    break;
                case "Camera Model":
                    viewModel = this.photoLeastLikesService.SearchByCamera(0, searchInput).ToList();
                    break;
                case "Caption":
                    viewModel = this.photoLeastLikesService.SearchByCaption(0, searchInput).ToList();
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
                case "Location Name":
                    viewModel = this.photoMostDislikesService.SearchByLocation(0, searchInput).ToList();
                    break;
                case "Camera Model":
                    viewModel = this.photoMostDislikesService.SearchByCamera(0, searchInput).ToList();
                    break;
                case "Caption":
                    viewModel = this.photoMostDislikesService.SearchByCaption(0, searchInput).ToList();
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
                case "Location Name":
                    viewModel = this.photoLeastDislikesService.SearchByLocation(0, searchInput).ToList();
                    break;
                case "Camera Model":
                    viewModel = this.photoLeastDislikesService.SearchByCamera(0, searchInput).ToList();
                    break;
                case "Caption":
                    viewModel = this.photoLeastDislikesService.SearchByCaption(0, searchInput).ToList();
                    break;
                default:
                    break;
            }

            return this.View("PhotosDislikesLeast", viewModel);
        }
    }
}
