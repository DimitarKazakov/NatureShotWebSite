namespace NatureShot.Services.Data.VideoPosts.Contracts
{
    using System;
    using System.Collections.Generic;
    using NatureShot.Common;
    using NatureShot.Web.ViewModels.Videos;

    public interface IVideoPostsNewest
    {
        IEnumerable<VideoPostViewModel> GetVideoPostsNewest(int page, int count = GlobalConstants.Pages);

        IEnumerable<VideoPostViewModel> SearchByCaption(int page, string input, int count = GlobalConstants.Pages);

        IEnumerable<VideoPostViewModel> SearchByUsername(int page, string input, int count = GlobalConstants.Pages);

        IEnumerable<VideoPostViewModel> SearchByTags(int page, string input, int count = GlobalConstants.Pages);

        IEnumerable<VideoPostViewModel> SearchByLocation(int page, string input, int count = GlobalConstants.Pages);

        IEnumerable<VideoPostViewModel> SearchByCamera(int page, string input, int count = GlobalConstants.Pages);

        IEnumerable<VideoPostViewModel> SearchByLikedPosts(int page, string input, int count = GlobalConstants.Pages);

        IEnumerable<VideoPostViewModel> SearchByDislikedPosts(int page, string input, int count = GlobalConstants.Pages);

        IEnumerable<VideoPostViewModel> SearchByCommentedPosts(int page, string input, int count = GlobalConstants.Pages);
    }
}
