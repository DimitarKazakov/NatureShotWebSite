namespace NatureShot.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CloudinaryDotNet.Actions;
    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;
    using NatureShot.Web.ViewModels.Images;
    using NatureShot.Web.ViewModels.NormalPosts;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postRepository;
        private readonly IImagesService imagesService;
        private readonly ICameraService cameraService;
        private readonly ILocationsService locationsService;
        private readonly ICountriesService countriesService;
        private readonly ITagsService tagsService;

        public PostsService(IDeletableEntityRepository<Post> postRepository,
                            IImagesService imagesService,
                            ICameraService cameraService,
                            ILocationsService locationsService,
                            ICountriesService countriesService,
                            ITagsService tagsService)
        {
            this.imagesService = imagesService;
            this.postRepository = postRepository;
            this.cameraService = cameraService;
            this.locationsService = locationsService;
            this.countriesService = countriesService;
            this.tagsService = tagsService;
        }

        public async Task CreateImagePostAsync(ImagePostInputModel input, string userId, ImageUploadResult imageInput)
        {
            var image = await this.imagesService.CreateImage(userId, imageInput);
            var camera = await this.cameraService.GetCameraByNameAsync(input.Camera);
            var country = await this.countriesService.GetCountry(input.Country);
            var location = await this.locationsService.GetLocation(input.Location, country);
            var postType = new PostType
            {
                Name = "Image",
            };

            var post = new Post
            {
                AddedByUserId = userId,
                Camera = camera,
                Caption = input.Caption,
                Type = postType,
                Dislikes = 0,
                Likes = 0,
                Image = image,
                ImageId = image.Id,
                Location = location,
            };

            var tags = await this.tagsService.GetTagsForPost(input.Tags);
            foreach (var tag in tags)
            {

                post.Tags.Add(new PostTag
                {
                    Tag = tag,
                    Post = post,
                });
            }

            await this.postRepository.AddAsync(post);
            await this.postRepository.SaveChangesAsync();
        }

        public async Task CreateNormalPostAsync(NormalPostInputModel input, string userId)
        {
            var postType = new PostType
            {
                Name = "Post",
            };

            var post = new Post
            {
                AddedByUserId = userId,
                Caption = input.Caption,
                Type = postType,
                Dislikes = 0,
                Likes = 0,
            };

            var tags = await this.tagsService.GetTagsForPost(input.Tags);
            foreach (var tag in tags)
            {
                post.Tags.Add(new PostTag
                {
                    Tag = tag,
                    Post = post,
                });
            }

            await this.postRepository.AddAsync(post);
            await this.postRepository.SaveChangesAsync();
        }

        public IEnumerable<NormalPostViewModel> GetNormalPosts(int page, int count = 10)
        {
            var postsCount = this.postRepository.AllAsNoTracking().Where(x => x.Type.Name == "Post").Count();
            if (postsCount > (page * count) && postsCount < (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Post")
                               .OrderByDescending(x => x.CreatedOn)
                               .Skip(page * count)
                               .Take(postsCount - (count * page))
                               .Select(x => new NormalPostViewModel
                               {
                                   Username = x.AddedByUser.UserName,
                                   Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                   Caption = x.Caption,
                                   Likes = x.Likes,
                                   Dislikes = x.Dislikes,
                               }).ToList();
            }
            else if (postsCount >= (page + 1) * count)
            {
                return this.postRepository.AllAsNoTracking()
                               .Where(x => x.Type.Name == "Post")
                               .OrderByDescending(x => x.CreatedOn)
                               .Skip(page * count)
                               .Take(count)
                               .Select(x => new NormalPostViewModel
                               {
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
