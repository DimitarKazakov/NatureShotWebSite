namespace NatureShot.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using NatureShot.Common;
    using NatureShot.Data.Common.Models;

    public class PostType : BaseDeletableModel<int>
    {
        public PostType()
        {
            this.Posts = new HashSet<Post>();
        }

        [Required]
        [MaxLength(GlobalConstants.MinLengthTen)]
        public string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
