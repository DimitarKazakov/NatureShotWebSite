namespace NatureShot.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using NatureShot.Data.Common.Models;

    public class Image : BaseDeletableModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        [Required]
        [MaxLength(6)]
        public string Extension { get; set; }

        public int ImageTypeId { get; set; }

        public virtual ImageType Type { get; set; }
    }
}
