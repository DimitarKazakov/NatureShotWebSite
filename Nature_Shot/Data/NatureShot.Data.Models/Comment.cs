namespace NatureShot.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using NatureShot.Common;
    using NatureShot.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public Comment()
        {
        }

        [Required]
        [MaxLength(GlobalConstants.MaxLengthThreeHundred)]
        public string Content { get; set; }

        [Required]
        public string UserPostedId { get; set; }

        [Required]
        public virtual ApplicationUser UserPosted { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
