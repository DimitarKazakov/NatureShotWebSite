namespace NatureShot.Data.Models
{
    using System;
    using System.Collections.Generic;

    using NatureShot.Data.Common.Models;

    public class ChatGroup : BaseDeletableModel<string>
    {
        public ChatGroup()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Messages = new HashSet<Message>();
            this.Members = new HashSet<GroupMembers>();
        }

        public virtual ICollection<Message> Messages { get; set; }

        public virtual ICollection<GroupMembers> Members { get; set; }
    }
}
