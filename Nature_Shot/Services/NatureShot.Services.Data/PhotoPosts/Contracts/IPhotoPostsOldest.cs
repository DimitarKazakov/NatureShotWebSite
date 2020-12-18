namespace NatureShot.Services.Data.PhotoPosts.Contracts
{
    using System;
    using System.Collections.Generic;

    using NatureShot.Web.ViewModels.Images;

    public interface IPhotoPostsOldest
    {
        IEnumerable<ImagePostViewModel> GetImagePostsOldest(int page, int count = 4);

        IEnumerable<ImagePostViewModel> SearchByCaption(int page, string input, int count = 4);

        IEnumerable<ImagePostViewModel> SearchByUsername(int page, string input, int count = 4);

        IEnumerable<ImagePostViewModel> SearchByTags(int page, string input, int count = 4);

        IEnumerable<ImagePostViewModel> SearchByLocation(int page, string input, int count = 4);

        IEnumerable<ImagePostViewModel> SearchByCamera(int page, string input, int count = 4);

        IEnumerable<ImagePostViewModel> SearchByLikedPosts(int page, string input, int count = 4);

        IEnumerable<ImagePostViewModel> SearchByDislikedPosts(int page, string input, int count = 4);

        IEnumerable<ImagePostViewModel> SearchByCommentedPosts(int page, string input, int count = 4);
    }
}
