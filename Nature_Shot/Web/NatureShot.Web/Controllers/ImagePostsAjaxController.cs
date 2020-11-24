namespace NatureShot.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Encodings.Web;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NatureShot.Services.Data;
    using NatureShot.Services.Data.PhotoPosts;
    using NatureShot.Web.ViewModels.Images;

    [Route("api/[controller]")]
    [ApiController]
    public class ImagePostsAjaxController : BaseController
    {
        private readonly IPostsService postsService;
        private readonly HtmlEncoder encoder;
        private readonly IPhotoPostsNewest photoNewestService;
        private readonly IPhotoPostsOldest photoOldestService;
        private readonly IPhotoPostsLeastLikes photoLeastLikesService;
        private readonly IPhotoPostsMostLikes photoMostLikesService;
        private readonly IPhotoPostsMostDislikes photoMostDislikesService;
        private readonly IPhotoPostsLeastDislikes photoLeastDislikesService;

        public ImagePostsAjaxController(IPostsService postsService, HtmlEncoder encoder,
                                        IPhotoPostsNewest photoNewestService,
                                        IPhotoPostsOldest photoOldestService,
                                        IPhotoPostsLeastLikes photoLeastLikesService,
                                        IPhotoPostsMostLikes photoMostLikesService,
                                        IPhotoPostsMostDislikes photoMostDislikesService,
                                        IPhotoPostsLeastDislikes photoLeastDislikesService)
        {
            this.postsService = postsService;
            this.encoder = encoder;
            this.photoNewestService = photoNewestService;
            this.photoOldestService = photoOldestService;
            this.photoLeastLikesService = photoLeastLikesService;
            this.photoMostLikesService = photoMostLikesService;
            this.photoMostDislikesService = photoMostDislikesService;
            this.photoLeastDislikesService = photoLeastDislikesService;
        }

        [Authorize]
        [HttpGet("{page}")]
        public ICollection<ImagePostViewModel> LoadMoreImages(int page, string order)
        {
            var imageList = new List<ImagePostViewModel>();

            switch (order)
            {
                case "Date (Newest)":
                    imageList = this.photoNewestService.GetImagePostsNewest(page).ToList();
                    break;
                case "Date (Oldest)":
                    imageList = this.photoOldestService.GetImagePostsOldest(page).ToList();
                    break;
                case "Likes (Most)":
                    imageList = this.photoMostLikesService.GetImagePostsMostLikes(page).ToList();
                    break;
                case "Likes (Least)":
                    imageList = this.photoLeastLikesService.GetImagePostsLeastLikes(page).ToList();
                    break;
                case "Dislikes (Most)":
                    imageList = this.photoMostDislikesService.GetImagePostsMostDislikes(page).ToList();
                    break;
                case "Dislikes (Least)":
                    imageList = this.photoLeastDislikesService.GetImagePostsLeastDislikes(page).ToList();
                    break;
                default:
                    break;
            }

            foreach (var image in imageList)
            {
                image.Caption = this.encoder.Encode(image.Caption);
            }

            return imageList;
        }
    }
}
