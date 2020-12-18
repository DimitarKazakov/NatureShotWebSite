namespace NatureShot.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using NatureShot.Common;
    using NatureShot.Data.Common.Models;

    public class Report : BaseDeletableModel<int>
    {
        public Report()
        {
        }

        public Post Post { get; set; }

        public int PostId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.MaxLengthOneHundred)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(GlobalConstants.MaxLengthFiveHundred)]
        public string Content { get; set; }
    }
}
