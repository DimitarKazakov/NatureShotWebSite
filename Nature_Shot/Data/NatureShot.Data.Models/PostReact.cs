namespace NatureShot.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using NatureShot.Data.Common.Models;

    public class PostReact : BaseModel<int>
    {
        public PostReact()
        {
        }

        [Required]
        public string UserId { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public bool IsLiked { get; set; }
    }
}
