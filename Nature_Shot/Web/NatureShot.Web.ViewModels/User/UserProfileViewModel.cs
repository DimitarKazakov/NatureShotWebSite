using System;
namespace NatureShot.Web.ViewModels.User
{
    public class UserProfileViewModel
    {
        public UserProfileViewModel()
        {
        }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Proffesion { get; set; }

        public string Camera { get; set; }

        public string LivesIn { get; set; }

        public string ProfilePictureUrl { get; set; }

        public int TotalPosts { get; set; }

        public int TotalLikes { get; set; }

        public int TotalDislikes { get; set; }

        public DateTime JoinedOn { get; set; }
    }
}
