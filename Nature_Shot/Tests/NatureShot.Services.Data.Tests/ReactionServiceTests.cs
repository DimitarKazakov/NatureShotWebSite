namespace NatureShot.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Moq;
    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;
    using NatureShot.Services.Data;
    using Xunit;

    public class ReactionServiceTests
    {
        public ReactionServiceTests()
        {
        }

        [Fact]
        public async Task ChangeReactionAsyncShouldChangeToLike()
        {
            var list = new List<PostReact>()
            {
                new PostReact
                {
                    IsLiked = false,
                    PostId = 1,
                    UserId = "user1",
                },
                new PostReact
                {
                    IsLiked = true,
                    PostId = 2,
                    UserId = "user1",
                },
                new PostReact
                {
                    IsLiked = false,
                    PostId = 3,
                    UserId = "user2",
                },
            };

            var repository = new Mock<IRepository<PostReact>>();
            repository.Setup(r => r.All()).Returns(() => list.AsQueryable());
            var service = new ReactionService(repository.Object);

            var react = service.ChangeReactionAsync(3, "user2", "Like");

            Assert.True(list[2].IsLiked);
            repository.Verify(x => x.All(), Times.Once);
        }

        [Fact]
        public async Task ChangeReactionAsyncShouldChangeToDislike()
        {
            var list = new List<PostReact>()
            {
                new PostReact
                {
                    IsLiked = false,
                    PostId = 1,
                    UserId = "user1",
                },
                new PostReact
                {
                    IsLiked = true,
                    PostId = 2,
                    UserId = "user1",
                },
                new PostReact
                {
                    IsLiked = false,
                    PostId = 3,
                    UserId = "user2",
                },
            };

            var repository = new Mock<IRepository<PostReact>>();
            repository.Setup(r => r.All()).Returns(() => list.AsQueryable());
            var service = new ReactionService(repository.Object);

            var react = service.ChangeReactionAsync(2, "user1", "Dislike");

            Assert.False(list[2].IsLiked);
            repository.Verify(x => x.All(), Times.Once);
        }

        [Fact]
        public async Task CreateReactShouldAddTheNewReact()
        {
            var list = new List<PostReact>()
            {
                new PostReact
                {
                    IsLiked = false,
                    PostId = 1,
                    UserId = "user1",
                },
            };

            var repository = new Mock<IRepository<PostReact>>();
            repository.Setup(r => r.AddAsync(It.IsAny<PostReact>())).Callback((PostReact react) => list.Add(react));
            var service = new ReactionService(repository.Object);

            var react = service.CreateReact(2, "user1", true);

            Assert.True(list[1].IsLiked);
            Assert.Equal(2, list[1].PostId);
            Assert.Equal("user1", list[1].UserId);
            repository.Verify(x => x.AddAsync(It.IsAny<PostReact>()), Times.Once);
        }

        [Fact]
        public void GetPostReactShouldReturnCorrectReact()
        {
            var list = new List<PostReact>()
            {
                new PostReact
                {
                    IsLiked = false,
                    PostId = 1,
                    UserId = "user1",
                },
                new PostReact
                {
                    IsLiked = true,
                    PostId = 2,
                    UserId = "user1",
                },
            };

            var repository = new Mock<IRepository<PostReact>>();
            repository.Setup(r => r.All()).Returns(() => list.AsQueryable());
            var service = new ReactionService(repository.Object);

            var react = service.GetPostReact(2, "user1");

            Assert.True(react.IsLiked);
            Assert.Equal(2, react.PostId);
            Assert.Equal("user1", react.UserId);
            repository.Verify(x => x.All(), Times.Once);
        }

        [Fact]
        public void GetUsersWhoDislikedPostShouldReturnCorrectNumberOfUsers()
        {
            var list = new List<PostReact>()
            {
                new PostReact
                {
                    IsLiked = false,
                    PostId = 1,
                    User = new ApplicationUser
                    {
                        UserName = "user1",
                    },
                },
                new PostReact
                {
                    IsLiked = true,
                    PostId = 2,
                    User = new ApplicationUser
                    {
                        UserName = "user1",
                    },
                },
                new PostReact
                {
                    IsLiked = false,
                    PostId = 1,
                    User = new ApplicationUser
                    {
                        UserName = "user2",
                    },
                },
                new PostReact
                {
                    IsLiked = true,
                    PostId = 1,
                    User = new ApplicationUser
                    {
                        UserName = "user3",
                    },
                },
            };

            var repository = new Mock<IRepository<PostReact>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new ReactionService(repository.Object);

            var reacts = service.GetUsersWhoDislikedPost(1).ToList();

            Assert.Equal(2, reacts.Count());
            Assert.Equal(list[0].User.UserName, reacts[0].User);
            Assert.Equal(list[2].User.UserName, reacts[1].User);
            repository.Verify(x => x.AllAsNoTracking(), Times.Once);
        }

        [Fact]
        public void GetUsersWhoDislikedPostShouldReturnZeroIfThereArentSuch()
        {
            var list = new List<PostReact>();

            var repository = new Mock<IRepository<PostReact>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new ReactionService(repository.Object);

            var reacts = service.GetUsersWhoDislikedPost(1).ToList();

            Assert.Empty(reacts);
            repository.Verify(x => x.AllAsNoTracking(), Times.Once);
        }

        [Fact]
        public void GetUsersWhoLikedPostShouldReturnZeroIfThereArentSuch()
        {
            var list = new List<PostReact>();

            var repository = new Mock<IRepository<PostReact>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new ReactionService(repository.Object);

            var reacts = service.GetUsersWhoLikedPost(1).ToList();

            Assert.Empty(reacts);
            repository.Verify(x => x.AllAsNoTracking(), Times.Once);
        }

        [Fact]
        public void GetUsersWhoLikedPostShouldReturnCorrectNumberOfUsers()
        {
            var list = new List<PostReact>()
            {
                new PostReact
                {
                    IsLiked = false,
                    PostId = 1,
                    User = new ApplicationUser
                    {
                        UserName = "user1",
                    },
                },
                new PostReact
                {
                    IsLiked = true,
                    PostId = 2,
                    User = new ApplicationUser
                    {
                        UserName = "user1",
                    },
                },
                new PostReact
                {
                    IsLiked = false,
                    PostId = 1,
                    User = new ApplicationUser
                    {
                        UserName = "user2",
                    },
                },
                new PostReact
                {
                    IsLiked = true,
                    PostId = 1,
                    User = new ApplicationUser
                    {
                        UserName = "user3",
                    },
                },
            };

            var repository = new Mock<IRepository<PostReact>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new ReactionService(repository.Object);

            var reacts = service.GetUsersWhoLikedPost(2).ToList();

            Assert.Single(reacts);
            Assert.Equal(list[1].User.UserName, reacts[0].User);
            repository.Verify(x => x.AllAsNoTracking(), Times.Once);
        }
    }
}
