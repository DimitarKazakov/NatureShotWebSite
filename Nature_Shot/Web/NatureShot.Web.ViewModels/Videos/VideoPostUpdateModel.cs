namespace NatureShot.Web.ViewModels.Videos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class VideoPostUpdateModel
    {
        public VideoPostUpdateModel()
        {
        }

        public string VideoUrl { get; set; }

        public int VideoId { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "The field cannot be empty, you need at least 1 tag.")]
        [MaxLength(300, ErrorMessage = "Maximum 300 characters")]
        public string Tags { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "The field cannot be empty, you need at least 10 characters.")]
        [MaxLength(300, ErrorMessage = "Maximum 300 characters")]
        public string Caption { get; set; }

        [MinLength(3, ErrorMessage = "Location name should be at least 3 characters long.")]
        [MaxLength(60, ErrorMessage = "Location name cannot be bigger than 60 characters.")]
        public string Location { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Country name should be at least 3 characters long.")]
        [MaxLength(60, ErrorMessage = "Country name cannot be bigger than 60 characters.")]
        public string Country { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(60, ErrorMessage = "Camera model cannot be bigger than 60 characters.")]
        public string Camera { get; set; }

        public IEnumerable<KeyValuePair<string, string>> LocationsDropDown { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CamerasDropDown { get; set; }

        public IEnumerable<KeyValuePair<string, string>> TagsDropDown { get; set; }
    }
}
