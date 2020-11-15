namespace NatureShot.Web.ViewModels.Images
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;

    public class ImagePostInputModel
    {
        public ImagePostInputModel()
        {
        }

        [Required]
        public IFormFile Image { get; set; }

        [Required]
        [MinLength(3)]
        public string Tags { get; set; }

        [Required]
        [MinLength(10)]
        public string Caption { get; set; }

        [Required]
        [MinLength(3)]
        public string Location { get; set; }

        [Required]
        [MinLength(4)]
        public string Country { get; set; }

        [Required]
        [MinLength(4)]
        public string Camera { get; set; }
    }
}
