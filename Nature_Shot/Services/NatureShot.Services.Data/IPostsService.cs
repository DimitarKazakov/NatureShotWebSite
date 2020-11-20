namespace NatureShot.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CloudinaryDotNet.Actions;

    using NatureShot.Web.ViewModels.Images;

    public interface IPostsService
    {
        Task CreateImagePostAsync(ImagePostInputModel input, string userId, ImageUploadResult image);

        IEnumerable<ImagePostViewModel> GetImagePosts(int page, int count = 10);
    }
}
