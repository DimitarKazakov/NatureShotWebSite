namespace NatureShot.Web.ViewModels.NormalPosts
{
    using System;

    public class NormalPostViewModel
    {
        public NormalPostViewModel()
        {
        }

        public string Username { get; set; }

        public string Tags { get; set; }

        public string Caption { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }
    }
}
