namespace NatureShot.Services.Data
{
    using System;
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
            };

            await this.imageRepository.AddAsync(image);
            await this.imageRepository.SaveChangesAsync();
            return image;
        }
    }
}
