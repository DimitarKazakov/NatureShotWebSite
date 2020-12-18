namespace NatureShot.Web.ViewModels.Report
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using NatureShot.Common;

    public class ReportInputModel
    {
        public ReportInputModel()
        {
        }

        [Required]
        [MaxLength(GlobalConstants.MaxLengthOneHundred)]
        [MinLength(GlobalConstants.MinLengthFour)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(GlobalConstants.MaxLengthFiveHundred)]
        [MinLength(GlobalConstants.MinLengthTen)]
        public string Content { get; set; }

        [Required]
        public string PostId { get; set; }
    }
}
