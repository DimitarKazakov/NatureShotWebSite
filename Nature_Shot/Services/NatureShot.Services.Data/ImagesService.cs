namespace NatureShot.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CloudinaryDotNet.Actions;
    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;

    public class ImagesService : IImagesService
    {
        private readonly IDeletableEntityRepository<Image> imageRepository;

        public ImagesService(IDeletableEntityRepository<Image> imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        public async Task<Image> CreateImage(string userId, ImageUploadResult imageInput)
        {
            var type = new ImageType
            {
                Name = "horizontal",
            };

            if (imageInput.Width < imageInput.Height)
            {
                type.Name = "vertical";
            }
            else if (imageInput.Width < 650 && imageInput.Height < 650)
            {
                type.Name = "small horizontal";
            }

            var image = new Image
            {
                AddedByUserId = userId,
                Extension = imageInput.Format,
                ImageUrl = imageInput.Url.AbsoluteUri,
                Type = type,
                IsProfilePicture = false,
            };

            await this.imageRepository.AddAsync(image);

            await this.imageRepository.SaveChangesAsync();
            return image;
        }

        public async Task<Image> CreateProfileImage(string userId, ImageUploadResult imageInput)
        {
            var type = new ImageType
            {
                Name = "horizontal",
            };

            var image = new Image
            {
                AddedByUserId = userId,
                Extension = imageInput.Format,
                ImageUrl = imageInput.Url.AbsoluteUri,
                Type = type,
                IsProfilePicture = true,
            };

            var previousProfilPic = this.imageRepository.All().FirstOrDefault(x => x.AddedByUserId == userId && x.IsProfilePicture == true);
            if (previousProfilPic != null)
            {
                previousProfilPic.IsProfilePicture = false;
                await this.imageRepository.SaveChangesAsync();
            }

            await this.imageRepository.AddAsync(image);

            await this.imageRepository.SaveChangesAsync();
            return image;
        }
    }
}
