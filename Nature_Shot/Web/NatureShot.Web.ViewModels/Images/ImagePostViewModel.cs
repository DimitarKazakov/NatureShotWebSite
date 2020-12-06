using System;

namespace NatureShot.Web.ViewModels.Images
{
    public class ImagePostViewModel
    {
        public ImagePostViewModel()
        {
        }

        public DateTime DatePosted { get; set; }

        public int ImageId { get; set; }

        public string Username { get; set; }

        public string ImageUrl { get; set; }

        public string Tags { get; set; }

        public string Caption { get; set; }

        public string Location { get; set; }

        public string Camera { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public string Type { get; set; }

        public bool UsersOwnPhoto { get; set; }

    }
}
