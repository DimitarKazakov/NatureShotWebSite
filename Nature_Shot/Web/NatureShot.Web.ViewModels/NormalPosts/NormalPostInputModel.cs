namespace NatureShot.Web.ViewModels.NormalPosts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using NatureShot.Common;

    public class NormalPostInputModel
    {
        public NormalPostInputModel()
        {
        }

        [Required]
        [MinLength(GlobalConstants.MinLengthThree, ErrorMessage = "The field cannot be empty, you need at least 1 tag.")]
        [MaxLength(GlobalConstants.MaxLengthThreeHundred, ErrorMessage = "Maximum 300 characters")]
        public string Tags { get; set; }

        [Required]
        [MinLength(GlobalConstants.MinLengthTen, ErrorMessage = "The field cannot be empty, you need at least 10 characters.")]
        [MaxLength(GlobalConstants.MaxLengthThreeHundred, ErrorMessage = "Maximum 300 characters")]
        public string Caption { get; set; }

        public IEnumerable<KeyValuePair<string, string>> TagsDropDown { get; set; }
    }
}
