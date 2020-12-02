namespace NatureShot.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using NatureShot.Data.Models;
    using NatureShot.Services.Data;
    using NatureShot.Services.Data.NormalPosts;
    using NatureShot.Web.ViewModels.NormalPosts;

    public class NormalPostsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ITagsService tagsService;
        private readonly IPostsService postsService;
        private readonly INormalPostsNewest normalPostNewestService;
        private readonly INormalPostsOldest normalPostOldestService;
        private readonly INormalPostsMostLikes normalPostMostLikesService;
        private readonly INormalPostsLeastLikes normalPostLeastLikesService;
        private readonly INormalPostsMostDislikes normalPostMostDislikesService;
        private readonly INormalPostsLeastDislikes normalPostLeastDislikesService;

        public NormalPostsController(UserManager<ApplicationUser> userManager,
                                     ITagsService tagsService,
                                     IPostsService postsService,
                                     INormalPostsNewest normalPostNewestService,
                                     INormalPostsOldest normalPostOldestService,
                                     INormalPostsMostLikes normalPostMostLikesService,
                                     INormalPostsLeastLikes normalPostLeastLikesService,
                                     INormalPostsMostDislikes normalPostMostDislikesService,
                                     INormalPostsLeastDislikes normalPostLeastDislikesService)
        {
            this.userManager = userManager;
            this.tagsService = tagsService;
            this.postsService = postsService;
            this.normalPostNewestService = normalPostNewestService;
            this.normalPostOldestService = normalPostOldestService;
            this.normalPostMostLikesService = normalPostMostLikesService;
            this.normalPostLeastLikesService = normalPostLeastLikesService;
            this.normalPostMostDislikesService = normalPostMostDislikesService;
            this.normalPostLeastDislikesService = normalPostLeastDislikesService;
        }

        [Authorize]
        public IActionResult NormalPostsNewest(string searchBy, string searchInput)
        {
            if (searchBy != null && searchInput != null)
            {
                return this.RedirectToAction("SearchByNewest", new { searchBy = searchBy, searchInput = searchInput });
            }

            var viewModel = this.normalPostNewestService.GetNormalPostsNewest(0);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult NormalPostsOldest(string searchBy, string searchInput)
        {
            if (searchBy != null && searchInput != null)
            {
                return this.RedirectToAction("SearchByOldest", new { searchBy = searchBy, searchInput = searchInput });
            }

            var viewModel = this.normalPostOldestService.GetNormalPostsOldest(0);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult NormalPostsLikesMost(string searchBy, string searchInput)
        {
            if (searchBy != null && searchInput != null)
            {
                return this.RedirectToAction("SearchByMostLikes", new { searchBy = searchBy, searchInput = searchInput });
            }

            var viewModel = this.normalPostMostLikesService.GetNormalPostsMostLikes(0);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult NormalPostsLikesLeast(string searchBy, string searchInput)
        {
            if (searchBy != null && searchInput != null)
            {
                return this.RedirectToAction("SearchByLeastLikes", new { searchBy = searchBy, searchInput = searchInput });
            }

            var viewModel = this.normalPostLeastLikesService.GetNormalPostsLeastLikes(0);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult NormalPostsDislikesMost(string searchBy, string searchInput)
        {
            if (searchBy != null && searchInput != null)
            {
                return this.RedirectToAction("SearchByMostDislikes", new { searchBy = searchBy, searchInput = searchInput });
            }

            var viewModel = this.normalPostMostDislikesService.GetNormalPostsMostDislikes(0);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult NormalPostsDislikesLeast(string searchBy, string searchInput)
        {
            if (searchBy != null && searchInput != null)
            {
                return this.RedirectToAction("SearchByLeastDislikes", new { searchBy = searchBy, searchInput = searchInput });
            }

            var viewModel = this.normalPostLeastDislikesService.GetNormalPostsLeastDislikes(0);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult SearchByNewest(string searchBy, string searchInput)
        {
            var viewModel = new List<NormalPostViewModel>();
            switch (searchBy)
            {
                case "Name":
                    viewModel = this.normalPostNewestService.SearchByUsername(0, searchInput).ToList();
                    break;
                case "Tag":
                    viewModel = this.normalPostNewestService.SearchByTags(0, searchInput).ToList();
                    break;
                case "Caption":
                    viewModel = this.normalPostNewestService.SearchByCaption(0, searchInput).ToList();
                    break;
                default:
                    break;
            }

            return this.View("NormalPostsNewest", viewModel);
        }

        [Authorize]
        public IActionResult SearchByOldest(string searchBy, string searchInput)
        {
            var viewModel = new List<NormalPostViewModel>();
            switch (searchBy)
            {
                case "Name":
                    viewModel = this.normalPostOldestService.SearchByUsername(0, searchInput).ToList();
                    break;
                case "Tag":
                    viewModel = this.normalPostOldestService.SearchByTags(0, searchInput).ToList();
                    break;
                case "Caption":
                    viewModel = this.normalPostOldestService.SearchByCaption(0, searchInput).ToList();
                    break;
                default:
                    break;
            }

            return this.View("NormalPostsOldest", viewModel);
        }

        [Authorize]
        public IActionResult SearchByMostLikes(string searchBy, string searchInput)
        {
            var viewModel = new List<NormalPostViewModel>();
            switch (searchBy)
            {
                case "Name":
                    viewModel = this.normalPostMostLikesService.SearchByUsername(0, searchInput).ToList();
                    break;
                case "Tag":
                    viewModel = this.normalPostMostLikesService.SearchByTags(0, searchInput).ToList();
                    break;
                case "Caption":
                    viewModel = this.normalPostMostLikesService.SearchByCaption(0, searchInput).ToList();
                    break;
                default:
                    break;
            }

            return this.View("NormalPostsLikesMost", viewModel);
        }

        [Authorize]
        public IActionResult SearchByLeastLikes(string searchBy, string searchInput)
        {
            var viewModel = new List<NormalPostViewModel>();
            switch (searchBy)
            {
                case "Name":
                    viewModel = this.normalPostLeastLikesService.SearchByUsername(0, searchInput).ToList();
                    break;
                case "Tag":
                    viewModel = this.normalPostLeastLikesService.SearchByTags(0, searchInput).ToList();
                    break;
                case "Caption":
                    viewModel = this.normalPostLeastLikesService.SearchByCaption(0, searchInput).ToList();
                    break;
                default:
                    break;
            }

            return this.View("NormalPostsLikesLeast", viewModel);
        }

        [Authorize]
        public IActionResult SearchByMostDislikes(string searchBy, string searchInput)
        {
            var viewModel = new List<NormalPostViewModel>();
            switch (searchBy)
            {
                case "Name":
                    viewModel = this.normalPostMostDislikesService.SearchByUsername(0, searchInput).ToList();
                    break;
                case "Tag":
                    viewModel = this.normalPostMostDislikesService.SearchByTags(0, searchInput).ToList();
                    break;
                case "Caption":
                    viewModel = this.normalPostMostDislikesService.SearchByCaption(0, searchInput).ToList();
                    break;
                default:
                    break;
            }

            return this.View("NormalPostsDislikesMost", viewModel);
        }

        [Authorize]
        public IActionResult SearchByLeastDislikes(string searchBy, string searchInput)
        {
            var viewModel = new List<NormalPostViewModel>();
            switch (searchBy)
            {
                case "Name":
                    viewModel = this.normalPostLeastDislikesService.SearchByUsername(0, searchInput).ToList();
                    break;
                case "Tag":
                    viewModel = this.normalPostLeastDislikesService.SearchByTags(0, searchInput).ToList();
                    break;
                case "Caption":
                    viewModel = this.normalPostLeastDislikesService.SearchByCaption(0, searchInput).ToList();
                    break;
                default:
                    break;
            }

            return this.View("NormalPostsDislikesLeast", viewModel);
        }
    }
}
