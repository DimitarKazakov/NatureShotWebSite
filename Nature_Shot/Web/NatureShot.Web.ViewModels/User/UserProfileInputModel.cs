namespace NatureShot.Web.ViewModels.User
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using NatureShot.Common;
    using NatureShot.Web.ViewModels.CustomAttributes;

    public class UserProfileInputModel
    {
        public UserProfileInputModel()
        {
        }

        public string Id { get; set; }

        public string Username { get; set; }

        [AllowedExtensionsAttribute(new string[] { ".bmp", ".gif", ".jpeg", ".png", ".jpg", ".tif", ".tiff", ".svg", ".webp" })]
        public IFormFile ProfilePicture { get; set; }

        public string ProfilePictureUrl { get; set; }

        [MinLength(GlobalConstants.MinLengthSix, ErrorMessage = "Name should be at least 6 characters long.")]
        [MaxLength(GlobalConstants.MaxLengthFifty, ErrorMessage = "Name should be less than 50 characters")]
        [RegularExpression(@"^[a-zA-Z0-9_\-. ]+$", ErrorMessage = "Name field can contain only letters, numbers and _-. ")]
        public string Name { get; set; }

        [MinLength(GlobalConstants.MinLengthSix, ErrorMessage = "Proffesion should be at least 6 characters long.")]
        [MaxLength(GlobalConstants.MaxLengthFifty, ErrorMessage = "Proffesion should be less than 50 characters")]
        [RegularExpression(@"^[a-zA-Z0-9_\-. #!]+$", ErrorMessage = "Proffesion field can contain only letters, numbers and _-. #")]
        public string Proffesion { get; set; }

        [MinLength(GlobalConstants.MinLengthSix, ErrorMessage = "Live in should be at least 6 characters long.")]
        [MaxLength(GlobalConstants.MaxLengthFifty, ErrorMessage = "Live in should be less than 50 characters")]
        [RegularExpression(@"^[a-zA-Z0-9_\-. /]+$", ErrorMessage = "Live in field can contain only letters, numbers and _-. /")]
        public string LivesIn { get; set; }

        [MinLength(GlobalConstants.MinLengthSix, ErrorMessage = "Camera should be at least 6 characters long.")]
        [MaxLength(GlobalConstants.MaxLengthFifty, ErrorMessage = "Camera should be less than 50 characters")]
        [RegularExpression(@"^[a-zA-Z0-9_\-. /]+$", ErrorMessage = "Camera field can contain only letters, numbers and _-. /")]
        public string Camera { get; set; }
    }
}