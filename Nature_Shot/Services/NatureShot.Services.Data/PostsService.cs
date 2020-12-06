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
    using NatureShot.Web.ViewModels.Videos;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postRepository;
        private readonly IImagesService imagesService;
        private readonly ICameraService cameraService;
        private readonly ILocationsService locationsService;
        private readonly ICountriesService countriesService;
        private readonly ITagsService tagsService;
        private readonly IReactionService reactionService;
        private readonly IVideosService videosService;
        private readonly IDeletableEntityRepository<PostType> postTypeRepository;
        private readonly IDeletableEntityRepository<PostTag> postTagsRepository;

        public PostsService(IDeletableEntityRepository<Post> postRepository,
                            IImagesService imagesService,
                            ICameraService cameraService,
                            ILocationsService locationsService,
                            ICountriesService countriesService,
                            ITagsService tagsService,
                            IReactionService reactionService,
                            IVideosService videosService,
                            IDeletableEntityRepository<PostType> postTypeRepository,
                            IDeletableEntityRepository<PostTag> postTagsRepository)

        {
            this.imagesService = imagesService;
            this.postRepository = postRepository;
            this.cameraService = cameraService;
            this.locationsService = locationsService;
            this.countriesService = countriesService;
            this.tagsService = tagsService;
            this.reactionService = reactionService;
            this.videosService = videosService;
            this.postTypeRepository = postTypeRepository;
            this.postTagsRepository = postTagsRepository;
        }

        public async Task CreateImagePostAsync(ImagePostInputModel input, string userId, ImageUploadResult imageInput)
        {
            var image = await this.imagesService.CreateImage(userId, imageInput);
            var camera = await this.cameraService.GetCameraByNameAsync(input.Camera);
            var country = await this.countriesService.GetCountry(input.Country);
            var location = await this.locationsService.GetLocation(input.Location, country);
            var postType = this.postTypeRepository.All().FirstOrDefault(x => x.Name == "Image");

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
            var postType = this.postTypeRepository.All().FirstOrDefault(x => x.Name == "Post");

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

        public async Task CreateVideoPostAsync(VideoPostInputModel input, string userId, VideoUploadResult videoInput)
        {
            var video = await this.videosService.CreateVideo(userId, videoInput);
            var camera = await this.cameraService.GetCameraByNameAsync(input.Camera);
            var country = await this.countriesService.GetCountry(input.Country);
            var location = await this.locationsService.GetLocation(input.Location, country);
            var postType = this.postTypeRepository.All().FirstOrDefault(x => x.Name == "Video");

            var post = new Post
            {
                AddedByUserId = userId,
                Camera = camera,
                Caption = input.Caption,
                Type = postType,
                Dislikes = 0,
                Likes = 0,
                Video = video,
                VideoId = video.Id,
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

        public async Task Delete(int postId)
        {
            var post = this.postRepository.All().FirstOrDefault(x => x.Id == postId);

            if (post != null)
            {
                this.postRepository.Delete(post);
                await this.postRepository.SaveChangesAsync();
            }
        }

        public bool CheckPostOwner(int postId, string userId)
        {
            return this.postRepository.AllAsNoTracking().Any(x => x.Id == postId && x.AddedByUserId == userId);
        }

        public async Task UpdateImage(ImagePostUpdateModel input)
        {
            var image = this.postRepository.All().FirstOrDefault(x => x.Id == input.PhotoId);
            if (image.Caption != input.Caption)
            {
                image.Caption = input.Caption;
            }

            image.Camera = await this.cameraService.GetCameraByNameAsync(input.Camera);
            var country = await this.countriesService.GetCountry(input.Country);
            image.Location = await this.locationsService.GetLocation(input.Location, country);
            var tags = await this.tagsService.GetTagsForPost(input.Tags);
            var postTags = this.postTagsRepository.All().Where(x => x.PostId == input.PhotoId);
            foreach (var tag in postTags)
            {
                this.postTagsRepository.Delete(tag);
            }

            await this.postTagsRepository.SaveChangesAsync();
            foreach (var tag in tags)
            {
                var postTag = new PostTag
                {
                    PostId = image.Id,
                    TagId = tag.Id,
                };

                image.Tags.Add(postTag);
            }

            await this.postRepository.SaveChangesAsync();
        }

        public async Task UpdateVideo(VideoPostUpdateModel input)
        {
            var video = this.postRepository.All().FirstOrDefault(x => x.Id == input.VideoId);
            if (video.Caption != input.Caption)
            {
                video.Caption = input.Caption;
            }

            video.Camera = await this.cameraService.GetCameraByNameAsync(input.Camera);
            var country = await this.countriesService.GetCountry(input.Country);
            video.Location = await this.locationsService.GetLocation(input.Location, country);
            var tags = await this.tagsService.GetTagsForPost(input.Tags);
            var postTags = this.postTagsRepository.All().Where(x => x.PostId == input.VideoId);
            foreach (var tag in postTags)
            {
                this.postTagsRepository.Delete(tag);
            }

            await this.postTagsRepository.SaveChangesAsync();
            foreach (var tag in tags)
            {
                var postTag = new PostTag
                {
                    PostId = video.Id,
                    TagId = tag.Id,
                };

                video.Tags.Add(postTag);
            }

            await this.postRepository.SaveChangesAsync();
        }

        public async Task UpdatePost(NormalPostUpdateModel input)
        {
            var normalPost = this.postRepository.All().FirstOrDefault(x => x.Id == input.NormalPostId);
            if (normalPost.Caption != input.Caption)
            {
                normalPost.Caption = input.Caption;
            }

            var tags = await this.tagsService.GetTagsForPost(input.Tags);
            var postTags = this.postTagsRepository.All().Where(x => x.PostId == input.NormalPostId);
            foreach (var tag in postTags)
            {
                this.postTagsRepository.Delete(tag);
            }

            await this.postTagsRepository.SaveChangesAsync();
            foreach (var tag in tags)
            {
                var postTag = new PostTag
                {
                    PostId = normalPost.Id,
                    TagId = tag.Id,
                };

                normalPost.Tags.Add(postTag);
            }

            await this.postRepository.SaveChangesAsync();
        }

        public ImagePostUpdateModel GetImagePost(int id)
        {
            var post = this.postRepository.AllAsNoTracking()
                                          .Where(x => x.Id == id)
                                          .Select(x => new ImagePostUpdateModel
                                          {
                                              Caption = x.Caption,
                                              Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                              PhotoUrl = x.Image.ImageUrl,
                                              PhotoId = x.Id,
                                              Camera = x.Camera.Model,
                                              Country = x.Location.Country.Name,
                                              Location = x.Location.Name.Split("/", StringSplitOptions.RemoveEmptyEntries)[0],
                                          }).FirstOrDefault();
            return post;
        }

        public VideoPostUpdateModel GetVideoPost(int id)
        {
            var post = this.postRepository.AllAsNoTracking()
                                          .Where(x => x.Id == id)
                                          .Select(x => new VideoPostUpdateModel
                                          {
                                              Caption = x.Caption,
                                              Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                              VideoUrl = x.Video.VideoUrl,
                                              VideoId = x.Id,
                                              Camera = x.Camera.Model,
                                              Country = x.Location.Country.Name,
                                              Location = x.Location.Name.Split("/", StringSplitOptions.RemoveEmptyEntries)[0],
                                          }).FirstOrDefault();

            return post;
        }

        public NormalPostUpdateModel GetNormalPost(int id)
        {
            var post = this.postRepository.AllAsNoTracking()
                                          .Where(x => x.Id == id)
                                          .Select(x => new NormalPostUpdateModel
                                          {
                                              Caption = x.Caption,
                                              Tags = string.Join(' ', x.Tags.Select(x => x.Tag.Name)),
                                              NormalPostId = x.Id,
                                          }).FirstOrDefault();

            return post;
        }
    }
}
