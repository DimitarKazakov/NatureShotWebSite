namespace NatureShot.Services.Data.PhotoPosts.Contracts
{
    using System;
    using System.Collections.Generic;
    using NatureShot.Common;
    using NatureShot.Web.ViewModels.Images;

    public interface IPhotoPostsMostDislikes
    {
        IEnumerable<ImagePostViewModel> GetImagePostsMostDislikes(int page, int count = GlobalConstants.Pages);

        IEnumerable<ImagePostViewModel> SearchByCaption(int page, string input, int count = GlobalConstants.Pages);

        IEnumerable<ImagePostViewModel> SearchByUsername(int page, string input, int count = GlobalConstants.Pages);

        IEnumerable<ImagePostViewModel> SearchByTags(int page, string input, int count = GlobalConstants.Pages);

        IEnumerable<ImagePostViewModel> SearchByLocation(int page, string input, int count = GlobalConstants.Pages);

        IEnumerable<ImagePostViewModel> SearchByCamera(int page, string input, int count = GlobalConstants.Pages);

        IEnumerable<ImagePostViewModel> SearchByLikedPosts(int page, string input, int count = GlobalConstants.Pages);

        IEnumerable<ImagePostViewModel> SearchByDislikedPosts(int page, string input, int count = GlobalConstants.Pages);

        IEnumerable<ImagePostViewModel> SearchByCommentedPosts(int page, string input, int count = GlobalConstants.Pages);
    }
}
