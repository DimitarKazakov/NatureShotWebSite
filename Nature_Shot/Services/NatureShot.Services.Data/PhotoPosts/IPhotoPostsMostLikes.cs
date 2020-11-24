namespace NatureShot.Services.Data.PhotoPosts
{
    using System;
    using System.Collections.Generic;
    using NatureShot.Web.ViewModels.Images;

    public interface IPhotoPostsMostLikes
    {
        IEnumerable<ImagePostViewModel> GetImagePostsMostLikes(int page, int count = 10);

        IEnumerable<ImagePostViewModel> SearchByCaption(int page, string input, int count = 10);

        IEnumerable<ImagePostViewModel> SearchByUsername(int page, string input, int count = 10);

        IEnumerable<ImagePostViewModel> SearchByTags(int page, string input, int count = 10);

        IEnumerable<ImagePostViewModel> SearchByLocation(int page, string input, int count = 10);

        IEnumerable<ImagePostViewModel> SearchByCamera(int page, string input, int count = 10);
    }
}
