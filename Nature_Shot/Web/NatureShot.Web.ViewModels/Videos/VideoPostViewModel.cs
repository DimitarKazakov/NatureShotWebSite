namespace NatureShot.Web.ViewModels.Videos
{
    using System;

    public class VideoPostViewModel
    {
        public VideoPostViewModel()
        {
        }

        public DateTime DatePosted { get; set; }

        public int VideoId { get; set; }

        public string Username { get; set; }

        public string VideoUrl { get; set; }

        public string Tags { get; set; }

        public string Caption { get; set; }

        public string Location { get; set; }

        public string Camera { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public string Length { get; set; }
    }
}
