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
        public PostsController()
        {
        }

        public IActionResult Photos()
        {
            return this.View();
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
