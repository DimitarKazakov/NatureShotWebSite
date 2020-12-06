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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteImage(int id)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (!this.postsService.CheckPostOwner(id, user.Id))
            {
                return this.Redirect($"/PhotoPosts/PhotosNewest");
            }

            await this.postsService.Delete(id);
            return this.Redirect($"/PhotoPosts/PhotosNewest");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteVideo(int id)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (!this.postsService.CheckPostOwner(id, user.Id))
            {
                return this.Redirect("/VideoPosts/VideosNewest");
            }

            await this.postsService.Delete(id);
            return this.Redirect("/VideoPosts/VideosNewest");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (!this.postsService.CheckPostOwner(id, user.Id))
            {
                return this.Redirect("/NormalPosts/NormalPostsNewest");
            }

            await this.postsService.Delete(id);
            return this.Redirect("/NormalPosts/NormalPostsNewest");
        }

        [Authorize]
        public async Task<IActionResult> UpdateImage(int id)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (!this.postsService.CheckPostOwner(id, user.Id))
            {
                return this.Redirect($"/PhotoPosts/PhotosNewest");
            }

            var viewModel = this.postsService.GetImagePost(id);
            viewModel.LocationsDropDown = this.locationsService.GetAllLocationsAsKeyValuePair();
            viewModel.CamerasDropDown = this.cameraService.GetAllCamerasAsKeyValuePair();
            viewModel.TagsDropDown = this.tagsService.GetAllTagsAsKeyValuePair();
            return this.View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> UpdateVideo(int id)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (!this.postsService.CheckPostOwner(id, user.Id))
            {
                return this.Redirect("/VideoPosts/VideosNewest");
            }

            var viewModel = this.postsService.GetVideoPost(id);
            viewModel.LocationsDropDown = this.locationsService.GetAllLocationsAsKeyValuePair();
            viewModel.CamerasDropDown = this.cameraService.GetAllCamerasAsKeyValuePair();
            viewModel.TagsDropDown = this.tagsService.GetAllTagsAsKeyValuePair();
            return this.View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> UpdatePost(int id)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (!this.postsService.CheckPostOwner(id, user.Id))
            {
                return this.Redirect("/NormalPosts/NormalPostsNewest");
            }

            var viewModel = this.postsService.GetNormalPost(id);
            viewModel.TagsDropDown = this.tagsService.GetAllTagsAsKeyValuePair();
            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateVideo(VideoPostUpdateModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.LocationsDropDown = this.locationsService.GetAllLocationsAsKeyValuePair();
                input.CamerasDropDown = this.cameraService.GetAllCamerasAsKeyValuePair();
                input.TagsDropDown = this.tagsService.GetAllTagsAsKeyValuePair();

                return this.View(input);
            }

            await this.postsService.UpdateVideo(input);
            return this.Redirect("/VideoPosts/VideosNewest");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateImage(ImagePostUpdateModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.LocationsDropDown = this.locationsService.GetAllLocationsAsKeyValuePair();
                input.CamerasDropDown = this.cameraService.GetAllCamerasAsKeyValuePair();
                input.TagsDropDown = this.tagsService.GetAllTagsAsKeyValuePair();

                return this.View(input);
            }

            await this.postsService.UpdateImage(input);
            return this.Redirect($"/PhotoPosts/PhotosNewest");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdatePost(NormalPostUpdateModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.TagsDropDown = this.tagsService.GetAllTagsAsKeyValuePair();

                return this.View(input);
            }

            await this.postsService.UpdatePost(input);
            return this.Redirect("/NormalPosts/NormalPostsNewest");
        }
    }
}
