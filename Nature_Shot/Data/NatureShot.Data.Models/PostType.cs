namespace NatureShot.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using NatureShot.Data.Common.Models;

    public class PostType : BaseDeletableModel<int>
    {
        public PostType()
        {
            this.Posts = new HashSet<Post>();
        }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
