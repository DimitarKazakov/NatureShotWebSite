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

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        [Required]
        public virtual ApplicationUser AddedByUser { get; set; }

        public string Extension { get; set; }

        public int ImageTypeId { get; set; }

        public virtual ImageType Type { get; set; }
    }
}
