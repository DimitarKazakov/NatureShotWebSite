namespace NatureShot.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using NatureShot.Data.Models;
    using NatureShot.Services.Data;
    using NatureShot.Web.ViewModels.NormalPosts;

    public class NormalPostsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ITagsService tagsService;
        private readonly IPostsService postsService;

        public NormalPostsController(UserManager<ApplicationUser> userManager,
                                     ITagsService tagsService,
                                     IPostsService postsService)
        {
            this.userManager = userManager;
            this.tagsService = tagsService;
            this.postsService = postsService;
        }

        [Authorize]
        public IActionResult AddPost()
        {
            var viewModel = new NormalPostInputModel();
            viewModel.TagsDropDown = this.tagsService.GetAllTagsAsKeyValuePair();
            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddPost(NormalPostInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.TagsDropDown = this.tagsService.GetAllTagsAsKeyValuePair();

                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            await this.postsService.CreateNormalPostAsync(input, user.Id);

            return this.Redirect("/");
        }
    }
}
