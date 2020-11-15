namespace NatureShot.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using NatureShot.Data.Common.Models;

    public class ImageType : BaseModel<int>
    {
        public ImageType()
        {
        }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }
    }
}
