namespace NatureShot.Services.Data.Tests.VideoPosts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Moq;
    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;
    using NatureShot.Services.Data;
    using NatureShot.Services.Data.VideoPosts;
    using Xunit;

    public class VideoPostsNewestTests
    {
        public VideoPostsNewestTests()
        {
        }

        [Fact]
        public void GetVideoPostsNewestShouldReturnFirstTwoElementsWhenThereAreTwoOrMore()
        {
            var list = new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Likes = 0,
                    Dislikes = 3,
                    CreatedOn = new DateTime(2000, 11, 20),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 1),
                    },
                },
                new Post
                {
                    Id = 2,
                    Likes = 1,
                    Dislikes = 2,
                    CreatedOn = new DateTime(2000, 11, 21),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho2",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first2",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second2",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption2",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 2),
                    },
                },
                new Post
                {
                    Id = 3,
                    Likes = 2,
                    Dislikes = 1,
                    CreatedOn = new DateTime(2000, 11, 22),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho3",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first3",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second3",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption3",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 3),
                    },
                },
                new Post
                {
                    Id = 4,
                    Likes = 3,
                    Dislikes = 0,
                    CreatedOn = new DateTime(2000, 11, 23),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho4",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first4",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second4",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption4",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 4),
                    },
                },
                new Post
                {
                    Id = 5,
                    Likes = 4,
                    Dislikes = 4,
                    CreatedOn = new DateTime(2000, 11, 24),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho5",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first5",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second5",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption5",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 5),
                    },
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new VideoPostsNewest(repository.Object);

            var posts = service.GetVideoPostsNewest(0, 2).ToList();

            Assert.Equal(2, posts.Count());
            Assert.Equal(list[4].Id, posts[0].VideoId);
            Assert.Equal(list[3].Id, posts[1].VideoId);
            repository.Verify(x => x.AllAsNoTracking(), Times.AtMost(2));
        }

        [Fact]
        public void GetVideoPostsNewestShouldReturnSecondTwoElementsWhenThereAreFourOrMore()
        {
            var list = new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Likes = 0,
                    Dislikes = 3,
                    CreatedOn = new DateTime(2000, 11, 20),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 1),
                    },
                },
                new Post
                {
                    Id = 2,
                    Likes = 1,
                    Dislikes = 2,
                    CreatedOn = new DateTime(2000, 11, 21),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho2",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first2",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second2",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption2",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 2),
                    },
                },
                new Post
                {
                    Id = 3,
                    Likes = 2,
                    Dislikes = 1,
                    CreatedOn = new DateTime(2000, 11, 22),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho3",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first3",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second3",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption3",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 3),
                    },
                },
                new Post
                {
                    Id = 4,
                    Likes = 3,
                    Dislikes = 0,
                    CreatedOn = new DateTime(2000, 11, 23),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho4",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first4",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second4",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption4",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 4),
                    },
                },
                new Post
                {
                    Id = 5,
                    Likes = 4,
                    Dislikes = 4,
                    CreatedOn = new DateTime(2000, 11, 24),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho5",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first5",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second5",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption5",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 5),
                    },
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new VideoPostsNewest(repository.Object);

            var posts = service.GetVideoPostsNewest(1, 2).ToList();

            Assert.Equal(2, posts.Count());
            Assert.Equal(list[2].Id, posts[0].VideoId);
            Assert.Equal(list[1].Id, posts[1].VideoId);
            repository.Verify(x => x.AllAsNoTracking(), Times.AtMost(2));
        }

        [Fact]
        public void GetVideoPostsNewestShouldReturnFirstElementWhenThereAreLessThanTwo()
        {
            var list = new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Likes = 0,
                    Dislikes = 3,
                    CreatedOn = new DateTime(2000, 11, 20),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 1),
                    },
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new VideoPostsNewest(repository.Object);

            var posts = service.GetVideoPostsNewest(0, 2).ToList();

            Assert.Single(posts);
            Assert.Equal(list[0].Id, posts[0].VideoId);
            repository.Verify(x => x.AllAsNoTracking(), Times.AtMost(2));
        }

        [Fact]
        public void GetVideoPostsNewestShouldReturnThirdElementWhenThereAreThree()
        {
            var list = new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Likes = 0,
                    Dislikes = 3,
                    CreatedOn = new DateTime(2000, 11, 20),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 1),
                    },
                },
                new Post
                {
                    Id = 2,
                    Likes = 1,
                    Dislikes = 2,
                    CreatedOn = new DateTime(2000, 11, 21),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho2",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first2",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second2",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption2",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 2),
                    },
                },
                new Post
                {
                    Id = 3,
                    Likes = 2,
                    Dislikes = 1,
                    CreatedOn = new DateTime(2000, 11, 22),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho3",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first3",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second3",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption3",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 3),
                    },
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new VideoPostsNewest(repository.Object);

            var posts = service.GetVideoPostsNewest(1, 2).ToList();

            Assert.Single(posts);
            Assert.Equal(list[0].Id, posts[0].VideoId);
            repository.Verify(x => x.AllAsNoTracking(), Times.AtMost(2));
        }

        [Fact]
        public void GetVideoPostsNewestShouldReturnZeroWhenEmpty()
        {
            var list = new List<Post>();
            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new VideoPostsNewest(repository.Object);

            var posts = service.GetVideoPostsNewest(0, 2).ToList();

            Assert.Empty(posts);
            repository.Verify(x => x.AllAsNoTracking(), Times.Once);
        }

        [Fact]
        public void SearchByCaptionShouldReturnFirstTwoElementsWhenThereAreTwoOrMore()
        {
            var list = new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Likes = 0,
                    Dislikes = 3,
                    CreatedOn = new DateTime(2000, 11, 20),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 1),
                    },
                },
                new Post
                {
                    Id = 2,
                    Likes = 1,
                    Dislikes = 2,
                    CreatedOn = new DateTime(2000, 11, 21),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho2",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first2",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second2",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption2",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 2),
                    },
                },
                new Post
                {
                    Id = 3,
                    Likes = 2,
                    Dislikes = 1,
                    CreatedOn = new DateTime(2000, 11, 22),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho3",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first3",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second3",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption3",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 3),
                    },
                },
                new Post
                {
                    Id = 4,
                    Likes = 3,
                    Dislikes = 0,
                    CreatedOn = new DateTime(2000, 11, 23),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho4",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first4",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second4",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption4",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 4),
                    },
                },
                new Post
                {
                    Id = 5,
                    Likes = 4,
                    Dislikes = 4,
                    CreatedOn = new DateTime(2000, 11, 24),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho5",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first5",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second5",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption5",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 5),
                    },
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new VideoPostsNewest(repository.Object);

            var posts = service.SearchByCaption(0, "testCaption", 2).ToList();

            Assert.Equal(2, posts.Count());
            Assert.Equal(list[4].Id, posts[0].VideoId);
            Assert.Equal(list[3].Id, posts[1].VideoId);
            repository.Verify(x => x.AllAsNoTracking(), Times.AtMost(2));
        }

        [Fact]
        public void SearchByCaptionShouldReturnSecondTwoElementsWhenThereAreFourOrMore()
        {
            var list = new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Likes = 0,
                    Dislikes = 3,
                    CreatedOn = new DateTime(2000, 11, 20),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 1),
                    },
                },
                new Post
                {
                    Id = 2,
                    Likes = 1,
                    Dislikes = 2,
                    CreatedOn = new DateTime(2000, 11, 21),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho2",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first2",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second2",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption2",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 2),
                    },
                },
                new Post
                {
                    Id = 3,
                    Likes = 2,
                    Dislikes = 1,
                    CreatedOn = new DateTime(2000, 11, 22),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho3",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first3",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second3",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption3",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 3),
                    },
                },
                new Post
                {
                    Id = 4,
                    Likes = 3,
                    Dislikes = 0,
                    CreatedOn = new DateTime(2000, 11, 23),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho4",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first4",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second4",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption4",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 4),
                    },
                },
                new Post
                {
                    Id = 5,
                    Likes = 4,
                    Dislikes = 4,
                    CreatedOn = new DateTime(2000, 11, 24),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho5",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first5",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second5",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption5",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 5),
                    },
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new VideoPostsNewest(repository.Object);

            var posts = service.SearchByCaption(1, "testCaption", 2).ToList();

            Assert.Equal(2, posts.Count());
            Assert.Equal(list[2].Id, posts[0].VideoId);
            Assert.Equal(list[1].Id, posts[1].VideoId);
            repository.Verify(x => x.AllAsNoTracking(), Times.AtMost(2));
        }

        [Fact]
        public void SearchByCaptionShouldReturnFirstElementWhenThereAreLessThanTwo()
        {
            var list = new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Likes = 0,
                    Dislikes = 3,
                    CreatedOn = new DateTime(2000, 11, 20),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 1),
                    },
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new VideoPostsNewest(repository.Object);

            var posts = service.SearchByCaption(0, "testCaption", 2).ToList();

            Assert.Single(posts);
            Assert.Equal(list[0].Id, posts[0].VideoId);
            repository.Verify(x => x.AllAsNoTracking(), Times.AtMost(2));
        }

        [Fact]
        public void SearchByCaptionShouldReturnThirdElementWhenThereLessThanFour()
        {
            var list = new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Likes = 0,
                    Dislikes = 3,
                    CreatedOn = new DateTime(2000, 11, 20),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 1),
                    },
                },
                new Post
                {
                    Id = 2,
                    Likes = 1,
                    Dislikes = 2,
                    CreatedOn = new DateTime(2000, 11, 21),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho2",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first2",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second2",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption2",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 2),
                    },
                },
                new Post
                {
                    Id = 3,
                    Likes = 2,
                    Dislikes = 1,
                    CreatedOn = new DateTime(2000, 11, 22),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho3",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first3",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second3",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption3",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 3),
                    },
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new VideoPostsNewest(repository.Object);

            var posts = service.SearchByCaption(1, "testCaption", 2).ToList();

            Assert.Single(posts);
            Assert.Equal(list[0].Id, posts[0].VideoId);
            repository.Verify(x => x.AllAsNoTracking(), Times.AtMost(2));
        }

        [Fact]
        public void SearchByCaptionShouldReturnZeroElementsWhenEmpty()
        {
            var list = new List<Post>();

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new VideoPostsNewest(repository.Object);

            var posts = service.SearchByCaption(0, "testCaption", 2).ToList();

            Assert.Empty(posts);
            repository.Verify(x => x.AllAsNoTracking(), Times.Once);
        }

        [Fact]
        public void SearchByTagsShouldReturnFirstTwoElementsWhenThereAreTwoOrMore()
        {
            var list = new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Likes = 0,
                    Dislikes = 3,
                    CreatedOn = new DateTime(2000, 11, 20),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 1),
                    },
                },
                new Post
                {
                    Id = 2,
                    Likes = 1,
                    Dislikes = 2,
                    CreatedOn = new DateTime(2000, 11, 21),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho2",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first2",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second2",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption2",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 2),
                    },
                },
                new Post
                {
                    Id = 3,
                    Likes = 2,
                    Dislikes = 1,
                    CreatedOn = new DateTime(2000, 11, 22),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho3",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first3",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second3",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption3",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 3),
                    },
                },
                new Post
                {
                    Id = 4,
                    Likes = 3,
                    Dislikes = 0,
                    CreatedOn = new DateTime(2000, 11, 23),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho4",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first4",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second4",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption4",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 4),
                    },
                },
                new Post
                {
                    Id = 5,
                    Likes = 4,
                    Dislikes = 4,
                    CreatedOn = new DateTime(2000, 11, 24),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho5",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second5",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption5",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 5),
                    },
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new VideoPostsNewest(repository.Object);

            var posts = service.SearchByTags(0, "#first", 2).ToList();

            Assert.Equal(2, posts.Count());
            Assert.Equal(list[4].Id, posts[0].VideoId);
            Assert.Equal(list[0].Id, posts[1].VideoId);
            repository.Verify(x => x.AllAsNoTracking(), Times.AtMost(2));
        }

        [Fact]
        public void SearchByTagsShouldReturnSecondTwoElementsWhenThereAreFourOrMore()
        {
            var list = new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Likes = 0,
                    Dislikes = 3,
                    CreatedOn = new DateTime(2000, 11, 20),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 1),
                    },
                },
                new Post
                {
                    Id = 2,
                    Likes = 1,
                    Dislikes = 2,
                    CreatedOn = new DateTime(2000, 11, 21),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho2",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second2",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption2",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 2),
                    },
                },
                new Post
                {
                    Id = 3,
                    Likes = 2,
                    Dislikes = 1,
                    CreatedOn = new DateTime(2000, 11, 22),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho3",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second3",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption3",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 3),
                    },
                },
                new Post
                {
                    Id = 4,
                    Likes = 3,
                    Dislikes = 0,
                    CreatedOn = new DateTime(2000, 11, 23),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho4",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second4",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption4",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 4),
                    },
                },
                new Post
                {
                    Id = 5,
                    Likes = 4,
                    Dislikes = 4,
                    CreatedOn = new DateTime(2000, 11, 24),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho5",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first5",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second5",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption5",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 5),
                    },
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new VideoPostsNewest(repository.Object);

            var posts = service.SearchByTags(1, "#first", 2).ToList();

            Assert.Equal(2, posts.Count());
            Assert.Equal(list[1].Id, posts[0].VideoId);
            Assert.Equal(list[0].Id, posts[1].VideoId);
            repository.Verify(x => x.AllAsNoTracking(), Times.AtMost(2));
        }

        [Fact]
        public void SearchByTagsShouldReturnFirstElementWhenThereAreLessThanTwo()
        {
            var list = new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Likes = 0,
                    Dislikes = 3,
                    CreatedOn = new DateTime(2000, 11, 20),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 1),
                    },
                },
                new Post
                {
                    Id = 2,
                    Likes = 1,
                    Dislikes = 2,
                    CreatedOn = new DateTime(2000, 11, 21),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho2",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first2",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second2",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption2",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 2),
                    },
                },
                new Post
                {
                    Id = 3,
                    Likes = 2,
                    Dislikes = 1,
                    CreatedOn = new DateTime(2000, 11, 22),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho3",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first3",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second3",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption3",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 3),
                    },
                },
                new Post
                {
                    Id = 4,
                    Likes = 3,
                    Dislikes = 0,
                    CreatedOn = new DateTime(2000, 11, 23),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho4",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first4",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second4",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption4",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 4),
                    },
                },
                new Post
                {
                    Id = 5,
                    Likes = 4,
                    Dislikes = 4,
                    CreatedOn = new DateTime(2000, 11, 24),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho5",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first5",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second5",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption5",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 5),
                    },
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new VideoPostsNewest(repository.Object);

            var posts = service.SearchByTags(0, "#first", 2).ToList();

            Assert.Single(posts);
            Assert.Equal(list[0].Id, posts[0].VideoId);
            repository.Verify(x => x.AllAsNoTracking(), Times.AtMost(2));
        }

        [Fact]
        public void SearchByTagsShouldReturnThirdElementWhenThereAreLessThanFour()
        {
            var list = new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Likes = 0,
                    Dislikes = 3,
                    CreatedOn = new DateTime(2000, 11, 20),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 1),
                    },
                },
                new Post
                {
                    Id = 2,
                    Likes = 1,
                    Dislikes = 2,
                    CreatedOn = new DateTime(2000, 11, 21),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho2",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second2",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption2",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 2),
                    },
                },
                new Post
                {
                    Id = 3,
                    Likes = 2,
                    Dislikes = 1,
                    CreatedOn = new DateTime(2000, 11, 22),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho3",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second3",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption3",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 3),
                    },
                },
                new Post
                {
                    Id = 4,
                    Likes = 3,
                    Dislikes = 0,
                    CreatedOn = new DateTime(2000, 11, 23),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho4",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first4",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second4",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption4",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 4),
                    },
                },
                new Post
                {
                    Id = 5,
                    Likes = 4,
                    Dislikes = 4,
                    CreatedOn = new DateTime(2000, 11, 24),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho5",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first5",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second5",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption5",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 5),
                    },
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new VideoPostsNewest(repository.Object);

            var posts = service.SearchByTags(1, "#first", 2).ToList();

            Assert.Single(posts);
            Assert.Equal(list[0].Id, posts[0].VideoId);
            repository.Verify(x => x.AllAsNoTracking(), Times.AtMost(2));
        }

        [Fact]
        public void SearchByTagsShouldReturnZeroWhenThereIsNone()
        {
            var list = new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Likes = 0,
                    Dislikes = 3,
                    CreatedOn = new DateTime(2000, 11, 20),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 1),
                    },
                },
                new Post
                {
                    Id = 2,
                    Likes = 0,
                    Dislikes = 2,
                    CreatedOn = new DateTime(2000, 11, 21),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho2",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first2",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second2",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption2",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 2),
                    },
                },
                new Post
                {
                    Id = 3,
                    Likes = 0,
                    Dislikes = 1,
                    CreatedOn = new DateTime(2000, 11, 22),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho3",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first3",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second3",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption3",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 3),
                    },
                },
                new Post
                {
                    Id = 4,
                    Likes = 0,
                    Dislikes = 0,
                    CreatedOn = new DateTime(2000, 11, 23),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho4",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first4",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second4",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption4",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 4),
                    },
                },
                new Post
                {
                    Id = 5,
                    Likes = 0,
                    Dislikes = 4,
                    CreatedOn = new DateTime(2000, 11, 24),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho5",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first5",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second5",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption5",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 5),
                    },
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new VideoPostsNewest(repository.Object);

            var posts = service.SearchByTags(0, "#zero", 2).ToList();

            Assert.Empty(posts);
            repository.Verify(x => x.AllAsNoTracking(), Times.Once);
        }

        [Fact]
        public void SearchByUsernameShouldReturnFirstTwoElementsWhenThereAreTwoOrMore()
        {
            var list = new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Likes = 0,
                    Dislikes = 3,
                    CreatedOn = new DateTime(2000, 11, 20),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 1),
                    },
                },
                new Post
                {
                    Id = 2,
                    Likes = 1,
                    Dislikes = 2,
                    CreatedOn = new DateTime(2000, 11, 21),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho2",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first2",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second2",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption2",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 2),
                    },
                },
                new Post
                {
                    Id = 3,
                    Likes = 2,
                    Dislikes = 1,
                    CreatedOn = new DateTime(2000, 11, 22),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho3",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first3",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second3",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption3",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 3),
                    },
                },
                new Post
                {
                    Id = 4,
                    Likes = 3,
                    Dislikes = 0,
                    CreatedOn = new DateTime(2000, 11, 23),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho4",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first4",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second4",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption4",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 4),
                    },
                },
                new Post
                {
                    Id = 5,
                    Likes = 4,
                    Dislikes = 4,
                    CreatedOn = new DateTime(2000, 11, 24),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho5",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first5",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second5",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption5",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 5),
                    },
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new VideoPostsNewest(repository.Object);

            var posts = service.SearchByUsername(0, "pesho", 2).ToList();

            Assert.Equal(2, posts.Count());
            Assert.Equal(list[4].Id, posts[0].VideoId);
            Assert.Equal(list[3].Id, posts[1].VideoId);
            repository.Verify(x => x.AllAsNoTracking(), Times.AtMost(2));
        }

        [Fact]
        public void SearchByUsernameShouldReturnSecondTwoElementsWhenThereAreFourOrMore()
        {
            var list = new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Likes = 0,
                    Dislikes = 3,
                    CreatedOn = new DateTime(2000, 11, 20),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 1),
                    },
                },
                new Post
                {
                    Id = 2,
                    Likes = 1,
                    Dislikes = 2,
                    CreatedOn = new DateTime(2000, 11, 21),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho2",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first2",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second2",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption2",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 2),
                    },
                },
                new Post
                {
                    Id = 3,
                    Likes = 2,
                    Dislikes = 1,
                    CreatedOn = new DateTime(2000, 11, 22),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho3",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first3",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second3",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption3",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 3),
                    },
                },
                new Post
                {
                    Id = 4,
                    Likes = 3,
                    Dislikes = 0,
                    CreatedOn = new DateTime(2000, 11, 23),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho4",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first4",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second4",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption4",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 4),
                    },
                },
                new Post
                {
                    Id = 5,
                    Likes = 4,
                    Dislikes = 4,
                    CreatedOn = new DateTime(2000, 11, 24),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho5",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first5",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second5",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption5",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 5),
                    },
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new VideoPostsNewest(repository.Object);

            var posts = service.SearchByUsername(1, "pesho", 2).ToList();

            Assert.Equal(2, posts.Count());
            Assert.Equal(list[2].Id, posts[0].VideoId);
            Assert.Equal(list[1].Id, posts[1].VideoId);
            repository.Verify(x => x.AllAsNoTracking(), Times.AtMost(2));
        }

        [Fact]
        public void SearchByUsernameShouldReturnFirstElementWhenThereAreLessThanTwo()
        {
            var list = new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Likes = 0,
                    Dislikes = 3,
                    CreatedOn = new DateTime(2000, 11, 20),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 1),
                    },
                },
                new Post
                {
                    Id = 2,
                    Likes = 1,
                    Dislikes = 2,
                    CreatedOn = new DateTime(2000, 11, 21),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho2",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first2",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second2",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption2",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 2),
                    },
                },
                new Post
                {
                    Id = 3,
                    Likes = 2,
                    Dislikes = 1,
                    CreatedOn = new DateTime(2000, 11, 22),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho3",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first3",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second3",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption3",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 3),
                    },
                },
                new Post
                {
                    Id = 4,
                    Likes = 3,
                    Dislikes = 0,
                    CreatedOn = new DateTime(2000, 11, 23),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho4",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first4",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second4",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption4",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 4),
                    },
                },
                new Post
                {
                    Id = 5,
                    Likes = 4,
                    Dislikes = 4,
                    CreatedOn = new DateTime(2000, 11, 24),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho5",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first5",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second5",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption5",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 5),
                    },
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new VideoPostsNewest(repository.Object);

            var posts = service.SearchByUsername(0, "pesho1", 2).ToList();

            Assert.Single(posts);
            Assert.Equal(list[0].Id, posts[0].VideoId);
            repository.Verify(x => x.AllAsNoTracking(), Times.AtMost(2));
        }

        [Fact]
        public void SearchByCaptionShouldReturnThirElementWhenThereLessThanFour()
        {
            var list = new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Likes = 0,
                    Dislikes = 3,
                    CreatedOn = new DateTime(2000, 11, 20),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 1),
                    },
                },
                new Post
                {
                    Id = 2,
                    Likes = 1,
                    Dislikes = 2,
                    CreatedOn = new DateTime(2000, 11, 21),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho2",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first2",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second2",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption2",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 2),
                    },
                },
                new Post
                {
                    Id = 3,
                    Likes = 2,
                    Dislikes = 1,
                    CreatedOn = new DateTime(2000, 11, 22),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho3",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first3",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second3",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption3",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 3),
                    },
                },
                new Post
                {
                    Id = 4,
                    Likes = 4,
                    Dislikes = 0,
                    CreatedOn = new DateTime(2000, 11, 23),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first4",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second4",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption4",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 4),
                    },
                },
                new Post
                {
                    Id = 5,
                    Likes = 5,
                    Dislikes = 4,
                    CreatedOn = new DateTime(2000, 11, 24),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first5",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second5",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption5",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 5),
                    },
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new VideoPostsNewest(repository.Object);

            var posts = service.SearchByUsername(1, "pesho1", 2).ToList();

            Assert.Single(posts);
            Assert.Equal(list[0].Id, posts[0].VideoId);
            repository.Verify(x => x.AllAsNoTracking(), Times.AtMost(2));
        }

        [Fact]
        public void SearchByUsernameShouldReturnZeroWhenNone()
        {
            var list = new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Likes = 0,
                    Dislikes = 3,
                    CreatedOn = new DateTime(2000, 11, 20),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 1),
                    },
                },
                new Post
                {
                    Id = 2,
                    Likes = 0,
                    Dislikes = 2,
                    CreatedOn = new DateTime(2000, 11, 21),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho2",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first2",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second2",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption2",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 2),
                    },
                },
                new Post
                {
                    Id = 3,
                    Likes = 0,
                    Dislikes = 1,
                    CreatedOn = new DateTime(2000, 11, 22),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho3",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first3",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second3",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption3",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 3),
                    },
                },
                new Post
                {
                    Id = 4,
                    Likes = 0,
                    Dislikes = 0,
                    CreatedOn = new DateTime(2000, 11, 23),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho4",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first4",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second4",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption4",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 4),
                    },
                },
                new Post
                {
                    Id = 5,
                    Likes = 0,
                    Dislikes = 4,
                    CreatedOn = new DateTime(2000, 11, 24),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho5",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first5",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second5",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption5",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 5),
                    },
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new VideoPostsNewest(repository.Object);

            var posts = service.SearchByUsername(0, "gosho", 2).ToList();

            Assert.Empty(posts);
            repository.Verify(x => x.AllAsNoTracking(), Times.Once);
        }

        [Fact]
        public void SearchByCameraShouldReturnTwoElementWhenThereMoreThanTwo()
        {
            var list = new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Likes = 0,
                    Dislikes = 3,
                    CreatedOn = new DateTime(2000, 11, 20),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 1),
                    },
                },
                new Post
                {
                    Id = 2,
                    Likes = 1,
                    Dislikes = 2,
                    CreatedOn = new DateTime(2000, 11, 21),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho2",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first2",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second2",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption2",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 2),
                    },
                },
                new Post
                {
                    Id = 3,
                    Likes = 2,
                    Dislikes = 1,
                    CreatedOn = new DateTime(2000, 11, 22),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho3",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first3",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second3",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption3",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 3),
                    },
                },
                new Post
                {
                    Id = 4,
                    Likes = 3,
                    Dislikes = 0,
                    CreatedOn = new DateTime(2000, 11, 23),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first4",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second4",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption4",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 4),
                    },
                },
                new Post
                {
                    Id = 5,
                    Likes = 4,
                    Dislikes = 4,
                    CreatedOn = new DateTime(2000, 11, 24),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first5",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second5",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption5",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 5),
                    },
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new VideoPostsNewest(repository.Object);

            var posts = service.SearchByCamera(0, "Iphone", 2).ToList();

            Assert.Equal(2, posts.Count);
            Assert.Equal(list[4].Id, posts[0].VideoId);
            Assert.Equal(list[3].Id, posts[1].VideoId);
            repository.Verify(x => x.AllAsNoTracking(), Times.AtMost(2));
        }

        [Fact]
        public void SearchByCameraShouldReturnSecondTwoElementWhenThereMoreThanFour()
        {
            var list = new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Likes = 0,
                    Dislikes = 3,
                    CreatedOn = new DateTime(2000, 11, 20),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 1),
                    },
                },
                new Post
                {
                    Id = 2,
                    Likes = 1,
                    Dislikes = 2,
                    CreatedOn = new DateTime(2000, 11, 21),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho2",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first2",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second2",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption2",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 2),
                    },
                },
                new Post
                {
                    Id = 3,
                    Likes = 2,
                    Dislikes = 1,
                    CreatedOn = new DateTime(2000, 11, 22),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho3",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first3",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second3",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption3",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 3),
                    },
                },
                new Post
                {
                    Id = 4,
                    Likes = 3,
                    Dislikes = 0,
                    CreatedOn = new DateTime(2000, 11, 23),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first4",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second4",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption4",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 4),
                    },
                },
                new Post
                {
                    Id = 5,
                    Likes = 4,
                    Dislikes = 4,
                    CreatedOn = new DateTime(2000, 11, 24),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first5",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second5",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption5",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 5),
                    },
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new VideoPostsNewest(repository.Object);

            var posts = service.SearchByCamera(1, "Iphone", 2).ToList();

            Assert.Equal(2, posts.Count);
            Assert.Equal(list[2].Id, posts[0].VideoId);
            Assert.Equal(list[1].Id, posts[1].VideoId);
            repository.Verify(x => x.AllAsNoTracking(), Times.AtMost(2));
        }

        [Fact]
        public void SearchByCameraShouldReturnFirstElementWhenThereLessThanTwo()
        {
            var list = new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Likes = 0,
                    Dislikes = 3,
                    CreatedOn = new DateTime(2000, 11, 20),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Huawei",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 1),
                    },
                },
                new Post
                {
                    Id = 2,
                    Likes = 1,
                    Dislikes = 2,
                    CreatedOn = new DateTime(2000, 11, 21),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho2",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first2",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second2",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption2",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 2),
                    },
                },
                new Post
                {
                    Id = 3,
                    Likes = 2,
                    Dislikes = 1,
                    CreatedOn = new DateTime(2000, 11, 22),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho3",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first3",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second3",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption3",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 3),
                    },
                },
                new Post
                {
                    Id = 4,
                    Likes = 3,
                    Dislikes = 0,
                    CreatedOn = new DateTime(2000, 11, 23),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first4",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second4",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption4",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 4),
                    },
                },
                new Post
                {
                    Id = 5,
                    Likes = 4,
                    Dislikes = 4,
                    CreatedOn = new DateTime(2000, 11, 24),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first5",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second5",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption5",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 5),
                    },
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new VideoPostsNewest(repository.Object);

            var posts = service.SearchByCamera(0, "Huawei", 2).ToList();

            Assert.Single(posts);
            Assert.Equal(list[0].Id, posts[0].VideoId);
            repository.Verify(x => x.AllAsNoTracking(), Times.AtMost(2));
        }

        [Fact]
        public void SearchByCameraShouldReturnThirElementWhenThereLessThanFour()
        {
            var list = new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Likes = 0,
                    Dislikes = 3,
                    CreatedOn = new DateTime(2000, 11, 20),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 1),
                    },
                },
                new Post
                {
                    Id = 2,
                    Likes = 1,
                    Dislikes = 2,
                    CreatedOn = new DateTime(2000, 11, 21),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho2",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first2",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second2",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption2",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 2),
                    },
                },
                new Post
                {
                    Id = 3,
                    Likes = 2,
                    Dislikes = 1,
                    CreatedOn = new DateTime(2000, 11, 22),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho3",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first3",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second3",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption3",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 3),
                    },
                },
                new Post
                {
                    Id = 4,
                    Likes = 3,
                    Dislikes = 0,
                    CreatedOn = new DateTime(2000, 11, 23),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first4",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second4",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption4",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone7",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 4),
                    },
                },
                new Post
                {
                    Id = 5,
                    Likes = 4,
                    Dislikes = 4,
                    CreatedOn = new DateTime(2000, 11, 24),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first5",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second5",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption5",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone7",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 5),
                    },
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new VideoPostsNewest(repository.Object);

            var posts = service.SearchByCamera(1, "Iphone6", 2).ToList();

            Assert.Single(posts);
            Assert.Equal(list[0].Id, posts[0].VideoId);
            repository.Verify(x => x.AllAsNoTracking(), Times.AtMost(2));
        }

        [Fact]
        public void SearchByCameraShouldReturnZeroElementWhenThereNone()
        {
            var list = new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Likes = 0,
                    Dislikes = 3,
                    CreatedOn = new DateTime(2000, 11, 20),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 1),
                    },
                },
                new Post
                {
                    Id = 2,
                    Likes = 1,
                    Dislikes = 2,
                    CreatedOn = new DateTime(2000, 11, 21),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho2",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first2",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second2",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption2",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 2),
                    },
                },
                new Post
                {
                    Id = 3,
                    Likes = 2,
                    Dislikes = 1,
                    CreatedOn = new DateTime(2000, 11, 22),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho3",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first3",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second3",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption3",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 3),
                    },
                },
                new Post
                {
                    Id = 4,
                    Likes = 3,
                    Dislikes = 0,
                    CreatedOn = new DateTime(2000, 11, 23),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first4",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second4",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption4",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 4),
                    },
                },
                new Post
                {
                    Id = 5,
                    Likes = 4,
                    Dislikes = 4,
                    CreatedOn = new DateTime(2000, 11, 24),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first5",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second5",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption5",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 5),
                    },
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new VideoPostsNewest(repository.Object);

            var posts = service.SearchByCamera(1, "Samsung", 2).ToList();

            Assert.Empty(posts);
            repository.Verify(x => x.AllAsNoTracking(), Times.Once);
        }

        [Fact]
        public void SearchByLocationShouldReturnTwoElementWhenThereMoreThanTwo()
        {
            var list = new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Likes = 0,
                    Dislikes = 3,
                    CreatedOn = new DateTime(2000, 11, 20),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 1),
                    },
                },
                new Post
                {
                    Id = 2,
                    Likes = 1,
                    Dislikes = 2,
                    CreatedOn = new DateTime(2000, 11, 21),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho2",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first2",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second2",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption2",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 2),
                    },
                },
                new Post
                {
                    Id = 3,
                    Likes = 2,
                    Dislikes = 1,
                    CreatedOn = new DateTime(2000, 11, 22),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho3",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first3",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second3",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption3",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 3),
                    },
                },
                new Post
                {
                    Id = 4,
                    Likes = 3,
                    Dislikes = 0,
                    CreatedOn = new DateTime(2000, 11, 23),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first4",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second4",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption4",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 4),
                    },
                },
                new Post
                {
                    Id = 5,
                    Likes = 4,
                    Dislikes = 4,
                    CreatedOn = new DateTime(2000, 11, 24),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first5",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second5",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption5",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 5),
                    },
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new VideoPostsNewest(repository.Object);

            var posts = service.SearchByLocation(0, "Plovdiv", 2).ToList();

            Assert.Equal(2, posts.Count());
            Assert.Equal(list[4].Id, posts[0].VideoId);
            Assert.Equal(list[3].Id, posts[1].VideoId);
            repository.Verify(x => x.AllAsNoTracking(), Times.AtMost(2));
        }

        [Fact]
        public void SearchByLocationShouldReturnSecondTwoElementWhenThereMoreThanFour()
        {
            var list = new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Likes = 0,
                    Dislikes = 3,
                    CreatedOn = new DateTime(2000, 11, 20),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 1),
                    },
                },
                new Post
                {
                    Id = 2,
                    Likes = 1,
                    Dislikes = 2,
                    CreatedOn = new DateTime(2000, 11, 21),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho2",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first2",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second2",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption2",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 2),
                    },
                },
                new Post
                {
                    Id = 3,
                    Likes = 2,
                    Dislikes = 1,
                    CreatedOn = new DateTime(2000, 11, 22),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho3",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first3",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second3",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption3",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 3),
                    },
                },
                new Post
                {
                    Id = 4,
                    Likes = 3,
                    Dislikes = 0,
                    CreatedOn = new DateTime(2000, 11, 23),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first4",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second4",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption4",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 4),
                    },
                },
                new Post
                {
                    Id = 5,
                    Likes = 4,
                    Dislikes = 4,
                    CreatedOn = new DateTime(2000, 11, 24),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first5",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second5",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption5",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 5),
                    },
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new VideoPostsNewest(repository.Object);

            var posts = service.SearchByLocation(1, "Plovdiv", 2).ToList();

            Assert.Equal(2, posts.Count());
            Assert.Equal(list[2].Id, posts[0].VideoId);
            Assert.Equal(list[1].Id, posts[1].VideoId);
            repository.Verify(x => x.AllAsNoTracking(), Times.AtMost(2));
        }

        [Fact]
        public void SearchByLocationShouldReturnFirstElementWhenThereLessThanTwo()
        {
            var list = new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Likes = 0,
                    Dislikes = 3,
                    CreatedOn = new DateTime(2000, 11, 20),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption",
                    Location = new Location
                    {
                        Name = "Sofia/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 1),
                    },
                },
                new Post
                {
                    Id = 2,
                    Likes = 1,
                    Dislikes = 2,
                    CreatedOn = new DateTime(2000, 11, 21),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho2",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first2",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second2",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption2",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 2),
                    },
                },
                new Post
                {
                    Id = 3,
                    Likes = 2,
                    Dislikes = 1,
                    CreatedOn = new DateTime(2000, 11, 22),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho3",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first3",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second3",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption3",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 3),
                    },
                },
                new Post
                {
                    Id = 4,
                    Likes = 3,
                    Dislikes = 0,
                    CreatedOn = new DateTime(2000, 11, 23),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first4",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second4",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption4",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 4),
                    },
                },
                new Post
                {
                    Id = 5,
                    Likes = 4,
                    Dislikes = 4,
                    CreatedOn = new DateTime(2000, 11, 24),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first5",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second5",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption5",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 5),
                    },
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new VideoPostsNewest(repository.Object);

            var posts = service.SearchByLocation(0, "Sofia", 2).ToList();

            Assert.Single(posts);
            Assert.Equal(list[0].Id, posts[0].VideoId);
            repository.Verify(x => x.AllAsNoTracking(), Times.AtMost(2));
        }

        [Fact]
        public void SearchByLocationShouldReturnThirdElementWhenThereLessThanFour()
        {
            var list = new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Likes = 0,
                    Dislikes = 3,
                    CreatedOn = new DateTime(2000, 11, 20),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 1),
                    },
                },
                new Post
                {
                    Id = 2,
                    Likes = 1,
                    Dislikes = 2,
                    CreatedOn = new DateTime(2000, 11, 21),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho2",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first2",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second2",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption2",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 2),
                    },
                },
                new Post
                {
                    Id = 3,
                    Likes = 2,
                    Dislikes = 1,
                    CreatedOn = new DateTime(2000, 11, 22),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho3",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first3",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second3",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption3",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 3),
                    },
                },
                new Post
                {
                    Id = 4,
                    Likes = 3,
                    Dislikes = 0,
                    CreatedOn = new DateTime(2000, 11, 23),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first4",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second4",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption4",
                    Location = new Location
                    {
                        Name = "Sofia/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 4),
                    },
                },
                new Post
                {
                    Id = 5,
                    Likes = 4,
                    Dislikes = 4,
                    CreatedOn = new DateTime(2000, 11, 24),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first5",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second5",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption5",
                    Location = new Location
                    {
                        Name = "Sofia/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 5),
                    },
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new VideoPostsNewest(repository.Object);

            var posts = service.SearchByLocation(1, "Plovdiv", 2).ToList();

            Assert.Single(posts);
            Assert.Equal(list[0].Id, posts[0].VideoId);
            repository.Verify(x => x.AllAsNoTracking(), Times.AtMost(2));
        }

        [Fact]
        public void SearchByLocationShouldReturnZeroElementsWhenThereAreNone()
        {
            var list = new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Likes = 0,
                    Dislikes = 3,
                    CreatedOn = new DateTime(2000, 11, 20),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 1),
                    },
                },
                new Post
                {
                    Id = 2,
                    Likes = 1,
                    Dislikes = 2,
                    CreatedOn = new DateTime(2000, 11, 21),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho2",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first2",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second2",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption2",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 2),
                    },
                },
                new Post
                {
                    Id = 3,
                    Likes = 2,
                    Dislikes = 1,
                    CreatedOn = new DateTime(2000, 11, 22),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho3",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first3",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second3",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption3",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 3),
                    },
                },
                new Post
                {
                    Id = 4,
                    Likes = 3,
                    Dislikes = 0,
                    CreatedOn = new DateTime(2000, 11, 23),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first4",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second4",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption4",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 4),
                    },
                },
                new Post
                {
                    Id = 5,
                    Likes = 4,
                    Dislikes = 4,
                    CreatedOn = new DateTime(2000, 11, 24),
                    AddedByUser = new ApplicationUser
                    {
                        UserName = "Pesho1",
                    },
                    Tags = new List<PostTag>
                    {
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#first5",
                            },
                        },
                        new PostTag
                        {
                            Tag = new Tag
                            {
                                Name = "#second5",
                            },
                        },
                    },
                    Type = new PostType
                    {
                        Name = "Video",
                    },
                    Caption = "testCaption5",
                    Location = new Location
                    {
                        Name = "Plovdiv/Bulgaria",
                    },
                    Camera = new Camera
                    {
                        Model = "Iphone6",
                    },
                    Video = new Video
                    {
                        VideoUrl = "https://test1",
                        Length = new TimeSpan(0, 0, 5),
                    },
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new VideoPostsNewest(repository.Object);

            var posts = service.SearchByLocation(1, "Burgas", 2).ToList();

            Assert.Empty(posts);
            repository.Verify(x => x.AllAsNoTracking(), Times.Once);
        }
    }
}
