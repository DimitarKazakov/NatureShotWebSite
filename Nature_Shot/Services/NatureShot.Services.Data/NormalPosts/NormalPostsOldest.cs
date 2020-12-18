namespace NatureShot.Services.Data.NormalPosts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;
    using NatureShot.Web.ViewModels.NormalPosts;
    using NatureShot.Services.Data.NormalPosts.Contracts;
    using NatureShot.Common;

    public class NormalPostsOldest : INormalPostsOldest
    {
        private readonly IDeletableEntityRepository<Post> postRepository;
        private readonly IRepository<PostReact> reactRepository;

        public NormalPostsOldest(IDeletableEntityRepository<Post> postRepository, IRepository<PostReact> reactRepository)
        {
            this.postRepository = postRepository;
            this.reactRepository = reactRepository;
        }

        public NormalPostsOldest(IDeletableEntityRepository<Post> postRepository)
        {
            this.postRepository = postRepository;
        }

        public IEnumerable<NormalPostViewModel> GetNormalPostsOldest(int page, int count = GlobalConstants.Pages)
        {
            var postCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == "Post").Count();
            if (postCount > (page * count) && postCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Post")
                               .OrderBy(x => x.CreatedOn)
                               .Skip(page * count)
                               .Take(postCount - (count * page))
                               .Select(x => new NormalPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString(GlobalConstants.DateTime),
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
                               .OrderBy(x => x.CreatedOn)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new NormalPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString(GlobalConstants.DateTime),
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

        public IEnumerable<NormalPostViewModel> SearchByCaption(int page, string input, int count = GlobalConstants.Pages)
        {
            var postCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == "Post" && x.Caption.ToLower().Contains(input.ToLower())).Count();
            if (postCount > (page * count) && postCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Post" && x.Caption.ToLower().Contains(input.ToLower()))
                               .OrderBy(x => x.CreatedOn)
                               .Skip(page * count)
                               .Take(postCount - (count * page))
                               .Select(x => new NormalPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString(GlobalConstants.DateTime),
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
                               .OrderBy(x => x.CreatedOn)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new NormalPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString(GlobalConstants.DateTime),
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

        public IEnumerable<NormalPostViewModel> SearchByTags(int page, string input, int count = GlobalConstants.Pages)
        {
            var postCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == "Post" && x.Tags.Select(x => x.Tag.Name).Contains(input)).Count();
            if (postCount > (page * count) && postCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Post" && x.Tags.Select(x => x.Tag.Name).Contains(input))
                               .OrderBy(x => x.CreatedOn)
                               .Skip(page * count)
                               .Take(postCount - (count * page))
                               .Select(x => new NormalPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString(GlobalConstants.DateTime),
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
                               .OrderBy(x => x.CreatedOn)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new NormalPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString(GlobalConstants.DateTime),
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

        public IEnumerable<NormalPostViewModel> SearchByUsername(int page, string input, int count = GlobalConstants.Pages)
        {
            var postCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == "Post" && x.AddedByUser.UserName.ToLower().Contains(input.ToLower())).Count();
            if (postCount > (page * count) && postCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Post" && x.AddedByUser.UserName.ToLower().Contains(input.ToLower()))
                               .OrderBy(x => x.CreatedOn)
                               .Skip(page * count)
                               .Take(postCount - (count * page))
                               .Select(x => new NormalPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString(GlobalConstants.DateTime),
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
                               .OrderBy(x => x.CreatedOn)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new NormalPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString(GlobalConstants.DateTime),
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

        public IEnumerable<NormalPostViewModel> SearchByCommentedPosts(int page, string input, int count = GlobalConstants.Pages)
        {
            var postCount = this.postRepository.AllAsNoTracking().Where(x => x.Comments.Select(x => x.UserPosted.UserName).Contains(input) && x.Type.Name == "Post").Count();
            if (postCount > (page * count) && postCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Comments.Select(x => x.UserPosted.UserName).Contains(input) && x.Type.Name == "Post")
                               .OrderBy(x => x.CreatedOn)
                               .Skip(page * count)
                               .Take(postCount - (count * page))
                               .Select(x => new NormalPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString(GlobalConstants.DateTime),
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
                               .Where(x => x.Comments.Select(x => x.UserPosted.UserName).Contains(input) && x.Type.Name == "Post")
                               .OrderBy(x => x.CreatedOn)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new NormalPostViewModel
                               {
                                   DatePosted = x.CreatedOn.ToString(GlobalConstants.DateTime),
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

        public IEnumerable<NormalPostViewModel> SearchByDislikedPosts(int page, string input, int count = GlobalConstants.Pages)
        {
            var postCount = this.reactRepository.AllAsNoTracking().Where(x => x.IsLiked == false && x.User.UserName.ToLower() == input.ToLower() && x.Post.Type.Name == "Post").Count();
            if (postCount > (page * count) && postCount < (page + 1) * count)
            {
                return this.reactRepository.AllAsNoTracking()
                               .Where(x => x.IsLiked == false && x.User.UserName.ToLower() == input.ToLower() && x.Post.Type.Name == "Post")
                               .OrderBy(x => x.Post.CreatedOn)
                               .Skip(page * count)
                               .Take(postCount - (count * page))
                               .Select(x => new NormalPostViewModel
                               {
                                   DatePosted = x.Post.CreatedOn.ToString(GlobalConstants.DateTime),
                                   PostId = x.PostId.ToString(),
                                   Username = x.User.UserName,
                                   Tags = string.Join(' ', x.Post.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Post.Caption,
                                   Likes = x.Post.Likes,
                                   Dislikes = x.Post.Dislikes,
                               }).ToList();
            }
            else if (postCount >= (page + 1) * count)
            {
                return this.reactRepository.AllAsNoTracking()
                               .Where(x => x.IsLiked == false && x.User.UserName.ToLower() == input.ToLower() && x.Post.Type.Name == "Post")
                               .OrderBy(x => x.Post.CreatedOn)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new NormalPostViewModel
                               {
                                   DatePosted = x.Post.CreatedOn.ToString(GlobalConstants.DateTime),
                                   PostId = x.PostId.ToString(),
                                   Username = x.User.UserName,
                                   Tags = string.Join(' ', x.Post.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Post.Caption,
                                   Likes = x.Post.Likes,
                                   Dislikes = x.Post.Dislikes,
                               }).ToList();
            }
            else
            {
                return new List<NormalPostViewModel>();
            }
        }

        public IEnumerable<NormalPostViewModel> SearchByLikedPosts(int page, string input, int count = GlobalConstants.Pages)
        {
            var postCount = this.reactRepository.AllAsNoTracking().Where(x => x.IsLiked == true && x.User.UserName.ToLower() == input.ToLower() && x.Post.Type.Name == "Post").Count();
            if (postCount > (page * count) && postCount < (page + 1) * count)
            {
                return this.reactRepository.AllAsNoTracking()
                               .Where(x => x.IsLiked == true && x.User.UserName.ToLower() == input.ToLower() && x.Post.Type.Name == "Post")
                               .OrderBy(x => x.Post.CreatedOn)
                               .Skip(page * count)
                               .Take(postCount - (count * page))
                               .Select(x => new NormalPostViewModel
                               {
                                   DatePosted = x.Post.CreatedOn.ToString(GlobalConstants.DateTime),
                                   PostId = x.PostId.ToString(),
                                   Username = x.User.UserName,
                                   Tags = string.Join(' ', x.Post.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Post.Caption,
                                   Likes = x.Post.Likes,
                                   Dislikes = x.Post.Dislikes,
                               }).ToList();
            }
            else if (postCount >= (page + 1) * count)
            {
                return this.reactRepository.AllAsNoTracking()
                               .Where(x => x.IsLiked == true && x.User.UserName.ToLower() == input.ToLower() && x.Post.Type.Name == "Post")
                               .OrderBy(x => x.Post.CreatedOn)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new NormalPostViewModel
                               {
                                   DatePosted = x.Post.CreatedOn.ToString(GlobalConstants.DateTime),
                                   PostId = x.PostId.ToString(),
                                   Username = x.User.UserName,
                                   Tags = string.Join(' ', x.Post.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Post.Caption,
                                   Likes = x.Post.Likes,
                                   Dislikes = x.Post.Dislikes,
                               }).ToList();
            }
            else
            {
                return new List<NormalPostViewModel>();
            }
        }
    }
}
