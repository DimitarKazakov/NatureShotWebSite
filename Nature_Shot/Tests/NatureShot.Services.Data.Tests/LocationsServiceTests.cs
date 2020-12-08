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

    public class LocationsServiceTests
    {
        public LocationsServiceTests()
        {
        }

        [Fact]
        public void GetAllLocationsAsKeyValuePairShouldReturnCorrectNumber()
        {
            var list = new List<Location>()
            {
                new Location
                {
                    Id = 1,
                    Name = "Plovdiv/Bulgaria",
                },
                new Location
                {
                    Id = 2,
                    Name = "Sofia/Bulgaria",
                },
                new Location
                {
                    Id = 3,
                    Name = "Stara Zagora/Bulgaria",
                },
            };

            var repository = new Mock<IRepository<Location>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new LocationsService(repository.Object);

            var locations = service.GetAllLocationsAsKeyValuePair();

            Assert.Equal(3, locations.Count());
            repository.Verify(x => x.AllAsNoTracking(), Times.Once);
        }

        [Fact]
        public void GetAllLocationsAsKeyValuePairShouldReturnZeroForEmptyDatabase()
        {
            var list = new List<Location>();

            var repository = new Mock<IRepository<Location>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(() => list.AsQueryable());
            var service = new LocationsService(repository.Object);

            var locations = service.GetAllLocationsAsKeyValuePair();

            Assert.Empty(locations);
            repository.Verify(x => x.AllAsNoTracking(), Times.Once);
        }

        [Fact]
        public async Task GetLocationShouldReturnTheCorrectLocation()
        {
            var list = new List<Location>()
            {
                new Location
                {
                    Id = 1,
                    Name = "Plovdiv/Bulgaria",
                    Country = new Country
                    {
                        Name = "Bulgaria",
                    },
                },
                new Location
                {
                    Id = 2,
                    Name = "Sofia/Bulgaria",
                    Country = new Country
                    {
                        Name = "Bulgaria",
                    },
                },
                new Location
                {
                    Id = 3,
                    Name = "Stara Zagora/Bulgaria",
                    Country = new Country
                    {
                        Name = "Bulgaria",
                    },
                },
            };

            var repository = new Mock<IRepository<Location>>();
            repository.Setup(r => r.All()).Returns(() => list.AsQueryable());
            var service = new LocationsService(repository.Object);

            var location = await service.GetLocation("Plovdiv", new Country { Name = "Bulgaria" });

            Assert.Equal(list[0].Name, location.Name);
            repository.Verify(x => x.All(), Times.Once);
        }

        [Fact]
        public async Task GetLocationShouldAddTheLocationIfItIsNotThere()
        {
            var list = new List<Location>()
            {
                new Location
                {
                    Id = 1,
                    Name = "Plovdiv/Bulgaria",
                    Country = new Country
                    {
                        Name = "Bulgaria",
                    },
                },
                new Location
                {
                    Id = 2,
                    Name = "Sofia/Bulgaria",
                    Country = new Country
                    {
                        Name = "Bulgaria",
                    },
                },
                new Location
                {
                    Id = 3,
                    Name = "Stara Zagora/Bulgaria",
                    Country = new Country
                    {
                        Name = "Bulgaria",
                    },
                },
            };

            var repository = new Mock<IRepository<Location>>();
            repository.Setup(r => r.All()).Returns(() => list.AsQueryable());
            repository.Setup(r => r.AddAsync(It.IsAny<Location>())).Callback((Location location) => list.Add(location));
            var service = new LocationsService(repository.Object);

            var location = await service.GetLocation("Peshtera", new Country { Name = "Bulgaria" });

            Assert.Equal("Peshtera/Bulgaria", location.Name);
            repository.Verify(x => x.AddAsync(It.IsAny<Location>()), Times.Once);
        }
    }
}
