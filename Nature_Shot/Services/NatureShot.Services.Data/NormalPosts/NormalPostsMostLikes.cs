namespace NatureShot.Services.Data.NormalPosts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;
    using NatureShot.Web.ViewModels.NormalPosts;

    public class NormalPostsMostLikes : INormalPostsMostLikes
    {
        private readonly IDeletableEntityRepository<Post> postRepository;

        public NormalPostsMostLikes(IDeletableEntityRepository<Post> postRepository)
        {
            this.postRepository = postRepository;
        }

        public IEnumerable<NormalPostViewModel> GetNormalPostsMostLikes(int page, int count = 10)
        {
            var postCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == "Post").Count();
            if (postCount > (page * count) && postCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Post")
                               .OrderByDescending(x => x.Likes)
                               .Skip(page * count)
                               .Take(postCount - (count * page))
                               .Select(x => new NormalPostViewModel
                               {
                                   DatePosted = x.CreatedOn,
                                   PostId = x.Id.ToString(),
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                               }).ToList();
            }
            else if (postCount >= (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Post")
                               .OrderByDescending(x => x.Likes)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new NormalPostViewModel
                               {
                                   DatePosted = x.CreatedOn,
                                   PostId = x.Id.ToString(),
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                               }).ToList();
            }
            else
            {
                return new List<NormalPostViewModel>();
            }
        }

        public IEnumerable<NormalPostViewModel> SearchByCaption(int page, string input, int count = 10)
        {
            var postCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == "Post" && x.Caption.ToLower().Contains(input.ToLower())).Count();
            if (postCount > (page * count) && postCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Post" && x.Caption.ToLower().Contains(input.ToLower()))
                               .OrderByDescending(x => x.Likes)
                               .Skip(page * count)
                               .Take(postCount - (count * page))
                               .Select(x => new NormalPostViewModel
                               {
                                   DatePosted = x.CreatedOn,
                                   PostId = x.Id.ToString(),
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                               }).ToList();
            }
            else if (postCount >= (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Post" && x.Caption.ToLower().Contains(input.ToLower()))
                               .OrderByDescending(x => x.Likes)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new NormalPostViewModel
                               {
                                   DatePosted = x.CreatedOn,
                                   PostId = x.Id.ToString(),
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                               }).ToList();
            }
            else
            {
                return new List<NormalPostViewModel>();
            }
        }

        public IEnumerable<NormalPostViewModel> SearchByTags(int page, string input, int count = 10)
        {
            var postCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == "Post" && x.Tags.Select(x => x.Tag.Name).Contains(input)).Count();
            if (postCount > (page * count) && postCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Post" && x.Tags.Select(x => x.Tag.Name).Contains(input))
                               .OrderByDescending(x => x.Likes)
                               .Skip(page * count)
                               .Take(postCount - (count * page))
                               .Select(x => new NormalPostViewModel
                               {
                                   DatePosted = x.CreatedOn,
                                   PostId = x.Id.ToString(),
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                               }).ToList();
            }
            else if (postCount >= (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Post" && x.Tags.Select(x => x.Tag.Name).Contains(input))
                               .OrderByDescending(x => x.Likes)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new NormalPostViewModel
                               {
                                   DatePosted = x.CreatedOn,
                                   PostId = x.Id.ToString(),
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                               }).ToList();
            }
            else
            {
                return new List<NormalPostViewModel>();
            }
        }

        public IEnumerable<NormalPostViewModel> SearchByUsername(int page, string input, int count = 10)
        {
            var postCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == "Post" && x.AddedByUser.UserName.ToLower().Contains(input.ToLower())).Count();
            if (postCount > (page * count) && postCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Post" && x.AddedByUser.UserName.ToLower().Contains(input.ToLower()))
                               .OrderByDescending(x => x.Likes)
                               .Skip(page * count)
                               .Take(postCount - (count * page))
                               .Select(x => new NormalPostViewModel
                               {
                                   DatePosted = x.CreatedOn,
                                   PostId = x.Id.ToString(),
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                               }).ToList();
            }
            else if (postCount >= (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Post" && x.AddedByUser.UserName.ToLower().Contains(input.ToLower()))
                               .OrderByDescending(x => x.Likes)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new NormalPostViewModel
                               {
                                   DatePosted = x.CreatedOn,
                                   PostId = x.Id.ToString(),
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                               }).ToList();
            }
            else
            {
                return new List<NormalPostViewModel>();
            }
        }
    }
}
