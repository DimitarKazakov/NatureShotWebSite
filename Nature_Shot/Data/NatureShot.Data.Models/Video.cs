namespace NatureShot.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using NatureShot.Data.Common.Models;

    public class Video : BaseDeletableModel<string>
    {
        public Video()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string AddedByUserId { get; set; }

        [Required]
        public virtual ApplicationUser AddedByUser { get; set; }

        [Required]
        public string Extension { get; set; }

        public TimeSpan Length { get; set; }
    }
}
