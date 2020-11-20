namespace NatureShot.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using NatureShot.Services.Data;
    using NatureShot.Web.ViewModels.Images;

    [Route("api/[controller]")]
    [ApiController]
    public class ImagePostsController : ControllerBase
    {
        private readonly IPostsService postsService;

        public ImagePostsController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        [HttpGet("{page}")]
        public ICollection<ImagePostViewModel> LoadMoreImages(int page)
        {
            var imageList = this.postsService.GetImagePosts(page).ToList();

            return imageList;
        }
    }
}
