namespace NatureShot.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using NatureShot.Data;
    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;
    using NatureShot.Services.Data;
    using NatureShot.Web.CloudinaryHelper;
    using NatureShot.Web.ViewModels;
    using NatureShot.Web.ViewModels.Home;
    using NatureShot.Web.ViewModels.Images;

    public class ImagesController : Controller
    {
        private readonly Cloudinary cloudinary;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPostsService postsService;
        private readonly ILocationsService locationsService;
        private readonly ICameraService cameraService;
        private readonly ITagsService tagsService;

        public ImagesController(Cloudinary cloudinary,
                                UserManager<ApplicationUser> userManager,
                                IPostsService postsService,
                                ILocationsService locationsService,
                                ICameraService cameraService,
                                ITagsService tagsService)
        {
            this.cloudinary = cloudinary;
            this.postsService = postsService;
            this.userManager = userManager;
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

                return this.View(input);
            }

            var imageInfo = await CloudinaryExtension.UploadImageAsync(this.cloudinary, input.Image);
            var user = await this.userManager.GetUserAsync(this.User);
            await this.postsService.CreateImagePostAsync(input, user.Id, imageInfo);

            return this.Redirect("/");
        }
    }
}
