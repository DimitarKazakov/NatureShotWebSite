namespace NatureShot.Services.Data.PhotoPosts
{
    using System;
    using System.Collections.Generic;

    using NatureShot.Web.ViewModels.Images;

    public interface IPhotoPostsMostDislikes
    {
        IEnumerable<ImagePostViewModel> GetImagePostsMostDislikes(int page, int count = 5);

        IEnumerable<ImagePostViewModel> SearchByCaption(int page, string input, int count = 5);

        IEnumerable<ImagePostViewModel> SearchByUsername(int page, string input, int count = 5);

        IEnumerable<ImagePostViewModel> SearchByTags(int page, string input, int count = 5);

        IEnumerable<ImagePostViewModel> SearchByLocation(int page, string input, int count = 5);

        IEnumerable<ImagePostViewModel> SearchByCamera(int page, string input, int count = 5);
    }
}
