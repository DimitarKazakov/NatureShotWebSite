﻿namespace NatureShot.Data.Models
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

        public string Model { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
