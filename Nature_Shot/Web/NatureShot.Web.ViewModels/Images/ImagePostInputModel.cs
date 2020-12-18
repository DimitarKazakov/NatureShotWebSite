namespace NatureShot.Web.ViewModels.Images
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using NatureShot.Web.ViewModels.CustomAttributes;
    using NatureShot.Common;

    public class ImagePostInputModel
    {
        public ImagePostInputModel()
        {
        }

        [Required]
        [AllowedExtensionsAttribute(new string[] { ".bmp", ".gif", ".jpeg", ".png", ".jpg", ".tif", ".tiff", ".svg", ".webp" })]
        public IFormFile Image { get; set; }

        [Required]
        [MinLength(GlobalConstants.MinLengthThree, ErrorMessage = "The field cannot be empty, you need at least 1 tag.")]
        [MaxLength(GlobalConstants.MaxLengthThreeHundred, ErrorMessage = "Maximum 300 characters")]
        public string Tags { get; set; }

        [Required]
        [MinLength(GlobalConstants.MinLengthTen, ErrorMessage = "The field cannot be empty, you need at least 10 characters.")]
        [MaxLength(GlobalConstants.MaxLengthThreeHundred, ErrorMessage = "Maximum 300 characters")]
        public string Caption { get; set; }

        [MinLength(GlobalConstants.MinLengthThree, ErrorMessage = "Location name should be at least 3 characters long.")]
        [MaxLength(GlobalConstants.MaxLengthSixty, ErrorMessage = "Location name cannot be bigger than 60 characters.")]
        public string Location { get; set; }

        [Required]
        [MinLength(GlobalConstants.MinLengthFour, ErrorMessage = "Country name should be at least 3 characters long.")]
        [MaxLength(GlobalConstants.MaxLengthSixty, ErrorMessage = "Country name cannot be bigger than 60 characters.")]
        public string Country { get; set; }

        [Required]
        [MinLength(GlobalConstants.MinLengthFour)]
        [MaxLength(GlobalConstants.MaxLengthSixty, ErrorMessage = "Camera model cannot be bigger than 60 characters.")]
        public string Camera { get; set; }

        public IEnumerable<KeyValuePair<string, string>> LocationsDropDown { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CamerasDropDown { get; set; }

        public IEnumerable<KeyValuePair<string, string>> TagsDropDown { get; set; }
    }
}
