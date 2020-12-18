namespace NatureShot.Services.Data.VideoPosts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;
    using NatureShot.Web.ViewModels.Videos;
    using NatureShot.Services.Data.VideoPosts.Contracts;
    using NatureShot.Common;

    public class VideoPostsShortest : IVideoPostsShortest
    {
        private readonly IDeletableEntityRepository<Post> postRepository;
        private readonly IRepository<PostReact> reactRepository;

        public VideoPostsShortest(IDeletableEntityRepository<Post> postRepository, IRepository<PostReact> reactRepository)
        {
            this.postRepository = postRepository;
            this.reactRepository = reactRepository;
        }

        public VideoPostsShortest(IDeletableEntityRepository<Post> postRepository)
        {
            this.postRepository = postRepository;
        }

        public IEnumerable<VideoPostViewModel> GetVideoPostsShortest(int page, int count = GlobalConstants.Pages)
        {
            var videoCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == GlobalConstants.Video).Count();
            if (videoCount > (page * count) && videoCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == GlobalConstants.Video)
                               .OrderBy(x => x.Video.Length)
                               .Skip(page * count)
                               .Take(videoCount - (count * page))
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString(GlobalConstants.DateTime),
                                   VideoId = x.Id,
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   VideoUrl = x.Video.VideoUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Length = x.Video.Length.ToString(GlobalConstants.TimeSpan),
                               }).ToList();
            }
            else if (videoCount >= (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == GlobalConstants.Video)
                               .OrderBy(x => x.Video.Length)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString(GlobalConstants.DateTime),
                                   VideoId = x.Id,
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   VideoUrl = x.Video.VideoUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Length = x.Video.Length.ToString(GlobalConstants.TimeSpan),
                               }).ToList();
            }
            else
            {
                return new List<VideoPostViewModel>();
            }
        }

        public IEnumerable<VideoPostViewModel> SearchByCamera(int page, string input, int count = GlobalConstants.Pages)
        {
            var videoCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == GlobalConstants.Video && x.Camera.Model.ToLower().Contains(input.ToLower())).Count();
            if (videoCount > (page * count) && videoCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == GlobalConstants.Video && x.Camera.Model.ToLower().Contains(input.ToLower()))
                               .OrderBy(x => x.Video.Length)
                               .Skip(page * count)
                               .Take(videoCount - (count * page))
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString(GlobalConstants.DateTime),
                                   VideoId = x.Id,
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   VideoUrl = x.Video.VideoUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Length = x.Video.Length.ToString(GlobalConstants.TimeSpan),
                               }).ToList();
            }
            else if (videoCount >= (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == GlobalConstants.Video && x.Camera.Model.ToLower().Contains(input.ToLower()))
                               .OrderBy(x => x.Video.Length)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString(GlobalConstants.DateTime),
                                   VideoId = x.Id,
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   VideoUrl = x.Video.VideoUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Length = x.Video.Length.ToString(GlobalConstants.TimeSpan),
                               }).ToList();
            }
            else
            {
                return new List<VideoPostViewModel>();
            }
        }

        public IEnumerable<VideoPostViewModel> SearchByCaption(int page, string input, int count = GlobalConstants.Pages)
        {
            var videoCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == GlobalConstants.Video && x.Caption.ToLower().Contains(input.ToLower())).Count();
            if (videoCount > (page * count) && videoCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == GlobalConstants.Video && x.Caption.ToLower().Contains(input.ToLower()))
                               .OrderBy(x => x.Video.Length)
                               .Skip(page * count)
                               .Take(videoCount - (count * page))
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString(GlobalConstants.DateTime),
                                   VideoId = x.Id,
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   VideoUrl = x.Video.VideoUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Length = x.Video.Length.ToString(GlobalConstants.TimeSpan),
                               }).ToList();
            }
            else if (videoCount >= (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == GlobalConstants.Video && x.Caption.ToLower().Contains(input.ToLower()))
                               .OrderBy(x => x.Video.Length)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString(GlobalConstants.DateTime),
                                   VideoId = x.Id,
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   VideoUrl = x.Video.VideoUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Length = x.Video.Length.ToString(GlobalConstants.TimeSpan),
                               }).ToList();
            }
            else
            {
                return new List<VideoPostViewModel>();
            }
        }

        public IEnumerable<VideoPostViewModel> SearchByLocation(int page, string input, int count = GlobalConstants.Pages)
        {
            var videoCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == GlobalConstants.Video && x.Location.Name.ToLower().Contains(input.ToLower())).Count();
            if (videoCount > (page * count) && videoCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == GlobalConstants.Video && x.Location.Name.ToLower().Contains(input.ToLower()))
                               .OrderBy(x => x.Video.Length)
                               .Skip(page * count)
                               .Take(videoCount - (count * page))
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString(GlobalConstants.DateTime),
                                   VideoId = x.Id,
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   VideoUrl = x.Video.VideoUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Length = x.Video.Length.ToString(GlobalConstants.TimeSpan),
                               }).ToList();
            }
            else if (videoCount >= (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == GlobalConstants.Video && x.Location.Name.ToLower().Contains(input.ToLower()))
                               .OrderBy(x => x.Video.Length)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString(GlobalConstants.DateTime),
                                   VideoId = x.Id,
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   VideoUrl = x.Video.VideoUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Length = x.Video.Length.ToString(GlobalConstants.TimeSpan),
                               }).ToList();
            }
            else
            {
                return new List<VideoPostViewModel>();
            }
        }

        public IEnumerable<VideoPostViewModel> SearchByTags(int page, string input, int count = GlobalConstants.Pages)
        {
            var videoCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == GlobalConstants.Video && x.Tags.Select(x => x.Tag.Name).Contains(input)).Count();
            if (videoCount > (page * count) && videoCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == GlobalConstants.Video && x.Tags.Select(x => x.Tag.Name).Contains(input))
                               .OrderBy(x => x.Video.Length)
                               .Skip(page * count)
                               .Take(videoCount - (count * page))
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString(GlobalConstants.DateTime),
                                   VideoId = x.Id,
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   VideoUrl = x.Video.VideoUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Length = x.Video.Length.ToString(GlobalConstants.TimeSpan),
                               }).ToList();
            }
            else if (videoCount >= (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == GlobalConstants.Video && x.Tags.Select(x => x.Tag.Name).Contains(input))
                               .OrderBy(x => x.Video.Length)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString(GlobalConstants.DateTime),
                                   VideoId = x.Id,
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   VideoUrl = x.Video.VideoUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Length = x.Video.Length.ToString(GlobalConstants.TimeSpan),
                               }).ToList();
            }
            else
            {
                return new List<VideoPostViewModel>();
            }
        }

        public IEnumerable<VideoPostViewModel> SearchByUsername(int page, string input, int count = GlobalConstants.Pages)
        {
            var videoCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == GlobalConstants.Video && x.AddedByUser.UserName.ToLower().Contains(input.ToLower())).Count();
            if (videoCount > (page * count) && videoCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == GlobalConstants.Video && x.AddedByUser.UserName.ToLower().Contains(input.ToLower()))
                               .OrderBy(x => x.Video.Length)
                               .Skip(page * count)
                               .Take(videoCount - (count * page))
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString(GlobalConstants.DateTime),
                                   VideoId = x.Id,
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   VideoUrl = x.Video.VideoUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Length = x.Video.Length.ToString(GlobalConstants.TimeSpan),
                               }).ToList();
            }
            else if (videoCount >= (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == GlobalConstants.Video && x.AddedByUser.UserName.ToLower().Contains(input.ToLower()))
                               .OrderBy(x => x.Video.Length)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString(GlobalConstants.DateTime),
                                   VideoId = x.Id,
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   VideoUrl = x.Video.VideoUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Length = x.Video.Length.ToString(GlobalConstants.TimeSpan),
                               }).ToList();
            }
            else
            {
                return new List<VideoPostViewModel>();
            }
        }

        public IEnumerable<VideoPostViewModel> SearchByCommentedPosts(int page, string input, int count = GlobalConstants.Pages)
        {
            var imageCount = this.postRepository.AllAsNoTracking().Where(x => x.Comments.Select(x => x.UserPosted.UserName).Contains(input) && x.Type.Name == GlobalConstants.Video).Count();
            if (imageCount > (page * count) && imageCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Comments.Select(x => x.UserPosted.UserName).Contains(input) && x.Type.Name == GlobalConstants.Video)
                               .OrderBy(x => x.Video.Length)
                               .Skip(page * count)
                               .Take(imageCount - (count * page))
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString(GlobalConstants.DateTime),
                                   VideoId = x.Id,
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   VideoUrl = x.Video.VideoUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Length = x.Video.Length.ToString(GlobalConstants.TimeSpan),
                               }).ToList();
            }
            else if (imageCount >= (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Comments.Select(x => x.UserPosted.UserName).Contains(input) && x.Type.Name == GlobalConstants.Video)
                               .OrderBy(x => x.Video.Length)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString(GlobalConstants.DateTime),
                                   VideoId = x.Id,
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   VideoUrl = x.Video.VideoUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Length = x.Video.Length.ToString(GlobalConstants.TimeSpan),
                               }).ToList();
            }
            else
            {
                return new List<VideoPostViewModel>();
            }
        }

        public IEnumerable<VideoPostViewModel> SearchByDislikedPosts(int page, string input, int count = GlobalConstants.Pages)
        {
            var imageCount = this.reactRepository.AllAsNoTracking().Where(x => x.IsLiked == false && x.User.UserName.ToLower() == input.ToLower() && x.Post.Type.Name == GlobalConstants.Video).Count();
            if (imageCount > (page * count) && imageCount < (page + 1) * count)
            {
                return this.reactRepository.AllAsNoTracking()
                               .Where(x => x.IsLiked == false && x.User.UserName.ToLower() == input.ToLower() && x.Post.Type.Name == GlobalConstants.Video)
                               .OrderBy(x => x.Post.Video.Length)
                               .Skip(page * count)
                               .Take(imageCount - (count * page))
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.Post.CreatedOn.ToString(GlobalConstants.DateTime),
                                   VideoId = x.PostId,
                                   Username = x.Post.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Post.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Post.Caption,
                                   Camera = x.Post.Camera.Model,
                                   VideoUrl = x.Post.Video.VideoUrl,
                                   Likes = x.Post.Likes,
                                   Dislikes = x.Post.Dislikes,
                                   Location = x.Post.Location.Name,
                                   Length = x.Post.Video.Length.ToString(GlobalConstants.TimeSpan),
                               }).ToList();
            }
            else if (imageCount >= (page + 1) * count)
            {
                return this.reactRepository.AllAsNoTracking()
                               .Where(x => x.IsLiked == false && x.User.UserName.ToLower() == input.ToLower() && x.Post.Type.Name == GlobalConstants.Video)
                               .OrderBy(x => x.Post.Video.Length)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.Post.CreatedOn.ToString(GlobalConstants.DateTime),
                                   VideoId = x.PostId,
                                   Username = x.Post.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Post.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Post.Caption,
                                   Camera = x.Post.Camera.Model,
                                   VideoUrl = x.Post.Video.VideoUrl,
                                   Likes = x.Post.Likes,
                                   Dislikes = x.Post.Dislikes,
                                   Location = x.Post.Location.Name,
                                   Length = x.Post.Video.Length.ToString(GlobalConstants.TimeSpan),
                               }).ToList();
            }
            else
            {
                return new List<VideoPostViewModel>();
            }
        }

        public IEnumerable<VideoPostViewModel> SearchByLikedPosts(int page, string input, int count = GlobalConstants.Pages)
        {
            var imageCount = this.reactRepository.AllAsNoTracking().Where(x => x.IsLiked == true && x.User.UserName.ToLower() == input.ToLower() && x.Post.Type.Name == GlobalConstants.Video).Count();
            if (imageCount > (page * count) && imageCount < (page + 1) * count)
            {
                return this.reactRepository.AllAsNoTracking()
                               .Where(x => x.IsLiked == true && x.User.UserName.ToLower() == input.ToLower() && x.Post.Type.Name == GlobalConstants.Video)
                               .OrderBy(x => x.Post.Video.Length)
                               .Skip(page * count)
                               .Take(imageCount - (count * page))
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.Post.CreatedOn.ToString(GlobalConstants.DateTime),
                                   VideoId = x.PostId,
                                   Username = x.Post.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Post.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Post.Caption,
                                   Camera = x.Post.Camera.Model,
                                   VideoUrl = x.Post.Video.VideoUrl,
                                   Likes = x.Post.Likes,
                                   Dislikes = x.Post.Dislikes,
                                   Location = x.Post.Location.Name,
                                   Length = x.Post.Video.Length.ToString(GlobalConstants.TimeSpan),
                               }).ToList();
            }
            else if (imageCount >= (page + 1) * count)
            {
                return this.reactRepository.AllAsNoTracking()
                               .Where(x => x.IsLiked == true && x.User.UserName.ToLower() == input.ToLower() && x.Post.Type.Name == GlobalConstants.Video)
                               .OrderBy(x => x.Post.Video.Length)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.Post.CreatedOn.ToString(GlobalConstants.DateTime),
                                   VideoId = x.PostId,
                                   Username = x.Post.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Post.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Post.Caption,
                                   Camera = x.Post.Camera.Model,
                                   VideoUrl = x.Post.Video.VideoUrl,
                                   Likes = x.Post.Likes,
                                   Dislikes = x.Post.Dislikes,
                                   Location = x.Post.Location.Name,
                                   Length = x.Post.Video.Length.ToString(GlobalConstants.TimeSpan),
                               }).ToList();
            }
            else
            {
                return new List<VideoPostViewModel>();
            }
        }
    }
}
