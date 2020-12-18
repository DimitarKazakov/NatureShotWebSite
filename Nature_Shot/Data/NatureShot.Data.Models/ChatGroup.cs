namespace NatureShot.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using NatureShot.Common;
    using NatureShot.Data.Common.Models;

    public class ChatGroup : BaseDeletableModel<string>
    {
        public ChatGroup()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Messages = new HashSet<Message>();
            this.Members = new HashSet<GroupMembers>();
        }

        [Required]
        [MaxLength(GlobalConstants.MaxLengthFifty)]
        public string Name { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public virtual ICollection<GroupMembers> Members { get; set; }
    }
}
