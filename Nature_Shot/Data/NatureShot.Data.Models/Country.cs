namespace NatureShot.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using NatureShot.Data.Common.Models;

    public class Country : BaseDeletableModel<int>
    {
        public Country()
        {
            this.Locations = new HashSet<Location>();
            this.Towns = new HashSet<Town>();
        }

        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        public virtual ICollection<Location> Locations { get; set; }

        public virtual ICollection<Town> Towns { get; set; }
    }
}
