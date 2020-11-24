namespace NatureShot.Services.Data.PhotoPosts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;
    using NatureShot.Web.ViewModels.Images;

    public class PhotoPostsLeastDislikes : IPhotoPostsLeastDislikes
    {
        private readonly IDeletableEntityRepository<Post> postRepository;

        public PhotoPostsLeastDislikes(IDeletableEntityRepository<Post> postRepository)
        {
            this.postRepository = postRepository;
        }

        public IEnumerable<ImagePostViewModel> GetImagePostsLeastDislikes(int page, int count = 10)
        {
            var imageCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == "Image").Count();
            if (imageCount > (page * count) && imageCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Image")
                               .OrderBy(x => x.Dislikes)
                               .Skip(page * count)
                               .Take(imageCount - (count * page))
                               .Select(x => new ImagePostViewModel
                               {
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   ImageUrl = x.Image.ImageUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Type = x.Image.Type.Name,
                               }).ToList();
            }
            else if (imageCount >= (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Image")
                               .OrderBy(x => x.Dislikes)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new ImagePostViewModel
                               {
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   ImageUrl = x.Image.ImageUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Type = x.Image.Type.Name,
                               }).ToList();
            }
            else
            {
                return new List<ImagePostViewModel>();
            }
        }

        public IEnumerable<ImagePostViewModel> SearchByCamera(int page, string input, int count = 10)
        {
            var imageCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == "Image" && x.Camera.Model.ToLower().Contains(input.ToLower())).Count();
            if (imageCount > (page * count) && imageCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Image" && x.Camera.Model.ToLower().Contains(input.ToLower()))
                               .OrderBy(x => x.Dislikes)
                               .Skip(page * count)
                               .Take(imageCount - (count * page))
                               .Select(x => new ImagePostViewModel
                               {
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   ImageUrl = x.Image.ImageUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Type = x.Image.Type.Name,
                               }).ToList();
            }
            else if (imageCount >= (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Image" && x.Camera.Model.ToLower().Contains(input.ToLower()))
                               .OrderBy(x => x.Dislikes)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new ImagePostViewModel
                               {
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   ImageUrl = x.Image.ImageUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Type = x.Image.Type.Name,
                               }).ToList();
            }
            else
            {
                return new List<ImagePostViewModel>();
            }
        }

        public IEnumerable<ImagePostViewModel> SearchByCaption(int page, string input, int count = 10)
        {
            var imageCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == "Image" && x.Caption.ToLower().Contains(input.ToLower())).Count();
            if (imageCount > (page * count) && imageCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Image" && x.Caption.ToLower().Contains(input.ToLower()))
                               .OrderBy(x => x.Dislikes)
                               .Skip(page * count)
                               .Take(imageCount - (count * page))
                               .Select(x => new ImagePostViewModel
                               {
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   ImageUrl = x.Image.ImageUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Type = x.Image.Type.Name,
                               }).ToList();
            }
            else if (imageCount >= (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Image" && x.Caption.ToLower().Contains(input.ToLower()))
                               .OrderBy(x => x.Dislikes)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new ImagePostViewModel
                               {
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   ImageUrl = x.Image.ImageUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Type = x.Image.Type.Name,
                               }).ToList();
            }
            else
            {
                return new List<ImagePostViewModel>();
            }
        }

        public IEnumerable<ImagePostViewModel> SearchByLocation(int page, string input, int count = 10)
        {
            var imageCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == "Image" && x.Location.Name.ToLower().Contains(input.ToLower())).Count();
            if (imageCount > (page * count) && imageCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Image" && x.Location.Name.ToLower().Contains(input.ToLower()))
                               .OrderBy(x => x.Dislikes)
                               .Skip(page * count)
                               .Take(imageCount - (count * page))
                               .Select(x => new ImagePostViewModel
                               {
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   ImageUrl = x.Image.ImageUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Type = x.Image.Type.Name,
                               }).ToList();
            }
            else if (imageCount >= (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Image" && x.Location.Name.ToLower().Contains(input.ToLower()))
                               .OrderBy(x => x.Dislikes)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new ImagePostViewModel
                               {
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   ImageUrl = x.Image.ImageUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Type = x.Image.Type.Name,
                               }).ToList();
            }
            else
            {
                return new List<ImagePostViewModel>();
            }
        }

        public IEnumerable<ImagePostViewModel> SearchByTags(int page, string input, int count = 10)
        {
            var imageCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == "Image" && x.Tags.Select(x => x.Tag.Name).Contains(input)).Count();
            if (imageCount > (page * count) && imageCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Image" && x.Tags.Select(x => x.Tag.Name).Contains(input))
                               .OrderBy(x => x.Dislikes)
                               .Skip(page * count)
                               .Take(imageCount - (count * page))
                               .Select(x => new ImagePostViewModel
                               {
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   ImageUrl = x.Image.ImageUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Type = x.Image.Type.Name,
                               }).ToList();
            }
            else if (imageCount >= (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Image" && x.Tags.Select(x => x.Tag.Name).Contains(input))
                               .OrderBy(x => x.Dislikes)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new ImagePostViewModel
                               {
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   ImageUrl = x.Image.ImageUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Type = x.Image.Type.Name,
                               }).ToList();
            }
            else
            {
                return new List<ImagePostViewModel>();
            }
        }

        public IEnumerable<ImagePostViewModel> SearchByUsername(int page, string input, int count = 10)
        {
            var imageCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == "Image" && x.AddedByUser.UserName.ToLower().Contains(input.ToLower())).Count();
            if (imageCount > (page * count) && imageCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Image" && x.AddedByUser.UserName.ToLower().Contains(input.ToLower()))
                               .OrderBy(x => x.Dislikes)
                               .Skip(page * count)
                               .Take(imageCount - (count * page))
                               .Select(x => new ImagePostViewModel
                               {
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   ImageUrl = x.Image.ImageUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Type = x.Image.Type.Name,
                               }).ToList();
            }
            else if (imageCount >= (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Image" && x.AddedByUser.UserName.ToLower().Contains(input.ToLower()))
                               .OrderBy(x => x.Dislikes)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new ImagePostViewModel
                               {
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Camera = x.Camera.Model,
                                   ImageUrl = x.Image.ImageUrl,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                                   Location = x.Location.Name,
                                   Type = x.Image.Type.Name,
                               }).ToList();
            }
            else
            {
                return new List<ImagePostViewModel>();
            }
        }
    }
}
