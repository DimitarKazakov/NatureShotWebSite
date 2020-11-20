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
        private readonly IPostsService postsService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILocationsService locationsService;

        public ImagesController(Cloudinary cloudinary,
                                IPostsService postsService,
                                UserManager<ApplicationUser> userManager,
                                ILocationsService locationsService)
        {
            this.cloudinary = cloudinary;
            this.postsService = postsService;
            this.userManager = userManager;
            this.locationsService = locationsService;
        }

        [Authorize]
        public IActionResult AddImage()
        {
            var viewModel = new ImagePostInputModel();
            viewModel.LocationsDropDown = this.locationsService.GetAllLocationsAsKeyValuePair();

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
