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
        private readonly IReactionService reactionService;

        public PostsService(IDeletableEntityRepository<Post> postRepository,
                            IImagesService imagesService,
                            ICameraService cameraService,
                            ILocationsService locationsService,
                            ICountriesService countriesService,
                            ITagsService tagsService,
                            IReactionService reactionService)
        {
            this.imagesService = imagesService;
            this.postRepository = postRepository;
            this.cameraService = cameraService;
            this.locationsService = locationsService;
            this.countriesService = countriesService;
            this.tagsService = tagsService;
            this.reactionService = reactionService;
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

        public async Task DislikeAsync(int postId, string userId)
        {
            var reaction = this.reactionService.GetPostReact(postId, userId);
            var post = this.postRepository.All().FirstOrDefault(x => x.Id == postId);

            if (reaction == null)
            {
                await this.reactionService.CreateReact(postId, userId, false);
                post.Dislikes += 1;
                await this.postRepository.SaveChangesAsync();
            }
            else if (reaction.IsLiked == true)
            {
                post.Likes -= 1;
                post.Dislikes += 1;
                await this.reactionService.ChangeReactionAsync(postId, userId, "Dislike");
                await this.postRepository.SaveChangesAsync();
            }

        }

        public async Task LikeAsync(int postId, string userId)
        {
            var reaction = this.reactionService.GetPostReact(postId, userId);
            var post = this.postRepository.All().FirstOrDefault(x => x.Id == postId);

            if (reaction == null)
            {
                await this.reactionService.CreateReact(postId, userId, true);
                post.Likes += 1;
                await this.postRepository.SaveChangesAsync();
            }
            else if (reaction.IsLiked == false)
            {
                post.Likes += 1;
                post.Dislikes -= 1;
                await this.reactionService.ChangeReactionAsync(postId, userId, "Like");
                await this.postRepository.SaveChangesAsync();
            }
        }
    }
}
