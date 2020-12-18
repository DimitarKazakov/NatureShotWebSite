namespace NatureShot.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using NatureShot.Common;
    using NatureShot.Data.Common.Models;

    public class Post : BaseDeletableModel<int>
    {
        public Post()
        {
            this.Tags = new HashSet<PostTag>();
            this.Comments = new HashSet<Comment>();
            this.PostReacts = new HashSet<PostReact>();
            this.Reports = new HashSet<Report>();
        }

        [Required]
        public string AddedByUserId { get; set; }

        [Required]
        public virtual ApplicationUser AddedByUser { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        [Required]
        [MaxLength(GlobalConstants.MaxLengthThreeHundred)]
        public string Caption { get; set; }

        public int PostTypeId { get; set; }

        public virtual PostType Type { get; set; }

        public int? LocationId { get; set; }

        public virtual Location Location { get; set; }

        public int? CameraId { get; set; }

        public virtual Camera Camera { get; set; }

        public string ImageId { get; set; }

        public virtual Image Image { get; set; }

        public string VideoId { get; set; }

        public virtual Video Video { get; set; }

        public virtual ICollection<PostTag> Tags { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<PostReact> PostReacts { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}
