namespace NatureShot.Services.Data.VideoPosts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;
    using NatureShot.Web.ViewModels.Videos;

    public class VideoPostsLeastLikes : IVideoPostsLeastLikes
    {
        private readonly IDeletableEntityRepository<Post> postRepository;

        public VideoPostsLeastLikes(IDeletableEntityRepository<Post> postRepository)
        {
            this.postRepository = postRepository;
        }

        public IEnumerable<VideoPostViewModel> GetVideoPostsLeastLikes(int page, int count = 5)
        {
            var videoCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == "Video").Count();
            if (videoCount > (page * count) && videoCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Video")
                               .OrderBy(x => x.Likes)
                               .Skip(page * count)
                               .Take(videoCount - (count * page))
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn,
                                   VideoId = x.Id,
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   VideoUrl = x.Video.VideoUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Length = x.Video.Length.ToString("c"),
                               }).ToList();
            }
            else if (videoCount >= (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Video")
                               .OrderBy(x => x.Likes)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn,
                                   VideoId = x.Id,
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   VideoUrl = x.Video.VideoUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Length = x.Video.Length.ToString("c"),
                               }).ToList();
            }
            else
            {
                return new List<VideoPostViewModel>();
            }
        }

        public IEnumerable<VideoPostViewModel> SearchByCamera(int page, string input, int count = 5)
        {
            var videoCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == "Video" && x.Camera.Model.ToLower().Contains(input.ToLower())).Count();
            if (videoCount > (page * count) && videoCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Video" && x.Camera.Model.ToLower().Contains(input.ToLower()))
                               .OrderBy(x => x.Likes)
                               .Skip(page * count)
                               .Take(videoCount - (count * page))
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn,
                                   VideoId = x.Id,
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   VideoUrl = x.Video.VideoUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Length = x.Video.Length.ToString("c"),
                               }).ToList();
            }
            else if (videoCount >= (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Video" && x.Camera.Model.ToLower().Contains(input.ToLower()))
                               .OrderBy(x => x.Likes)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn,
                                   VideoId = x.Id,
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   VideoUrl = x.Video.VideoUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Length = x.Video.Length.ToString("c"),
                               }).ToList();
            }
            else
            {
                return new List<VideoPostViewModel>();
            }
        }

        public IEnumerable<VideoPostViewModel> SearchByCaption(int page, string input, int count = 5)
        {
            var videoCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == "Video" && x.Caption.ToLower().Contains(input.ToLower())).Count();
            if (videoCount > (page * count) && videoCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Video" && x.Caption.ToLower().Contains(input.ToLower()))
                               .OrderBy(x => x.Likes)
                               .Skip(page * count)
                               .Take(videoCount - (count * page))
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn,
                                   VideoId = x.Id,
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   VideoUrl = x.Video.VideoUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Length = x.Video.Length.ToString("c"),
                               }).ToList();
            }
            else if (videoCount >= (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Video" && x.Caption.ToLower().Contains(input.ToLower()))
                               .OrderBy(x => x.Likes)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn,
                                   VideoId = x.Id,
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   VideoUrl = x.Video.VideoUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Length = x.Video.Length.ToString("c"),
                               }).ToList();
            }
            else
            {
                return new List<VideoPostViewModel>();
            }
        }

        public IEnumerable<VideoPostViewModel> SearchByLocation(int page, string input, int count = 5)
        {
            var videoCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == "Video" && x.Location.Name.ToLower().Contains(input.ToLower())).Count();
            if (videoCount > (page * count) && videoCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Video" && x.Location.Name.ToLower().Contains(input.ToLower()))
                               .OrderBy(x => x.Likes)
                               .Skip(page * count)
                               .Take(videoCount - (count * page))
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn,
                                   VideoId = x.Id,
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   VideoUrl = x.Video.VideoUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Length = x.Video.Length.ToString("c"),
                               }).ToList();
            }
            else if (videoCount >= (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Video" && x.Location.Name.ToLower().Contains(input.ToLower()))
                               .OrderBy(x => x.Likes)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn,
                                   VideoId = x.Id,
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   VideoUrl = x.Video.VideoUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Length = x.Video.Length.ToString("c"),
                               }).ToList();
            }
            else
            {
                return new List<VideoPostViewModel>();
            }
        }

        public IEnumerable<VideoPostViewModel> SearchByTags(int page, string input, int count = 5)
        {
            var videoCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == "Video" && x.Tags.Select(x => x.Tag.Name).Contains(input)).Count();
            if (videoCount > (page * count) && videoCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Video" && x.Tags.Select(x => x.Tag.Name).Contains(input))
                               .OrderBy(x => x.Likes)
                               .Skip(page * count)
                               .Take(videoCount - (count * page))
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn,
                                   VideoId = x.Id,
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   VideoUrl = x.Video.VideoUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Length = x.Video.Length.ToString("c"),
                               }).ToList();
            }
            else if (videoCount >= (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Video" && x.Tags.Select(x => x.Tag.Name).Contains(input))
                               .OrderBy(x => x.Likes)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn,
                                   VideoId = x.Id,
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   VideoUrl = x.Video.VideoUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Length = x.Video.Length.ToString("c"),
                               }).ToList();
            }
            else
            {
                return new List<VideoPostViewModel>();
            }
        }

        public IEnumerable<VideoPostViewModel> SearchByUsername(int page, string input, int count = 5)
        {
            var videoCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == "Video" && x.AddedByUser.UserName.ToLower().Contains(input.ToLower())).Count();
            if (videoCount > (page * count) && videoCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Video" && x.AddedByUser.UserName.ToLower().Contains(input.ToLower()))
                               .OrderBy(x => x.Likes)
                               .Skip(page * count)
                               .Take(videoCount - (count * page))
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn,
                                   VideoId = x.Id,
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   VideoUrl = x.Video.VideoUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Length = x.Video.Length.ToString("c"),
                               }).ToList();
            }
            else if (videoCount >= (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Video" && x.AddedByUser.UserName.ToLower().Contains(input.ToLower()))
                               .OrderBy(x => x.Likes)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn,
                                   VideoId = x.Id,
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   VideoUrl = x.Video.VideoUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Length = x.Video.Length.ToString("c"),
                               }).ToList();
            }
            else
            {
                return new List<VideoPostViewModel>();
            }
        }
    }
}
