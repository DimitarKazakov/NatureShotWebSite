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

    public class TagsServiceTests
    {
        public TagsServiceTests()
        {
        }

        [Fact]
        public void GetAllTagsAsKeyValuePairShouldReturnCorrectCount()
        {
            var list = new List<Tag>()
            {
                new Tag
                {
                    Id = 1,
                    Name = "#First",
                },
                new Tag
                {
                    Id = 2,
                    Name = "#Second",
                },
                new Tag
                {
                    Id = 3,
                    Name = "#Third",
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Tag>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new TagsService(repository.Object);

            var tags = service.GetAllTagsAsKeyValuePair();

            Assert.Equal(3, tags.Count());
            repository.Verify(x => x.AllAsNoTracking(), Times.Once);
        }

        [Fact]
        public void GetAllTagsAsKeyValuePairShouldReturnZeroWhenEmpty()
        {
            var list = new List<Tag>();

            var repository = new Mock<IDeletableEntityRepository<Tag>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new TagsService(repository.Object);

            var tags = service.GetAllTagsAsKeyValuePair();

            Assert.Empty(tags);
            repository.Verify(x => x.AllAsNoTracking(), Times.Once);
        }

        [Fact]
        public async Task GetTagsForPostShouldReturnCorrectTags()
        {
            var list = new List<Tag>()
            {
                new Tag
                {
                    Id = 1,
                    Name = "#first",
                },
                new Tag
                {
                    Id = 2,
                    Name = "#second",
                },
                new Tag
                {
                    Id = 3,
                    Name = "#third",
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Tag>>();
            repository.Setup(r => r.All()).Returns(() => list.AsQueryable());
            var service = new TagsService(repository.Object);

            var tags = await service.GetTagsForPost("#first #second #third");

            Assert.Equal(3, tags.Count());
            Assert.Equal(1, tags[0].Id);
            Assert.Equal(2, tags[1].Id);
            Assert.Equal(3, tags[2].Id);
            repository.Verify(x => x.All(), Times.AtLeastOnce);
        }

        [Fact]
        public async Task GetTagsForPostShouldAddIfDoesntFindTag()
        {
            var list = new List<Tag>()
            {
                new Tag
                {
                    Id = 1,
                    Name = "#first",
                },
                new Tag
                {
                    Id = 2,
                    Name = "#second",
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Tag>>();
            repository.Setup(r => r.All()).Returns(() => list.AsQueryable());
            repository.Setup(r => r.AddAsync(It.IsAny<Tag>())).Callback((Tag tag) => list.Add(tag));
            var service = new TagsService(repository.Object);

            var tags = await service.GetTagsForPost("#first #second #third");

            Assert.Equal(3, tags.Count());
            Assert.Equal(1, tags[0].Id);
            Assert.Equal(2, tags[1].Id);
            Assert.Equal("#third", tags[2].Name);
            repository.Verify(x => x.All(), Times.AtLeastOnce);
            repository.Verify(x => x.AddAsync(It.IsAny<Tag>()), Times.AtLeastOnce);
        }

        [Fact]
        public async Task GetTagsForPostShouldAddAllIfEmpty()
        {
            var list = new List<Tag>();

            var repository = new Mock<IDeletableEntityRepository<Tag>>();
            repository.Setup(r => r.All()).Returns(() => list.AsQueryable());
            repository.Setup(r => r.AddAsync(It.IsAny<Tag>())).Callback((Tag tag) => list.Add(tag));
            var service = new TagsService(repository.Object);

            var tags = await service.GetTagsForPost("#first #second third");

            Assert.Equal(3, tags.Count());
            Assert.Equal("#first", tags[0].Name);
            Assert.Equal("#second", tags[1].Name);
            Assert.Equal("#third", tags[2].Name);
            repository.Verify(x => x.All(), Times.AtLeastOnce);
            repository.Verify(x => x.AddAsync(It.IsAny<Tag>()), Times.AtLeastOnce);
        }
    }
}
