namespace NatureShot.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using CloudinaryDotNet.Actions;
    using NatureShot.Data.Models;

    public interface IImagesService
    {
        Task<Image> CreateImage(string userId, ImageUploadResult imageInput);

        Task<Image> CreateProfileImage(string userId, ImageUploadResult imageInput);
    }
}
