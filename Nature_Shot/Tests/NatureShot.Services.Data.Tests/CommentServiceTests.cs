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

    public class CommentServiceTests
    {
        public CommentServiceTests()
        {
        }

        [Fact]
        public void GetCommentsForPostShouldReturnCorrectNumberAndPosts()
        {
            var list = new List<Comment>()
            {
                new Comment
                {
                    Id = 1,
                    Content = "Wow",
                    PostId = 1,
                    UserPosted = new ApplicationUser
                    {
                        UserName = "asd",
                    },
                },
                new Comment
                {
                    Id = 2,
                    Content = "Amazing",
                    PostId = 2,
                    UserPosted = new ApplicationUser
                    {
                        UserName = "asd",
                    },
                },
                new Comment
                {
                    Id = 3,
                    Content = "Incredible",
                    PostId = 1,
                    UserPosted = new ApplicationUser
                    {
                        UserName = "asd",
                    },
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Comment>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new CommentService(repository.Object);

            var comments = service.GetCommentsForPost(1).ToList();

            Assert.Equal(2, comments.Count());
            Assert.Equal(list[0].Content, comments[0].Content);
            Assert.Equal(list[2].Content, comments[1].Content);
            repository.Verify(x => x.AllAsNoTracking(), Times.Once);
        }

        [Fact]
        public void GetCommentsForPostShouldReturnZeroWhenEmpty()
        {
            var list = new List<Comment>();

            var repository = new Mock<IDeletableEntityRepository<Comment>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new CommentService(repository.Object);

            var comments = service.GetCommentsForPost(1).ToList();

            Assert.Empty(comments);
            repository.Verify(x => x.AllAsNoTracking(), Times.Once);
        }

        [Fact]
        public async Task AddCommentShouldAddItToTheListAndIncreaseCount()
        {
            var list = new List<Comment>()
            {
                new Comment
                {
                    Id = 1,
                    Content = "Wow",
                    PostId = 1,
                    UserPostedId = "asd",
                },
                new Comment
                {
                    Id = 2,
                    Content = "Amazing",
                    PostId = 2,
                    UserPostedId = "asd",
                },
                new Comment
                {
                    Id = 3,
                    Content = "Incredible",
                    PostId = 1,
                    UserPostedId = "asd",
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Comment>>();
            repository.Setup(r => r.AddAsync(It.IsAny<Comment>())).Callback((Comment comment) => list.Add(comment));
            var service = new CommentService(repository.Object);

            await service.AddComment("asd", 3, "abvbg");
            var comment = list[3];

            Assert.Equal("asd", comment.UserPostedId);
            Assert.Equal(3, comment.PostId);
            Assert.Equal("abvbg", comment.Content);
            Assert.Equal(4, list.Count);
            repository.Verify(x => x.AddAsync(It.IsAny<Comment>()), Times.Once);
        }
    }
}
