using System;
using System.ComponentModel.DataAnnotations;

namespace NatureShot.Web.ViewModels.Report
{
    public class ReportInputModel
    {
        public ReportInputModel()
        {
        }

        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(500)]
        [MinLength(10)]
        public string Content { get; set; }

        [Required]
        public string PostId { get; set; }
    }
}
