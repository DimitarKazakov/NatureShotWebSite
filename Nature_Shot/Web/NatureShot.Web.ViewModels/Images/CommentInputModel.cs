namespace NatureShot.Web.ViewModels.Images
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using NatureShot.Common;

    public class CommentInputModel
    {
        public CommentInputModel()
        {
        }

        public string Id { get; set; }

        [MinLength(GlobalConstants.MinLengthThree)]
        [MaxLength(GlobalConstants.MaxLengthThreeHundred)]
        public string Comment { get; set; }
    }
}
