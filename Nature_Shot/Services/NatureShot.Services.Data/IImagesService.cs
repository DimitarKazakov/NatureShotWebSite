namespace NatureShot.Services.Data
{
    using System;
    using System.Threading.Tasks;
    using CloudinaryDotNet.Actions;

    using NatureShot.Web.ViewModels.Images;

    public interface IImagesService
    {
        Task CreateImagePostAsync(ImagePostInputModel input, string userId, ImageUploadResult image);
    }
}
