namespace NatureShot.Web.Controllers
{
    using System.Data;
    using System.IO;
    using System.Threading.Tasks;
    using LumenWorks.Framework.IO.Csv;
    using Microsoft.AspNetCore.Mvc;
    using NatureShot.Data;
    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;
    using NatureShot.Services.Data;
    using NatureShot.Web.ViewModels;
    using NatureShot.Scraping;
    using System.Collections.Generic;
    using System.Linq;

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
