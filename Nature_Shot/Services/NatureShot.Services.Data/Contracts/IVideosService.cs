namespace NatureShot.Services.Data.Contracts
{
    using System;
    using System.Threading.Tasks;

    using CloudinaryDotNet.Actions;

    public interface IVideosService
    {
        public Task<NatureShot.Data.Models.Video> CreateVideo(string userId, VideoUploadResult videoInput);
    }
}
