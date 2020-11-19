using System.ComponentModel.DataAnnotations;

namespace NatureShot.Data.Models
{

    public class PostReact
    {
        public PostReact()
        {
        }

        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public bool IsLiked { get; set; }
    }
}
