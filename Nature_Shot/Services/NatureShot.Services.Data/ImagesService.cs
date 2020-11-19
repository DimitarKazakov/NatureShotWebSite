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

    public class ImagesService : IImagesService
    {
        private readonly IDeletableEntityRepository<Image> imageRepository;
        private readonly IDeletableEntityRepository<Post> postRepository;
        private readonly IDeletableEntityRepository<Camera> cameraRepository;
        private readonly IRepository<Location> locationRepository;
        private readonly IDeletableEntityRepository<Country> countryRepository;
        private readonly IDeletableEntityRepository<Tag> tagsRepository;

        public ImagesService(IDeletableEntityRepository<Image> imageRepository,
                             IDeletableEntityRepository<Post> postRepository,
                             IDeletableEntityRepository<Camera> cameraRepository,
                             IRepository<Location> locationRepository,
                             IDeletableEntityRepository<Country> countryRepository,
                             IDeletableEntityRepository<Tag> tagsRepository)
        {
            this.imageRepository = imageRepository;
            this.postRepository = postRepository;
            this.cameraRepository = cameraRepository;
            this.locationRepository = locationRepository;
            this.countryRepository = countryRepository;
            this.tagsRepository = tagsRepository;
        }

        public async Task CreateImagePostAsync(ImagePostInputModel input, string userId, ImageUploadResult image)
        {
            var type = new ImageType
            {
                Name = "horizontal",
            };

            if (image.Width < image.Height)
            {
                type.Name = "vertical";
            }
            else if (image.Width < 800 && image.Height < 800)
            {
                type.Name = "small horizontal";
            }

            var imagePost = new Image
            {
                AddedByUserId = userId,
                Extension = image.Format,
                ImageUrl = image.Url.AbsoluteUri,
                Type = type,
            };

            await this.imageRepository.AddAsync(imagePost);
            await this.imageRepository.SaveChangesAsync();

            var camera = this.cameraRepository.All().FirstOrDefault(x => x.Model == input.Camera);
            if (camera == null)
            {
                camera = new Camera
                {
                    Model = input.Camera,
                };

                await this.cameraRepository.AddAsync(camera);
                await this.cameraRepository.SaveChangesAsync();
            }

            var country = this.countryRepository.All().FirstOrDefault(x => x.Name == input.Country);
            if (country == null)
            {
                country = new Country
                {
                    Name = input.Country,
                };

                await this.countryRepository.AddAsync(country);
                await this.countryRepository.SaveChangesAsync();
            }

            var location = this.locationRepository.All().FirstOrDefault(x => x.Name == input.Location + "/" + input.Country);
            if (location == null)
            {
                location = new Location
                {
                    Name = input.Location + "/" + input.Country,
                    Country = country,
                };

                await this.locationRepository.AddAsync(location);
                await this.locationRepository.SaveChangesAsync();
            }

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
                Image = imagePost,
                ImageId = imagePost.Id,
                Location = location,
            };

            var tagsFromDb = this.tagsRepository.All().ToList();
            var tagsInput = input.Tags.Split(' ');

            foreach (var tagInput in tagsInput)
            {
                var tag = new Tag
                {
                    Name = tagInput,
                };

                await this.tagsRepository.AddAsync(tag);
                post.Tags.Add(new PostTag
                {
                    Tag = tag,
                    Post = post,
                });

                if (!tagsFromDb.Contains(tag))
                {
                    await this.tagsRepository.AddAsync(tag);
                }
            }

            await this.tagsRepository.SaveChangesAsync();
            await this.postRepository.AddAsync(post);
            await this.postRepository.SaveChangesAsync();
        }
    }
}
