namespace NatureShot.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using NatureShot.Data;
    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;
    using NatureShot.Services.Data;
    using NatureShot.Services.Data.Contracts;
    using NatureShot.Web.CloudinaryHelper;
    using NatureShot.Web.ViewModels;
    using NatureShot.Web.ViewModels.Home;
    using NatureShot.Web.ViewModels.User;

    public class HomeController : BaseController
    {
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly Cloudinary cloudinary;
        private readonly SignInManager<ApplicationUser> signInManager;

        public HomeController(IUserService userService,
                              UserManager<ApplicationUser> userManager,
                              Cloudinary cloudinary,
                              SignInManager<ApplicationUser> SignInManager)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.cloudinary = cloudinary;
            signInManager = SignInManager;
        }

        public IActionResult Index()
        {
            if (this.signInManager.IsSignedIn(this.User))
            {
                return this.RedirectToAction(nameof(this.Profile), new { username = this.User.Identity.Name });
            }

            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [Authorize]
        [HttpGet("{username}")]
        public async Task<IActionResult> Profile(string username)
        {
            if (username != null)
            {
                var id = this.userService.GetUserId(username);
                if (id != null)
                {
                    var viewModel = this.userService.GetUserDataForProfile(id);
                    return this.View(viewModel);
                }
            }

            var user = await this.userManager.GetUserAsync(this.User);
            var model = this.userService.GetUserDataForProfile(user.Id);
            return this.View(model);
        }

        [Authorize]
        public async Task<IActionResult> OtherProfile([FromQuery] string username)
        {
            if (username != null)
            {
                var id = this.userService.GetUserId(username);
                if (id != null)
                {
                    var viewModel = this.userService.GetUserDataForProfile(id);
                    return this.View(nameof(this.Profile), viewModel);
                }
            }

            var user = await this.userManager.GetUserAsync(this.User);
            var model = this.userService.GetUserDataForProfile(user.Id);
            return this.View(nameof(this.Profile), model);
        }

        [Authorize]
        public async Task<IActionResult> UpdateProfile()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var model = this.userService.GetUserDataForUpdate(user.Id);
            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateProfile(UserProfileInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            if (input.ProfilePicture != null)
            {
                var imageInfo = await CloudinaryExtension.UploadImageAsync(this.cloudinary, input.ProfilePicture);
                await this.userService.UpdateProfile(input, imageInfo);
            }
            else
            {
                await this.userService.UpdateProfile(input);
            }

            return this.RedirectToAction(nameof(this.Profile), new { username = "My" });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
