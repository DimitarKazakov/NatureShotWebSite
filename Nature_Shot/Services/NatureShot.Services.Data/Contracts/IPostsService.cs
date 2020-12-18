namespace NatureShot.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CloudinaryDotNet.Actions;

    using NatureShot.Web.ViewModels.Images;
    using NatureShot.Web.ViewModels.NormalPosts;
    using NatureShot.Web.ViewModels.Videos;

    public interface IPostsService
    {
        Task CreateImagePostAsync(ImagePostInputModel input, string userId, ImageUploadResult image);

        Task CreateVideoPostAsync(VideoPostInputModel input, string userId, VideoUploadResult video);

        Task CreateNormalPostAsync(NormalPostInputModel input, string userId);

        Task LikeAsync(int postId, string userId);

        Task DislikeAsync(int postId, string userId);

        Task Delete(int postId);

        bool CheckPostOwner(int postId, string userId);

        Task UpdateImage(ImagePostUpdateModel input);

        Task UpdateVideo(VideoPostUpdateModel input);

        Task UpdatePost(NormalPostUpdateModel input);

        ImagePostUpdateModel GetImagePost(int id);

        VideoPostUpdateModel GetVideoPost(int id);

        NormalPostUpdateModel GetNormalPost(int id);
    }
}
