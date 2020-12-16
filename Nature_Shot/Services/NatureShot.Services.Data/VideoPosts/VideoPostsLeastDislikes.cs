﻿namespace NatureShot.Services.Data.VideoPosts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;
    using NatureShot.Web.ViewModels.Videos;

    public class VideoPostsLeastDislikes : IVideoPostsLeastDislikes
    {
        private readonly IDeletableEntityRepository<Post> postRepository;
        private readonly IRepository<PostReact> reactRepository;

        public VideoPostsLeastDislikes(IDeletableEntityRepository<Post> postRepository, IRepository<PostReact> reactRepository)
        {
            this.postRepository = postRepository;
            this.reactRepository = reactRepository;
        }

        public IEnumerable<VideoPostViewModel> GetVideoPostsLeastDislikes(int page, int count = 4)
        {
            var videoCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == "Video").Count();
            if (videoCount > (page * count) && videoCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Video")
                               .OrderBy(x => x.Dislikes)
                               .Skip(page * count)
                               .Take(videoCount - (count * page))
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString("dddd, dd MMMM yyyy"),
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
                               .OrderBy(x => x.Dislikes)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString("dddd, dd MMMM yyyy"),
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

        public IEnumerable<VideoPostViewModel> SearchByCamera(int page, string input, int count = 4)
        {
            var videoCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == "Video" && x.Camera.Model.ToLower().Contains(input.ToLower())).Count();
            if (videoCount > (page * count) && videoCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Video" && x.Camera.Model.ToLower().Contains(input.ToLower()))
                               .OrderBy(x => x.Dislikes)
                               .Skip(page * count)
                               .Take(videoCount - (count * page))
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString("dddd, dd MMMM yyyy"),
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
                               .OrderBy(x => x.Dislikes)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString("dddd, dd MMMM yyyy"),
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

        public IEnumerable<VideoPostViewModel> SearchByCaption(int page, string input, int count = 4)
        {
            var videoCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == "Video" && x.Caption.ToLower().Contains(input.ToLower())).Count();
            if (videoCount > (page * count) && videoCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Video" && x.Caption.ToLower().Contains(input.ToLower()))
                               .OrderBy(x => x.Dislikes)
                               .Skip(page * count)
                               .Take(videoCount - (count * page))
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString("dddd, dd MMMM yyyy"),
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
                               .OrderBy(x => x.Dislikes)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString("dddd, dd MMMM yyyy"),
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

        public IEnumerable<VideoPostViewModel> SearchByLocation(int page, string input, int count = 4)
        {
            var videoCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == "Video" && x.Location.Name.ToLower().Contains(input.ToLower())).Count();
            if (videoCount > (page * count) && videoCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Video" && x.Location.Name.ToLower().Contains(input.ToLower()))
                               .OrderBy(x => x.Dislikes)
                               .Skip(page * count)
                               .Take(videoCount - (count * page))
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString("dddd, dd MMMM yyyy"),
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
                               .OrderBy(x => x.Dislikes)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString("dddd, dd MMMM yyyy"),
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

        public IEnumerable<VideoPostViewModel> SearchByTags(int page, string input, int count = 4)
        {
            var videoCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == "Video" && x.Tags.Select(x => x.Tag.Name).Contains(input)).Count();
            if (videoCount > (page * count) && videoCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Video" && x.Tags.Select(x => x.Tag.Name).Contains(input))
                               .OrderBy(x => x.Dislikes)
                               .Skip(page * count)
                               .Take(videoCount - (count * page))
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString("dddd, dd MMMM yyyy"),
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
                               .OrderBy(x => x.Dislikes)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString("dddd, dd MMMM yyyy"),
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

        public IEnumerable<VideoPostViewModel> SearchByUsername(int page, string input, int count = 4)
        {
            var videoCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == "Video" && x.AddedByUser.UserName.ToLower().Contains(input.ToLower())).Count();
            if (videoCount > (page * count) && videoCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Video" && x.AddedByUser.UserName.ToLower().Contains(input.ToLower()))
                               .OrderBy(x => x.Dislikes)
                               .Skip(page * count)
                               .Take(videoCount - (count * page))
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString("dddd, dd MMMM yyyy"),
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
                               .OrderBy(x => x.Dislikes)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString("dddd, dd MMMM yyyy"),
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

        public IEnumerable<VideoPostViewModel> SearchByCommentedPosts(int page, string input, int count = 4)
        {
            var imageCount = this.postRepository.AllAsNoTracking().Where(x => x.Comments.Select(x => x.UserPosted.UserName).Contains(input) && x.Type.Name == "Video").Count();
            if (imageCount > (page * count) && imageCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Comments.Select(x => x.UserPosted.UserName).Contains(input) && x.Type.Name == "Video")
                               .OrderBy(x => x.Dislikes)
                               .Skip(page * count)
                               .Take(imageCount - (count * page))
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString("dddd, dd MMMM yyyy"),
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
            else if (imageCount >= (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Comments.Select(x => x.UserPosted.UserName).Contains(input) && x.Type.Name == "Video")
                               .OrderBy(x => x.Dislikes)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString("dddd, dd MMMM yyyy"),
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

        public IEnumerable<VideoPostViewModel> SearchByDislikedPosts(int page, string input, int count = 4)
        {
            var imageCount = this.reactRepository.AllAsNoTracking().Where(x => x.IsLiked == false && x.User.UserName.ToLower() == input.ToLower() && x.Post.Type.Name == "Video").Count();
            if (imageCount > (page * count) && imageCount < (page + 1) * count)
            {
                return this.reactRepository.AllAsNoTracking()
                               .Where(x => x.IsLiked == false && x.User.UserName.ToLower() == input.ToLower() && x.Post.Type.Name == "Video")
                               .OrderBy(x => x.Post.Dislikes)
                               .Skip(page * count)
                               .Take(imageCount - (count * page))
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.Post.CreatedOn.ToString("dddd, dd MMMM yyyy"),
                                   VideoId = x.PostId,
                                   Username = x.User.UserName,
                                   Tags = string.Join(' ', x.Post.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Post.Caption,
                                   Camera = x.Post.Camera.Model,
                                   VideoUrl = x.Post.Video.VideoUrl,
                                   Likes = x.Post.Likes,
                                   Dislikes = x.Post.Dislikes,
                                   Location = x.Post.Location.Name,
                                   Length = x.Post.Video.Length.ToString("c"),
                               }).ToList();
            }
            else if (imageCount >= (page + 1) * count)
            {
                return this.reactRepository.AllAsNoTracking()
                               .Where(x => x.IsLiked == false && x.User.UserName.ToLower() == input.ToLower() && x.Post.Type.Name == "Video")
                               .OrderBy(x => x.Post.Dislikes)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.Post.CreatedOn.ToString("dddd, dd MMMM yyyy"),
                                   VideoId = x.PostId,
                                   Username = x.User.UserName,
                                   Tags = string.Join(' ', x.Post.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Post.Caption,
                                   Camera = x.Post.Camera.Model,
                                   VideoUrl = x.Post.Video.VideoUrl,
                                   Likes = x.Post.Likes,
                                   Dislikes = x.Post.Dislikes,
                                   Location = x.Post.Location.Name,
                                   Length = x.Post.Video.Length.ToString("c"),
                               }).ToList();
            }
            else
            {
                return new List<VideoPostViewModel>();
            }
        }

        public IEnumerable<VideoPostViewModel> SearchByLikedPosts(int page, string input, int count = 4)
        {
            var imageCount = this.reactRepository.AllAsNoTracking().Where(x => x.IsLiked == true && x.User.UserName.ToLower() == input.ToLower() && x.Post.Type.Name == "Video").Count();
            if (imageCount > (page * count) && imageCount < (page + 1) * count)
            {
                return this.reactRepository.AllAsNoTracking()
                               .Where(x => x.IsLiked == true && x.User.UserName.ToLower() == input.ToLower() && x.Post.Type.Name == "Video")
                               .OrderBy(x => x.Post.Dislikes)
                               .Skip(page * count)
                               .Take(imageCount - (count * page))
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.Post.CreatedOn.ToString("dddd, dd MMMM yyyy"),
                                   VideoId = x.PostId,
                                   Username = x.User.UserName,
                                   Tags = string.Join(' ', x.Post.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Post.Caption,
                                   Camera = x.Post.Camera.Model,
                                   VideoUrl = x.Post.Video.VideoUrl,
                                   Likes = x.Post.Likes,
                                   Dislikes = x.Post.Dislikes,
                                   Location = x.Post.Location.Name,
                                   Length = x.Post.Video.Length.ToString("c"),
                               }).ToList();
            }
            else if (imageCount >= (page + 1) * count)
            {
                return this.reactRepository.AllAsNoTracking()
                               .Where(x => x.IsLiked == true && x.User.UserName.ToLower() == input.ToLower() && x.Post.Type.Name == "Video")
                               .OrderBy(x => x.Post.Dislikes)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new VideoPostViewModel
                               {
                                   DatePosted = x.Post.CreatedOn.ToString("dddd, dd MMMM yyyy"),
                                   VideoId = x.PostId,
                                   Username = x.User.UserName,
                                   Tags = string.Join(' ', x.Post.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Post.Caption,
                                   Camera = x.Post.Camera.Model,
                                   VideoUrl = x.Post.Video.VideoUrl,
                                   Likes = x.Post.Likes,
                                   Dislikes = x.Post.Dislikes,
                                   Location = x.Post.Location.Name,
                                   Length = x.Post.Video.Length.ToString("c"),
                               }).ToList();
            }
            else
            {
                return new List<VideoPostViewModel>();
            }
        }
    }
}
