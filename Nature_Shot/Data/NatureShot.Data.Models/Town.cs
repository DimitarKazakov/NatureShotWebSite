﻿namespace NatureShot.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using NatureShot.Common;
    using NatureShot.Data.Common.Models;

    public class Town : BaseDeletableModel<int>
    {
        public Town()
        {
            this.Locations = new HashSet<Location>();
        }

        [Required]
        [MaxLength(GlobalConstants.MaxLengthSixty)]
        public string Name { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}
