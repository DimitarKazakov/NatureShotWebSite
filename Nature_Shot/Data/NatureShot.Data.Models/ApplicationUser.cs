// ReSharper disable VirtualMemberCallInConstructor
namespace NatureShot.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;
    using NatureShot.Data.Common.Models;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Comments = new HashSet<Comment>();
            this.Images = new HashSet<Image>();
            this.Posts = new HashSet<Post>();
            this.PostReacts = new HashSet<PostReact>();
            this.Videos = new HashSet<Video>();
            this.Groups = new HashSet<GroupMembers>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Proffesion { get; set; }

        [MaxLength(50)]
        public string Camera { get; set; }

        [MaxLength(50)]
        public string LivesIn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<PostReact> PostReacts { get; set; }

        public virtual ICollection<Video> Videos { get; set; }

        public virtual ICollection<GroupMembers> Groups { get; set; }
    }
}
