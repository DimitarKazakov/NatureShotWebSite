namespace NatureShot.Data.Models
{
    using System;

    public class PostTag
    {
        public PostTag()
        {
        }

        public int Id { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public int TagId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
