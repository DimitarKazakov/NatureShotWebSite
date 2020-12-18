namespace NatureShot.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using CloudinaryDotNet.Actions;
    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;
    using NatureShot.Services.Data.Contracts;

    public class VideosService : IVideosService
    {
        private readonly IDeletableEntityRepository<NatureShot.Data.Models.Video> videoRepository;

        public VideosService(IDeletableEntityRepository<NatureShot.Data.Models.Video> videoRepository)
        {
            this.videoRepository = videoRepository;
        }

        public async Task<NatureShot.Data.Models.Video> CreateVideo(string userId, VideoUploadResult videoInput)
        {
            var seconds = (int)Math.Round(videoInput.Duration, MidpointRounding.AwayFromZero);
            var minitus = 0;
            var url = videoInput.Url.AbsoluteUri;

            if (seconds > 60)
            {
                minitus = seconds / 60;
                seconds -= minitus * 60;
            }

            if (url.StartsWith("http"))
            {
                url = url.Replace("http", "https");
            }

            var video = new NatureShot.Data.Models.Video
            {
                AddedByUserId = userId,
                Extension = videoInput.Format,
                VideoUrl = url,
                Length = new TimeSpan(0, minitus, seconds),
            };

            await this.videoRepository.AddAsync(video);

            await this.videoRepository.SaveChangesAsync();
            return video;
        }
    }
}
