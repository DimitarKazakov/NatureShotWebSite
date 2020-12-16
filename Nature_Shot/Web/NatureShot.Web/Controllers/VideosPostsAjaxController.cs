namespace NatureShot.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Encodings.Web;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NatureShot.Services.Data;
    using NatureShot.Services.Data.VideoPosts;
    using NatureShot.Web.ViewModels.Videos;

    [Route("api/[controller]")]
    [ApiController]
    public class VideosPostsAjaxController : BaseController
    {
        private readonly IPostsService postsService;
        private readonly HtmlEncoder encoder;
        private readonly IVideoPostsNewest videoNewestService;
        private readonly IVideoPostsOldest videoOldestService;
        private readonly IVideoPostsLeastLikes videoLeastLikesService;
        private readonly IVideoPostsMostLikes videoMostLikesService;
        private readonly IVideoPostsMostDislikes videoMostDislikesService;
        private readonly IVideoPostsLeastDislikes videoLeastDislikesService;
        private readonly IVideoPostsLongest videoLongestService;
        private readonly IVideoPostsShortest videoShortestService;

        public VideosPostsAjaxController(IPostsService postsService, HtmlEncoder encoder,
                                         IVideoPostsNewest videoNewestService,
                                         IVideoPostsOldest videoOldestService,
                                         IVideoPostsLeastLikes videoLeastLikesService,
                                         IVideoPostsMostLikes videoMostLikesService,
                                         IVideoPostsMostDislikes videoMostDislikesService,
                                         IVideoPostsLeastDislikes videoLeastDislikesService,
                                         IVideoPostsLongest videoLongestService,
                                         IVideoPostsShortest videoShortestService)
        {
            this.postsService = postsService;
            this.encoder = encoder;
            this.videoNewestService = videoNewestService;
            this.videoOldestService = videoOldestService;
            this.videoLeastLikesService = videoLeastLikesService;
            this.videoMostLikesService = videoMostLikesService;
            this.videoMostDislikesService = videoMostDislikesService;
            this.videoLeastDislikesService = videoLeastDislikesService;
            this.videoLongestService = videoLongestService;
            this.videoShortestService = videoShortestService;
        }

        [Authorize]
        [HttpGet("{page}")]
        public ICollection<VideoPostViewModel> LoadMoreVideos(int page, string order, string searchBy, string searchInput)
        {
            var videoList = new List<VideoPostViewModel>();

            switch (order)
            {
                case "Date (Newest)":
                    switch (searchBy)
                    {
                        case "Name":
                            videoList = this.videoNewestService.SearchByUsername(page, searchInput).ToList();
                            break;
                        case "Tag":
                            videoList = this.videoNewestService.SearchByTags(page, searchInput).ToList();
                            break;
                        case "Location":
                            videoList = this.videoNewestService.SearchByLocation(page, searchInput).ToList();
                            break;
                        case "Camera":
                            videoList = this.videoNewestService.SearchByCamera(page, searchInput).ToList();
                            break;
                        case "Caption":
                            videoList = this.videoNewestService.SearchByCaption(page, searchInput).ToList();
                            break;
                        case "Liked":
                            videoList = this.videoNewestService.SearchByLikedPosts(0, searchInput).ToList();
                            break;
                        case "Disliked":
                            videoList = this.videoNewestService.SearchByDislikedPosts(0, searchInput).ToList();
                            break;
                        case "Commented":
                            videoList = this.videoNewestService.SearchByCommentedPosts(0, searchInput).ToList();
                            break;
                        default:
                            videoList = this.videoNewestService.GetVideoPostsNewest(page).ToList();
                            break;
                    }

                    break;
                case "Date (Oldest)":
                    switch (searchBy)
                    {
                        case "Name":
                            videoList = this.videoOldestService.SearchByUsername(page, searchInput).ToList();
                            break;
                        case "Tag":
                            videoList = this.videoOldestService.SearchByTags(page, searchInput).ToList();
                            break;
                        case "Location":
                            videoList = this.videoOldestService.SearchByLocation(page, searchInput).ToList();
                            break;
                        case "Camera":
                            videoList = this.videoOldestService.SearchByCamera(page, searchInput).ToList();
                            break;
                        case "Caption":
                            videoList = this.videoOldestService.SearchByCaption(page, searchInput).ToList();
                            break;
                        case "Liked":
                            videoList = this.videoOldestService.SearchByLikedPosts(0, searchInput).ToList();
                            break;
                        case "Disliked":
                            videoList = this.videoOldestService.SearchByDislikedPosts(0, searchInput).ToList();
                            break;
                        case "Commented":
                            videoList = this.videoOldestService.SearchByCommentedPosts(0, searchInput).ToList();
                            break;
                        default:
                            videoList = this.videoOldestService.GetVideoPostsOldest(page).ToList();
                            break;
                    }

                    break;
                case "Likes (Most)":
                    switch (searchBy)
                    {
                        case "Name":
                            videoList = this.videoMostLikesService.SearchByUsername(page, searchInput).ToList();
                            break;
                        case "Tag":
                            videoList = this.videoMostLikesService.SearchByTags(page, searchInput).ToList();
                            break;
                        case "Location":
                            videoList = this.videoMostLikesService.SearchByLocation(page, searchInput).ToList();
                            break;
                        case "Camera":
                            videoList = this.videoMostLikesService.SearchByCamera(page, searchInput).ToList();
                            break;
                        case "Caption":
                            videoList = this.videoMostLikesService.SearchByCaption(page, searchInput).ToList();
                            break;
                        case "Liked":
                            videoList = this.videoMostLikesService.SearchByLikedPosts(0, searchInput).ToList();
                            break;
                        case "Disliked":
                            videoList = this.videoMostLikesService.SearchByDislikedPosts(0, searchInput).ToList();
                            break;
                        case "Commented":
                            videoList = this.videoMostLikesService.SearchByCommentedPosts(0, searchInput).ToList();
                            break;
                        default:
                            videoList = this.videoMostLikesService.GetVideoPostsMostLikes(page).ToList();
                            break;
                    }

                    break;
                case "Likes (Least)":
                    switch (searchBy)
                    {
                        case "Name":
                            videoList = this.videoLeastLikesService.SearchByUsername(page, searchInput).ToList();
                            break;
                        case "Tag":
                            videoList = this.videoLeastLikesService.SearchByTags(page, searchInput).ToList();
                            break;
                        case "Location":
                            videoList = this.videoLeastLikesService.SearchByLocation(page, searchInput).ToList();
                            break;
                        case "Camera":
                            videoList = this.videoLeastLikesService.SearchByCamera(page, searchInput).ToList();
                            break;
                        case "Caption":
                            videoList = this.videoLeastLikesService.SearchByCaption(page, searchInput).ToList();
                            break;
                        case "Liked":
                            videoList = this.videoLeastLikesService.SearchByLikedPosts(0, searchInput).ToList();
                            break;
                        case "Disliked":
                            videoList = this.videoLeastLikesService.SearchByDislikedPosts(0, searchInput).ToList();
                            break;
                        case "Commented":
                            videoList = this.videoLeastLikesService.SearchByCommentedPosts(0, searchInput).ToList();
                            break;
                        default:
                            videoList = this.videoLeastLikesService.GetVideoPostsLeastLikes(page).ToList();
                            break;
                    }

                    break;
                case "Dislikes (Most)":
                    switch (searchBy)
                    {
                        case "Name":
                            videoList = this.videoMostDislikesService.SearchByUsername(page, searchInput).ToList();
                            break;
                        case "Tag":
                            videoList = this.videoMostDislikesService.SearchByTags(page, searchInput).ToList();
                            break;
                        case "Location":
                            videoList = this.videoMostDislikesService.SearchByLocation(page, searchInput).ToList();
                            break;
                        case "Camera":
                            videoList = this.videoMostDislikesService.SearchByCamera(page, searchInput).ToList();
                            break;
                        case "Caption":
                            videoList = this.videoMostDislikesService.SearchByCaption(page, searchInput).ToList();
                            break;
                        case "Liked":
                            videoList = this.videoMostDislikesService.SearchByLikedPosts(0, searchInput).ToList();
                            break;
                        case "Disliked":
                            videoList = this.videoMostDislikesService.SearchByDislikedPosts(0, searchInput).ToList();
                            break;
                        case "Commented":
                            videoList = this.videoMostDislikesService.SearchByCommentedPosts(0, searchInput).ToList();
                            break;
                        default:
                            videoList = this.videoMostDislikesService.GetVideoPostsMostDislikes(page).ToList();
                            break;
                    }

                    break;
                case "Dislikes (Least)":
                    switch (searchBy)
                    {
                        case "Name":
                            videoList = this.videoLeastDislikesService.SearchByUsername(page, searchInput).ToList();
                            break;
                        case "Tag":
                            videoList = this.videoLeastDislikesService.SearchByTags(page, searchInput).ToList();
                            break;
                        case "Location":
                            videoList = this.videoLeastDislikesService.SearchByLocation(page, searchInput).ToList();
                            break;
                        case "Camera":
                            videoList = this.videoLeastDislikesService.SearchByCamera(page, searchInput).ToList();
                            break;
                        case "Caption":
                            videoList = this.videoLeastDislikesService.SearchByCaption(page, searchInput).ToList();
                            break;
                        case "Liked":
                            videoList = this.videoLeastDislikesService.SearchByLikedPosts(0, searchInput).ToList();
                            break;
                        case "Disliked":
                            videoList = this.videoLeastDislikesService.SearchByDislikedPosts(0, searchInput).ToList();
                            break;
                        case "Commented":
                            videoList = this.videoLeastDislikesService.SearchByCommentedPosts(0, searchInput).ToList();
                            break;
                        default:
                            videoList = this.videoLeastDislikesService.GetVideoPostsLeastDislikes(page).ToList();
                            break;
                    }

                    break;
                case "Length (Longest)":
                    switch (searchBy)
                    {
                        case "Name":
                            videoList = this.videoLongestService.SearchByUsername(page, searchInput).ToList();
                            break;
                        case "Tag":
                            videoList = this.videoLongestService.SearchByTags(page, searchInput).ToList();
                            break;
                        case "Location":
                            videoList = this.videoLongestService.SearchByLocation(page, searchInput).ToList();
                            break;
                        case "Camera":
                            videoList = this.videoLongestService.SearchByCamera(page, searchInput).ToList();
                            break;
                        case "Caption":
                            videoList = this.videoLongestService.SearchByCaption(page, searchInput).ToList();
                            break;
                        case "Liked":
                            videoList = this.videoLongestService.SearchByLikedPosts(0, searchInput).ToList();
                            break;
                        case "Disliked":
                            videoList = this.videoLongestService.SearchByDislikedPosts(0, searchInput).ToList();
                            break;
                        case "Commented":
                            videoList = this.videoLongestService.SearchByCommentedPosts(0, searchInput).ToList();
                            break;
                        default:
                            videoList = this.videoLongestService.GetVideoPostsLongest(page).ToList();
                            break;
                    }

                    break;
                case "Length (Shortest)":
                    switch (searchBy)
                    {
                        case "Name":
                            videoList = this.videoShortestService.SearchByUsername(page, searchInput).ToList();
                            break;
                        case "Tag":
                            videoList = this.videoShortestService.SearchByTags(page, searchInput).ToList();
                            break;
                        case "Location":
                            videoList = this.videoShortestService.SearchByLocation(page, searchInput).ToList();
                            break;
                        case "Camera":
                            videoList = this.videoShortestService.SearchByCamera(page, searchInput).ToList();
                            break;
                        case "Caption":
                            videoList = this.videoShortestService.SearchByCaption(page, searchInput).ToList();
                            break;
                        case "Liked":
                            videoList = this.videoShortestService.SearchByLikedPosts(0, searchInput).ToList();
                            break;
                        case "Disliked":
                            videoList = this.videoShortestService.SearchByDislikedPosts(0, searchInput).ToList();
                            break;
                        case "Commented":
                            videoList = this.videoShortestService.SearchByCommentedPosts(0, searchInput).ToList();
                            break;
                        default:
                            videoList = this.videoShortestService.GetVideoPostsShortest(page).ToList();
                            break;
                    }

                    break;
                default:
                    break;
            }

            foreach (var video in videoList)
            {
                if (this.User.Identity.Name == video.Username)
                {
                    video.UsersOwnPhoto = true;
                }

                video.Caption = this.encoder.Encode(video.Caption);
            }

            return videoList;
        }
    }
}
