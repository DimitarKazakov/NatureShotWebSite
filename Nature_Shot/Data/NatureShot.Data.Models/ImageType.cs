namespace NatureShot.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using NatureShot.Data.Common.Models;

    public class ImageType : BaseModel<int>
    {
        public ImageType()
        {
            this.Images = new HashSet<Image>();
        }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
