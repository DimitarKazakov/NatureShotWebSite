namespace NatureShot.Web.ViewModels.NormalPosts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class NormalPostInputModel
    {
        public NormalPostInputModel()
        {
        }

        [Required]
        [MinLength(3, ErrorMessage = "The field cannot be empty, you need at least 1 tag.")]
        [MaxLength(300, ErrorMessage = "Maximum 300 characters")]
        public string Tags { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "The field cannot be empty, you need at least 10 characters.")]
        [MaxLength(300, ErrorMessage = "Maximum 300 characters")]
        public string Caption { get; set; }

        public IEnumerable<KeyValuePair<string, string>> TagsDropDown { get; set; }
    }
}
