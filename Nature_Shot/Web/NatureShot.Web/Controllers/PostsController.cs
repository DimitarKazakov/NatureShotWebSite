namespace NatureShot.Web.Controllers
{

    using LumenWorks.Framework.IO.Csv;
    using Microsoft.AspNetCore.Mvc;
    using NatureShot.Data;
    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;
    using NatureShot.Services.Data;
    using NatureShot.Scraping;

    public class PostsController : Controller
    {
        private readonly IPostsService postsService;

        public PostsController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        public IActionResult Photos()
        {
            var viewModel = this.postsService.GetImagePosts(0);
            return this.View(viewModel);
        }

        //[HttpPost]
        //public IActionResult Photos(int id)
        //{
        //    return this.Redirect("/");
        //}

        public IActionResult NormalPosts()
        {
            return this.View();
        }
    }
}
