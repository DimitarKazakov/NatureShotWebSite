namespace NatureShot.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using NatureShot.Data.Models;
    using NatureShot.Services.Data;
    using NatureShot.Web.CloudinaryHelper;
    using NatureShot.Web.ViewModels.Images;
    using NatureShot.Web.ViewModels.NormalPosts;
    using NatureShot.Web.ViewModels.Videos;

    public class PostsController : Controller
    {
        private Cloudinary cloudinary;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPostsService postsService;
        private readonly ILocationsService locationsService;
        private readonly ICameraService cameraService;
        private readonly ITagsService tagsService;

        public PostsController(Cloudinary cloudinary,
                                UserManager<ApplicationUser> userManager,
                                IPostsService postsService,
                                ILocationsService locationsService,
                                ICameraService cameraService,
                                ITagsService tagsService)
        {
            this.cloudinary = cloudinary;
            this.userManager = userManager;
            this.postsService = postsService;
            this.locationsService = locationsService;
            this.cameraService = cameraService;
            this.tagsService = tagsService;
        }

        [Authorize]
        public IActionResult AddImage()
        {
            var viewModel = new ImagePostInputModel();
            viewModel.LocationsDropDown = this.locationsService.GetAllLocationsAsKeyValuePair();
            viewModel.CamerasDropDown = this.cameraService.GetAllCamerasAsKeyValuePair();
            viewModel.TagsDropDown = this.tagsService.GetAllTagsAsKeyValuePair();

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddImage(ImagePostInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.LocationsDropDown = this.locationsService.GetAllLocationsAsKeyValuePair();
                input.CamerasDropDown = this.cameraService.GetAllCamerasAsKeyValuePair();
                input.TagsDropDown = this.tagsService.GetAllTagsAsKeyValuePair();

                return this.View(input);
            }

            var imageInfo = await CloudinaryExtension.UploadImageAsync(this.cloudinary, input.Image);
            var user = await this.userManager.GetUserAsync(this.User);
            await this.postsService.CreateImagePostAsync(input, user.Id, imageInfo);

            return this.Redirect("/");
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

        [Authorize]
        public IActionResult AddVideo()
        {
            var viewModel = new VideoPostInputModel();
            viewModel.LocationsDropDown = this.locationsService.GetAllLocationsAsKeyValuePair();
            viewModel.CamerasDropDown = this.cameraService.GetAllCamerasAsKeyValuePair();
            viewModel.TagsDropDown = this.tagsService.GetAllTagsAsKeyValuePair();

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddVideo(VideoPostInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.LocationsDropDown = this.locationsService.GetAllLocationsAsKeyValuePair();
                input.CamerasDropDown = this.cameraService.GetAllCamerasAsKeyValuePair();
                input.TagsDropDown = this.tagsService.GetAllTagsAsKeyValuePair();

                return this.View(input);
            }

            var videoInfo = await CloudinaryExtension.UploadVideoAsync(this.cloudinary, input.Video);
            var user = await this.userManager.GetUserAsync(this.User);
            await this.postsService.CreateVideoPostAsync(input, user.Id, videoInfo);

            return this.Redirect("/");
        }
    }
}
