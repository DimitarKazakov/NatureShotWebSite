namespace NatureShot.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NatureShot.Services.Data;
    using NatureShot.Services.Data.VideoPosts;
    using NatureShot.Web.ViewModels.Videos;

    public class VideoPostsController : Controller
    {
        private readonly IPostsService postsService;
        private readonly IVideoPostsNewest videoNewestService;
        private readonly IVideoPostsOldest videoOldestService;
        private readonly IVideoPostsLeastLikes videoLeastLikesService;
        private readonly IVideoPostsMostLikes videoMostLikesService;
        private readonly IVideoPostsMostDislikes videoMostDislikesService;
        private readonly IVideoPostsLeastDislikes videoLeastDislikesService;
        private readonly IVideoPostsLongest videoLongestService;
        private readonly IVideoPostsShortest videoShortestService;

        public VideoPostsController(IPostsService postsService,
                               IVideoPostsNewest videoNewestService,
                               IVideoPostsOldest videoOldestService,
                               IVideoPostsLeastLikes videoLeastLikesService,
                               IVideoPostsMostLikes videoMostLikesService,
                               IVideoPostsMostDislikes videoMostDislikesService,
                               IVideoPostsLeastDislikes videoLeastDislikesService,
                               IVideoPostsLongest videoLongestService,
                               IVideoPostsShortest videoShortestService)
        {
            this.postsService = postsService;
            this.videoNewestService = videoNewestService;
            this.videoOldestService = videoOldestService;
            this.videoLeastLikesService = videoLeastLikesService;
            this.videoMostLikesService = videoMostLikesService;
            this.videoMostDislikesService = videoMostDislikesService;
            this.videoLeastDislikesService = videoLeastDislikesService;
            this.videoLongestService = videoLongestService;
            this.videoShortestService = videoShortestService;
        }

        [Authorize]
        public IActionResult VideosNewest(string searchBy, string searchInput)
        {
            if (searchBy != null && searchInput != null)
            {
                return this.RedirectToAction("SearchByNewest", new { searchBy = searchBy, searchInput = searchInput });
            }

            var viewModel = this.videoNewestService.GetVideoPostsNewest(0);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult VideosOldest(string searchBy, string searchInput)
        {
            if (searchBy != null && searchInput != null)
            {
                return this.RedirectToAction("SearchByOldest", new { searchBy = searchBy, searchInput = searchInput });
            }

            var viewModel = this.videoOldestService.GetVideoPostsOldest(0);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult VideosLikesMost(string searchBy, string searchInput)
        {
            if (searchBy != null && searchInput != null)
            {
                return this.RedirectToAction("SearchByMostLikes", new { searchBy = searchBy, searchInput = searchInput });
            }

            var viewModel = this.videoMostLikesService.GetVideoPostsMostLikes(0);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult VideosLikesLeast(string searchBy, string searchInput)
        {
            if (searchBy != null && searchInput != null)
            {
                return this.RedirectToAction("SearchByLeastLikes", new { searchBy = searchBy, searchInput = searchInput });
            }

            var viewModel = this.videoLeastLikesService.GetVideoPostsLeastLikes(0);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult VideosDislikesMost(string searchBy, string searchInput)
        {
            if (searchBy != null && searchInput != null)
            {
                return this.RedirectToAction("SearchByMostDislikes", new { searchBy = searchBy, searchInput = searchInput });
            }

            var viewModel = this.videoMostDislikesService.GetVideoPostsMostDislikes(0);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult VideosDislikesLeast(string searchBy, string searchInput)
        {
            if (searchBy != null && searchInput != null)
            {
                return this.RedirectToAction("SearchByLeastDislikes", new { searchBy = searchBy, searchInput = searchInput });
            }

            var viewModel = this.videoLeastDislikesService.GetVideoPostsLeastDislikes(0);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult VideosLongest(string searchBy, string searchInput)
        {
            if (searchBy != null && searchInput != null)
            {
                return this.RedirectToAction("SearchByLongest", new { searchBy = searchBy, searchInput = searchInput });
            }

            var viewModel = this.videoLongestService.GetVideoPostsLongest(0);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult VideosShortest(string searchBy, string searchInput)
        {
            if (searchBy != null && searchInput != null)
            {
                return this.RedirectToAction("SearchByShortest", new { searchBy = searchBy, searchInput = searchInput });
            }

            var viewModel = this.videoShortestService.GetVideoPostsShortest(0);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult SearchByNewest(string searchBy, string searchInput)
        {
            var viewModel = new List<VideoPostViewModel>();
            switch (searchBy)
            {
                case "Name":
                    viewModel = this.videoNewestService.SearchByUsername(0, searchInput).ToList();
                    break;
                case "Tag":
                    viewModel = this.videoNewestService.SearchByTags(0, searchInput).ToList();
                    break;
                case "Location":
                    viewModel = this.videoNewestService.SearchByLocation(0, searchInput).ToList();
                    break;
                case "Camera":
                    viewModel = this.videoNewestService.SearchByCamera(0, searchInput).ToList();
                    break;
                case "Caption":
                    viewModel = this.videoNewestService.SearchByCaption(0, searchInput).ToList();
                    break;
                default:
                    break;
            }

            return this.View("VideosNewest", viewModel);
        }

        [Authorize]
        public IActionResult SearchByOldest(string searchBy, string searchInput)
        {
            var viewModel = new List<VideoPostViewModel>();
            switch (searchBy)
            {
                case "Name":
                    viewModel = this.videoOldestService.SearchByUsername(0, searchInput).ToList();
                    break;
                case "Tag":
                    viewModel = this.videoOldestService.SearchByTags(0, searchInput).ToList();
                    break;
                case "Location":
                    viewModel = this.videoOldestService.SearchByLocation(0, searchInput).ToList();
                    break;
                case "Camera":
                    viewModel = this.videoOldestService.SearchByCamera(0, searchInput).ToList();
                    break;
                case "Caption":
                    viewModel = this.videoOldestService.SearchByCaption(0, searchInput).ToList();
                    break;
                default:
                    break;
            }

            return this.View("VideosOldest", viewModel);
        }

        [Authorize]
        public IActionResult SearchByMostLikes(string searchBy, string searchInput)
        {
            var viewModel = new List<VideoPostViewModel>();
            switch (searchBy)
            {
                case "Name":
                    viewModel = this.videoMostLikesService.SearchByUsername(0, searchInput).ToList();
                    break;
                case "Tag":
                    viewModel = this.videoMostLikesService.SearchByTags(0, searchInput).ToList();
                    break;
                case "Location":
                    viewModel = this.videoMostLikesService.SearchByLocation(0, searchInput).ToList();
                    break;
                case "Camera":
                    viewModel = this.videoMostLikesService.SearchByCamera(0, searchInput).ToList();
                    break;
                case "Caption":
                    viewModel = this.videoMostLikesService.SearchByCaption(0, searchInput).ToList();
                    break;
                default:
                    break;
            }

            return this.View("VideosLikesMost", viewModel);
        }

        [Authorize]
        public IActionResult SearchByLeastLikes(string searchBy, string searchInput)
        {
            var viewModel = new List<VideoPostViewModel>();
            switch (searchBy)
            {
                case "Name":
                    viewModel = this.videoLeastLikesService.SearchByUsername(0, searchInput).ToList();
                    break;
                case "Tag":
                    viewModel = this.videoLeastLikesService.SearchByTags(0, searchInput).ToList();
                    break;
                case "Location":
                    viewModel = this.videoLeastLikesService.SearchByLocation(0, searchInput).ToList();
                    break;
                case "Camera":
                    viewModel = this.videoLeastLikesService.SearchByCamera(0, searchInput).ToList();
                    break;
                case "Caption":
                    viewModel = this.videoLeastLikesService.SearchByCaption(0, searchInput).ToList();
                    break;
                default:
                    break;
            }

            return this.View("VideosLikesLeast", viewModel);
        }

        [Authorize]
        public IActionResult SearchByMostDislikes(string searchBy, string searchInput)
        {
            var viewModel = new List<VideoPostViewModel>();
            switch (searchBy)
            {
                case "Name":
                    viewModel = this.videoMostDislikesService.SearchByUsername(0, searchInput).ToList();
                    break;
                case "Tag":
                    viewModel = this.videoMostDislikesService.SearchByTags(0, searchInput).ToList();
                    break;
                case "Location":
                    viewModel = this.videoMostDislikesService.SearchByLocation(0, searchInput).ToList();
                    break;
                case "Camera":
                    viewModel = this.videoMostDislikesService.SearchByCamera(0, searchInput).ToList();
                    break;
                case "Caption":
                    viewModel = this.videoMostDislikesService.SearchByCaption(0, searchInput).ToList();
                    break;
                default:
                    break;
            }

            return this.View("VideosDislikesMost", viewModel);
        }

        [Authorize]
        public IActionResult SearchByLeastDislikes(string searchBy, string searchInput)
        {
            var viewModel = new List<VideoPostViewModel>();
            switch (searchBy)
            {
                case "Name":
                    viewModel = this.videoLeastDislikesService.SearchByUsername(0, searchInput).ToList();
                    break;
                case "Tag":
                    viewModel = this.videoLeastDislikesService.SearchByTags(0, searchInput).ToList();
                    break;
                case "Location":
                    viewModel = this.videoLeastDislikesService.SearchByLocation(0, searchInput).ToList();
                    break;
                case "Camera":
                    viewModel = this.videoLeastDislikesService.SearchByCamera(0, searchInput).ToList();
                    break;
                case "Caption":
                    viewModel = this.videoLeastDislikesService.SearchByCaption(0, searchInput).ToList();
                    break;
                default:
                    break;
            }

            return this.View("VideosDislikesLeast", viewModel);
        }

        [Authorize]
        public IActionResult SearchByLongest(string searchBy, string searchInput)
        {
            var viewModel = new List<VideoPostViewModel>();
            switch (searchBy)
            {
                case "Name":
                    viewModel = this.videoLongestService.SearchByUsername(0, searchInput).ToList();
                    break;
                case "Tag":
                    viewModel = this.videoLongestService.SearchByTags(0, searchInput).ToList();
                    break;
                case "Location":
                    viewModel = this.videoLongestService.SearchByLocation(0, searchInput).ToList();
                    break;
                case "Camera":
                    viewModel = this.videoLongestService.SearchByCamera(0, searchInput).ToList();
                    break;
                case "Caption":
                    viewModel = this.videoLongestService.SearchByCaption(0, searchInput).ToList();
                    break;
                default:
                    break;
            }

            return this.View("VideosLongest", viewModel);
        }

        [Authorize]
        public IActionResult SearchByShortest(string searchBy, string searchInput)
        {
            var viewModel = new List<VideoPostViewModel>();
            switch (searchBy)
            {
                case "Name":
                    viewModel = this.videoShortestService.SearchByUsername(0, searchInput).ToList();
                    break;
                case "Tag":
                    viewModel = this.videoShortestService.SearchByTags(0, searchInput).ToList();
                    break;
                case "Location":
                    viewModel = this.videoShortestService.SearchByLocation(0, searchInput).ToList();
                    break;
                case "Camera":
                    viewModel = this.videoShortestService.SearchByCamera(0, searchInput).ToList();
                    break;
                case "Caption":
                    viewModel = this.videoShortestService.SearchByCaption(0, searchInput).ToList();
                    break;
                default:
                    break;
            }

            return this.View("VideosShortest", viewModel);
        }
    }
}
