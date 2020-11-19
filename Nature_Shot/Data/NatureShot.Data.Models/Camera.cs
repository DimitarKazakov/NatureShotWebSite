namespace NatureShot.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using NatureShot.Data.Common.Models;

    public class Camera : BaseDeletableModel<int>
    {
        public Camera()
        {
            this.Posts = new HashSet<Post>();
        }

        [Required]
        [MaxLength(60)]
        public string Model { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
