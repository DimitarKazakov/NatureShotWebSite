namespace NatureShot.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CloudinaryDotNet.Actions;

    using NatureShot.Web.ViewModels.Images;
    using NatureShot.Web.ViewModels.NormalPosts;

    public interface IPostsService
    {
        Task CreateImagePostAsync(ImagePostInputModel input, string userId, ImageUploadResult image);

        Task CreateNormalPostAsync(NormalPostInputModel input, string userId);

        IEnumerable<NormalPostViewModel> GetNormalPosts(int page, int count = 10);
    }
}
