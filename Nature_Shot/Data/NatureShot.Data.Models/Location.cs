namespace NatureShot.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using NatureShot.Data.Common.Models;

    public class Location : BaseModel<int>
    {
        public Location()
        {
            this.Posts = new HashSet<Post>();
        }

        [Required]
        [MaxLength(120)]
        public string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public int? TownId { get; set; }

        public virtual Town Town { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
