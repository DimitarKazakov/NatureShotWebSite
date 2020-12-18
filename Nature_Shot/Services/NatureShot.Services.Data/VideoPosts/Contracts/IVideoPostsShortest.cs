namespace NatureShot.Services.Data.VideoPosts.Contracts
{
    using System;
    using System.Collections.Generic;

    using NatureShot.Web.ViewModels.Videos;

    public interface IVideoPostsShortest
    {
        IEnumerable<VideoPostViewModel> GetVideoPostsShortest(int page, int count = 4);

        IEnumerable<VideoPostViewModel> SearchByCaption(int page, string input, int count = 4);

        IEnumerable<VideoPostViewModel> SearchByUsername(int page, string input, int count = 4);

        IEnumerable<VideoPostViewModel> SearchByTags(int page, string input, int count = 4);

        IEnumerable<VideoPostViewModel> SearchByLocation(int page, string input, int count = 4);

        IEnumerable<VideoPostViewModel> SearchByCamera(int page, string input, int count = 4);

        IEnumerable<VideoPostViewModel> SearchByLikedPosts(int page, string input, int count = 4);

        IEnumerable<VideoPostViewModel> SearchByDislikedPosts(int page, string input, int count = 4);

        IEnumerable<VideoPostViewModel> SearchByCommentedPosts(int page, string input, int count = 4);
    }
}
