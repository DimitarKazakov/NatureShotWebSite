namespace NatureShot.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using NatureShot.Data.Common.Models;

    public class GroupMembers : BaseDeletableModel<int>
    {
        public GroupMembers()
        {
        }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string ChatGroupId { get; set; }

        public ChatGroup ChatGroup { get; set; }
    }
}
