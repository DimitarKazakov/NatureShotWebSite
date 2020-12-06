namespace NatureShot.Data.Models
{
    using System;
    using NatureShot.Data.Common.Models;

    public class PostTag : BaseDeletableModel<int>
    {
        public PostTag()
        {
        }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public int TagId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
