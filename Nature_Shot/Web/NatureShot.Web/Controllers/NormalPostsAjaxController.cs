namespace NatureShot.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Encodings.Web;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NatureShot.Services.Data;
    using NatureShot.Web.ViewModels.NormalPosts;

    [Route("api/[controller]")]
    [ApiController]
    public class NormalPostsAjaxController : BaseController
    {
        private readonly IPostsService postsService;
        private readonly HtmlEncoder encoder;

        public NormalPostsAjaxController(IPostsService postsService, HtmlEncoder encoder)
        {
            this.postsService = postsService;
            this.encoder = encoder;
        }

        [Authorize]
        [HttpGet("{page}")]
        public ICollection<NormalPostViewModel> LoadMoreImages(int page)
        {
            var normalPostList = this.postsService.GetNormalPosts(page).ToList();
            foreach (var post in normalPostList)
            {
                post.Caption = this.encoder.Encode(post.Caption);
            }

            return normalPostList;
        }
    }
}
