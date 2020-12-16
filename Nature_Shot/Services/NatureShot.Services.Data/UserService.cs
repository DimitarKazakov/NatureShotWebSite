namespace NatureShot.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CloudinaryDotNet.Actions;
    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;
    using NatureShot.Web.ViewModels.User;

    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IImagesService imagesService;

        public UserService(IDeletableEntityRepository<ApplicationUser> userRepository, IImagesService imagesService)
        {
            this.userRepository = userRepository;
            this.imagesService = imagesService;
        }

        public IEnumerable<string> GetAllUserNames()
        {
            return this.userRepository.AllAsNoTracking().Select(x => x.UserName).ToList();
        }

        public UserProfileInputModel GetUserDataForUpdate(string id)
        {
            var user = this.userRepository.All().Where(x => x.Id == id).Select(x => new UserProfileInputModel
            {
                Id = x.Id,
                Username = x.UserName,
                Proffesion = x.Proffesion == null ? string.Empty : x.Proffesion,
                Camera = x.Camera == null ? string.Empty : x.Camera,
                LivesIn = x.LivesIn == null ? string.Empty : x.LivesIn,
                Name = x.Name == null ? string.Empty : x.Name,
                ProfilePictureUrl = x.Images.FirstOrDefault(x => x.IsProfilePicture == true).ImageUrl,
            }).FirstOrDefault();

            return user;
        }

        public string GetUserId(string username)
        {
            if (username.Contains("@"))
            {
                var user = this.userRepository.AllAsNoTracking().FirstOrDefault(x => x.Email == username);
                return user == null ? null : user.Id;

            }
            else
            {
                var user = this.userRepository.AllAsNoTracking().FirstOrDefault(x => x.UserName == username);
                return user == null ? null : user.Id;
            }
        }

        public UserProfileViewModel GetUserDataForProfile(string id)
        {
            var user = this.userRepository.All().Where(x => x.Id == id).Select(x => new UserProfileViewModel
            {
                Email = x.Email,
                JoinedOn = x.CreatedOn,
                TotalPosts = x.Posts.Count(y => y.AddedByUserId == x.Id),
                TotalLikes = x.Posts.Select(y => y.Likes).Sum(),
                TotalDislikes = x.Posts.Select(y => y.Dislikes).Sum(),
                Username = x.UserName,
                Proffesion = x.Proffesion == null ? string.Empty : x.Proffesion,
                Camera = x.Camera == null ? string.Empty : x.Camera,
                LivesIn = x.LivesIn == null ? string.Empty : x.LivesIn,
                Name = x.Name == null ? string.Empty : x.Name,
                ProfilePictureUrl = x.Images.FirstOrDefault(x => x.IsProfilePicture == true).ImageUrl,
            }).FirstOrDefault();

            return user;
        }

        public async Task UpdateProfile(UserProfileInputModel input, ImageUploadResult imageInput = null)
        {
            var user = this.userRepository.All().FirstOrDefault(x => x.Id == input.Id);

            if (imageInput != null && input.ProfilePicture != null)
            {
                await this.imagesService.CreateProfileImage(input.Id, imageInput);
            }

            if (input.Camera != null)
            {
                user.Camera = input.Camera;
            }

            if (input.LivesIn != null)
            {
                user.LivesIn = input.LivesIn;
            }

            if (input.Name != null)
            {
                user.Name = input.Name;
            }

            if (input.Proffesion != null)
            {
                user.Proffesion = input.Proffesion;
            }

            await this.userRepository.SaveChangesAsync();
        }
    }
}
