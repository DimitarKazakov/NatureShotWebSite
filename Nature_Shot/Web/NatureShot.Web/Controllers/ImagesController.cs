namespace NatureShot.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;
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

        public ImagesController(Cloudinary cloudinary)
        {
            this.cloudinary = cloudinary;
        }

        public IActionResult AddImage()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddImage(ImagePostInputModel input)
        {
            // image-path: http://res.cloudinary.com/drw0gj3qi/image/upload/v1605470739/a7dwxdo8bnmqnrxe5lju.jpg
            var imageUrl = await CloudinaryExtension.UploadImageAsync(this.cloudinary, input.Image);
            return this.Redirect("/");
        }
    }
}
