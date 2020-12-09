namespace NatureShot.Services.Data.Tests.NormalPostsTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Moq;
    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;
    using NatureShot.Services.Data;
    using NatureShot.Services.Data.NormalPosts;
    using Xunit;

    public class NormalPostsOldestTests
    {
        public NormalPostsOldestTests()
        {
        }

        [Fact]
        public void GetNormalPostsOldestShouldReturnFirstTwoElementsWhenThereAreTwoOrMore()
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
                        Name = "Post",
                    },
                    Caption = "testCaption",
                },
                new Post
                {
                    Id = 2,
                    Likes = 2,
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
                        Name = "Post",
                    },
                    Caption = "testCaption2",
                },
                new Post
                {
                    Id = 3,
                    Likes = 1,
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
                        Name = "Post",
                    },
                    Caption = "testCaption3",
                },
                new Post
                {
                    Id = 4,
                    Likes = 4,
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
                        Name = "Post",
                    },
                    Caption = "testCaption4",
                },
                new Post
                {
                    Id = 5,
                    Likes = 3,
                    Dislikes = 3,
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
                        Name = "Post",
                    },
                    Caption = "testCaption5",
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new NormalPostsOldest(repository.Object);

            var posts = service.GetNormalPostsOldest(0, 2).ToList();

            Assert.Equal(2, posts.Count());
            Assert.Equal(list[0].Id, int.Parse(posts[0].PostId));
            Assert.Equal(list[1].Id, int.Parse(posts[1].PostId));
            repository.Verify(x => x.AllAsNoTracking(), Times.AtMost(2));
        }

        [Fact]
        public void GetNormalPostsOldestShouldReturnSecondTwoElementsWhenThereAreFourOrMore()
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
                        Name = "Post",
                    },
                    Caption = "testCaption",
                },
                new Post
                {
                    Id = 2,
                    Likes = 2,
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
                        Name = "Post",
                    },
                    Caption = "testCaption2",
                },
                new Post
                {
                    Id = 3,
                    Likes = 1,
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
                        Name = "Post",
                    },
                    Caption = "testCaption3",
                },
                new Post
                {
                    Id = 4,
                    Likes = 4,
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
                        Name = "Post",
                    },
                    Caption = "testCaption4",
                },
                new Post
                {
                    Id = 5,
                    Likes = 3,
                    Dislikes = 3,
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
                        Name = "Post",
                    },
                    Caption = "testCaption5",
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new NormalPostsOldest(repository.Object);

            var posts = service.GetNormalPostsOldest(1, 2).ToList();

            Assert.Equal(2, posts.Count());
            Assert.Equal(list[2].Id, int.Parse(posts[0].PostId));
            Assert.Equal(list[3].Id, int.Parse(posts[1].PostId));
            repository.Verify(x => x.AllAsNoTracking(), Times.AtMost(2));
        }

        [Fact]
        public void GetNormalPostsOldestShouldReturnFirstElementWhenThereAreLessThanTwo()
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
                        Name = "Post",
                    },
                    Caption = "testCaption",
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new NormalPostsOldest(repository.Object);

            var posts = service.GetNormalPostsOldest(0, 2).ToList();

            Assert.Single(posts);
            Assert.Equal(list[0].Id, int.Parse(posts[0].PostId));
            repository.Verify(x => x.AllAsNoTracking(), Times.AtMost(2));
        }

        [Fact]
        public void GetNormalPostsOldestShouldReturnThirdElementWhenThereAreThree()
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
                        Name = "Post",
                    },
                    Caption = "testCaption",
                },
                new Post
                {
                    Id = 2,
                    Likes = 2,
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
                        Name = "Post",
                    },
                    Caption = "testCaption2",
                },
                new Post
                {
                    Id = 3,
                    Likes = 1,
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
                        Name = "Post",
                    },
                    Caption = "testCaption3",
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new NormalPostsOldest(repository.Object);

            var posts = service.GetNormalPostsOldest(1, 2).ToList();

            Assert.Single(posts);
            Assert.Equal(list[2].Id, int.Parse(posts[0].PostId));
            repository.Verify(x => x.AllAsNoTracking(), Times.AtMost(2));
        }

        [Fact]
        public void GetNormalPostsOldestShouldReturnZeroWhenEmpty()
        {
            var list = new List<Post>();
            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new NormalPostsOldest(repository.Object);

            var posts = service.GetNormalPostsOldest(0, 2).ToList();

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
                        Name = "Post",
                    },
                    Caption = "testCaption",
                },
                new Post
                {
                    Id = 2,
                    Likes = 2,
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
                        Name = "Post",
                    },
                    Caption = "testCaption2",
                },
                new Post
                {
                    Id = 3,
                    Likes = 1,
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
                        Name = "Post",
                    },
                    Caption = "testCaption3",
                },
                new Post
                {
                    Id = 4,
                    Likes = 4,
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
                        Name = "Post",
                    },
                    Caption = "testCaption4",
                },
                new Post
                {
                    Id = 5,
                    Likes = 3,
                    Dislikes = 3,
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
                        Name = "Post",
                    },
                    Caption = "testCaption5",
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new NormalPostsOldest(repository.Object);

            var posts = service.SearchByCaption(0, "testCaption", 2).ToList();

            Assert.Equal(2, posts.Count());
            Assert.Equal(list[0].Id, int.Parse(posts[0].PostId));
            Assert.Equal(list[1].Id, int.Parse(posts[1].PostId));
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
                        Name = "Post",
                    },
                    Caption = "testCaption",
                },
                new Post
                {
                    Id = 2,
                    Likes = 2,
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
                        Name = "Post",
                    },
                    Caption = "testCaption2",
                },
                new Post
                {
                    Id = 3,
                    Likes = 1,
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
                        Name = "Post",
                    },
                    Caption = "testCaption3",
                },
                new Post
                {
                    Id = 4,
                    Likes = 4,
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
                        Name = "Post",
                    },
                    Caption = "testCaption4",
                },
                new Post
                {
                    Id = 5,
                    Likes = 3,
                    Dislikes = 3,
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
                        Name = "Post",
                    },
                    Caption = "testCaption5",
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new NormalPostsOldest(repository.Object);

            var posts = service.SearchByCaption(1, "testCaption", 2).ToList();

            Assert.Equal(2, posts.Count());
            Assert.Equal(list[2].Id, int.Parse(posts[0].PostId));
            Assert.Equal(list[3].Id, int.Parse(posts[1].PostId));
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
                        Name = "Post",
                    },
                    Caption = "testCaption",
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new NormalPostsOldest(repository.Object);

            var posts = service.SearchByCaption(0, "testCaption", 2).ToList();

            Assert.Single(posts);
            Assert.Equal(list[0].Id, int.Parse(posts[0].PostId));
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
                        Name = "Post",
                    },
                    Caption = "testCaption",
                },
                new Post
                {
                    Id = 2,
                    Likes = 2,
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
                        Name = "Post",
                    },
                    Caption = "testCaption2",
                },
                new Post
                {
                    Id = 3,
                    Likes = 1,
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
                        Name = "Post",
                    },
                    Caption = "testCaption3",
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new NormalPostsOldest(repository.Object);

            var posts = service.SearchByCaption(1, "testCaption", 2).ToList();

            Assert.Single(posts);
            Assert.Equal(list[2].Id, int.Parse(posts[0].PostId));
            repository.Verify(x => x.AllAsNoTracking(), Times.AtMost(2));
        }

        [Fact]
        public void SearchByCaptionShouldReturnZeroElementsWhenEmpty()
        {
            var list = new List<Post>();

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new NormalPostsOldest(repository.Object);

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
                        Name = "Post",
                    },
                    Caption = "testCaption",
                },
                new Post
                {
                    Id = 2,
                    Likes = 2,
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
                        Name = "Post",
                    },
                    Caption = "testCaption2",
                },
                new Post
                {
                    Id = 3,
                    Likes = 1,
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
                        Name = "Post",
                    },
                    Caption = "testCaption3",
                },
                new Post
                {
                    Id = 4,
                    Likes = 4,
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
                        Name = "Post",
                    },
                    Caption = "testCaption4",
                },
                new Post
                {
                    Id = 5,
                    Likes = 3,
                    Dislikes = 3,
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
                        Name = "Post",
                    },
                    Caption = "testCaption5",
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new NormalPostsOldest(repository.Object);

            var posts = service.SearchByTags(0, "#first", 2).ToList();

            Assert.Equal(2, posts.Count());
            Assert.Equal(list[0].Id, int.Parse(posts[0].PostId));
            Assert.Equal(list[4].Id, int.Parse(posts[1].PostId));
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
                        Name = "Post",
                    },
                    Caption = "testCaption",
                },
                new Post
                {
                    Id = 2,
                    Likes = 2,
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
                        Name = "Post",
                    },
                    Caption = "testCaption2",
                },
                new Post
                {
                    Id = 3,
                    Likes = 1,
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
                        Name = "Post",
                    },
                    Caption = "testCaption3",
                },
                new Post
                {
                    Id = 4,
                    Likes = 4,
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
                        Name = "Post",
                    },
                    Caption = "testCaption4",
                },
                new Post
                {
                    Id = 5,
                    Likes = 3,
                    Dislikes = 3,
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
                        Name = "Post",
                    },
                    Caption = "testCaption5",
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new NormalPostsOldest(repository.Object);

            var posts = service.SearchByTags(1, "#first", 2).ToList();

            Assert.Equal(2, posts.Count());
            Assert.Equal(list[2].Id, int.Parse(posts[0].PostId));
            Assert.Equal(list[3].Id, int.Parse(posts[1].PostId));
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
                        Name = "Post",
                    },
                    Caption = "testCaption",
                },
                new Post
                {
                    Id = 2,
                    Likes = 2,
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
                        Name = "Post",
                    },
                    Caption = "testCaption2",
                },
                new Post
                {
                    Id = 3,
                    Likes = 1,
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
                        Name = "Post",
                    },
                    Caption = "testCaption3",
                },
                new Post
                {
                    Id = 4,
                    Likes = 4,
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
                        Name = "Post",
                    },
                    Caption = "testCaption4",
                },
                new Post
                {
                    Id = 5,
                    Likes = 3,
                    Dislikes = 3,
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
                        Name = "Post",
                    },
                    Caption = "testCaption5",
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new NormalPostsOldest(repository.Object);

            var posts = service.SearchByTags(0, "#first", 2).ToList();

            Assert.Single(posts);
            Assert.Equal(list[0].Id, int.Parse(posts[0].PostId));
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
                        Name = "Post",
                    },
                    Caption = "testCaption",
                },
                new Post
                {
                    Id = 2,
                    Likes = 2,
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
                        Name = "Post",
                    },
                    Caption = "testCaption2",
                },
                new Post
                {
                    Id = 3,
                    Likes = 1,
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
                        Name = "Post",
                    },
                    Caption = "testCaption3",
                },
                new Post
                {
                    Id = 4,
                    Likes = 4,
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
                        Name = "Post",
                    },
                    Caption = "testCaption4",
                },
                new Post
                {
                    Id = 5,
                    Likes = 3,
                    Dislikes = 3,
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
                        Name = "Post",
                    },
                    Caption = "testCaption5",
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new NormalPostsOldest(repository.Object);

            var posts = service.SearchByTags(1, "#first", 2).ToList();

            Assert.Single(posts);
            Assert.Equal(list[2].Id, int.Parse(posts[0].PostId));
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
                        Name = "Post",
                    },
                    Caption = "testCaption",
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
                        Name = "Post",
                    },
                    Caption = "testCaption2",
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
                        Name = "Post",
                    },
                    Caption = "testCaption3",
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
                        Name = "Post",
                    },
                    Caption = "testCaption4",
                },
                new Post
                {
                    Id = 5,
                    Likes = 0,
                    Dislikes = 3,
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
                        Name = "Post",
                    },
                    Caption = "testCaption5",
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new NormalPostsOldest(repository.Object);

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
                        Name = "Post",
                    },
                    Caption = "testCaption",
                },
                new Post
                {
                    Id = 2,
                    Likes = 2,
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
                        Name = "Post",
                    },
                    Caption = "testCaption2",
                },
                new Post
                {
                    Id = 3,
                    Likes = 1,
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
                        Name = "Post",
                    },
                    Caption = "testCaption3",
                },
                new Post
                {
                    Id = 4,
                    Likes = 4,
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
                        Name = "Post",
                    },
                    Caption = "testCaption4",
                },
                new Post
                {
                    Id = 5,
                    Likes = 3,
                    Dislikes = 3,
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
                        Name = "Post",
                    },
                    Caption = "testCaption5",
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new NormalPostsOldest(repository.Object);

            var posts = service.SearchByUsername(0, "pesho", 2).ToList();

            Assert.Equal(2, posts.Count());
            Assert.Equal(list[0].Id, int.Parse(posts[0].PostId));
            Assert.Equal(list[1].Id, int.Parse(posts[1].PostId));
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
                        Name = "Post",
                    },
                    Caption = "testCaption",
                },
                new Post
                {
                    Id = 2,
                    Likes = 2,
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
                        Name = "Post",
                    },
                    Caption = "testCaption2",
                },
                new Post
                {
                    Id = 3,
                    Likes = 1,
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
                        Name = "Post",
                    },
                    Caption = "testCaption3",
                },
                new Post
                {
                    Id = 4,
                    Likes = 4,
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
                        Name = "Post",
                    },
                    Caption = "testCaption4",
                },
                new Post
                {
                    Id = 5,
                    Likes = 3,
                    Dislikes = 3,
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
                        Name = "Post",
                    },
                    Caption = "testCaption5",
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new NormalPostsOldest(repository.Object);

            var posts = service.SearchByUsername(1, "pesho", 2).ToList();

            Assert.Equal(2, posts.Count());
            Assert.Equal(list[2].Id, int.Parse(posts[0].PostId));
            Assert.Equal(list[3].Id, int.Parse(posts[1].PostId));
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
                        Name = "Post",
                    },
                    Caption = "testCaption",
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
                        Name = "Post",
                    },
                    Caption = "testCaption2",
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
                        Name = "Post",
                    },
                    Caption = "testCaption3",
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
                        Name = "Post",
                    },
                    Caption = "testCaption4",
                },
                new Post
                {
                    Id = 5,
                    Likes = 0,
                    Dislikes = 3,
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
                        Name = "Post",
                    },
                    Caption = "testCaption5",
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new NormalPostsOldest(repository.Object);

            var posts = service.SearchByUsername(0, "pesho1", 2).ToList();

            Assert.Single(posts);
            Assert.Equal(list[0].Id, int.Parse(posts[0].PostId));
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
                        Name = "Post",
                    },
                    Caption = "testCaption",
                },
                new Post
                {
                    Id = 2,
                    Likes = 2,
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
                        Name = "Post",
                    },
                    Caption = "testCaption2",
                },
                new Post
                {
                    Id = 3,
                    Likes = 1,
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
                        Name = "Post",
                    },
                    Caption = "testCaption3",
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
                        Name = "Post",
                    },
                    Caption = "testCaption4",
                },
                new Post
                {
                    Id = 5,
                    Likes = 3,
                    Dislikes = 3,
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
                        Name = "Post",
                    },
                    Caption = "testCaption5",
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new NormalPostsOldest(repository.Object);

            var posts = service.SearchByUsername(1, "pesho1", 2).ToList();

            Assert.Single(posts);
            Assert.Equal(list[4].Id, int.Parse(posts[0].PostId));
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
                        Name = "Post",
                    },
                    Caption = "testCaption",
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
                        Name = "Post",
                    },
                    Caption = "testCaption2",
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
                        Name = "Post",
                    },
                    Caption = "testCaption3",
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
                        Name = "Post",
                    },
                    Caption = "testCaption4",
                },
                new Post
                {
                    Id = 5,
                    Likes = 0,
                    Dislikes = 3,
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
                        Name = "Post",
                    },
                    Caption = "testCaption5",
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Post>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new NormalPostsOldest(repository.Object);

            var posts = service.SearchByUsername(0, "gosho", 2).ToList();

            Assert.Empty(posts);
            repository.Verify(x => x.AllAsNoTracking(), Times.Once);
        }
    }
}
