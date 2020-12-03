namespace NatureShot.Services.Data.VideoPosts
{
    using System;
    using System.Collections.Generic;

    using NatureShot.Web.ViewModels.Videos;

    public interface IVideoPostsMostDislikes
    {
        IEnumerable<VideoPostViewModel> GetVideoPostsMostDislikes(int page, int count = 5);

        IEnumerable<VideoPostViewModel> SearchByCaption(int page, string input, int count = 5);

        IEnumerable<VideoPostViewModel> SearchByUsername(int page, string input, int count = 5);

        IEnumerable<VideoPostViewModel> SearchByTags(int page, string input, int count = 5);

        IEnumerable<VideoPostViewModel> SearchByLocation(int page, string input, int count = 5);

        IEnumerable<VideoPostViewModel> SearchByCamera(int page, string input, int count = 5);
    }
}
