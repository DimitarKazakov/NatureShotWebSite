namespace NatureShot.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using NatureShot.Common;
    using NatureShot.Data.Common.Models;

    public class Message : BaseDeletableModel<int>
    {
        public Message()
        {
        }

        [Required]
        [MaxLength(GlobalConstants.MaxLengthThreeHundred)]
        public string Content { get; set; }

        [Required]
        [MaxLength(GlobalConstants.MaxLengthTwentyFive)]
        public string SendByUsername { get; set; }

        public bool HasBeenRead { get; set; }

        [Required]
        public string ChatGroupId { get; set; }

        public ChatGroup ChatGroup { get; set; }
    }
}
