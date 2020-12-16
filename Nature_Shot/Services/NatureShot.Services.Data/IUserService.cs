namespace NatureShot.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CloudinaryDotNet.Actions;
    using NatureShot.Web.ViewModels.User;

    public interface IUserService
    {
        IEnumerable<string> GetAllUserNames();

        UserProfileInputModel GetUserDataForUpdate(string id);

        UserProfileViewModel GetUserDataForProfile(string id);

        Task UpdateProfile(UserProfileInputModel input, ImageUploadResult imageInput = null);

        string GetUserId(string username);
    }
}
