namespace NatureShot.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Moq;
    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;
    using NatureShot.Services.Data;
    using Xunit;

    public class ContriesServiceTests
    {
        public ContriesServiceTests()
        {
        }

        [Fact]
        public async Task GetCountryShouldReturnCorrectCountry()
        {
            var list = new List<Country>()
            {
                new Country
                {
                    Id = 1,
                    Name = "Bulgaria",
                },
                new Country
                {
                    Id = 2,
                    Name = "Germany",
                },
                new Country
                {
                    Id = 3,
                    Name = "Greece",
                },
            };

            var repository = new Mock<IDeletableEntityRepository<Country>>();
            repository.Setup(r => r.All()).Returns(() => list.AsQueryable());
            var service = new CountriesService(repository.Object);

            var county = await service.GetCountry("Germany");

            Assert.Equal("Germany", county.Name);
            Assert.Equal(2, county.Id);
            repository.Verify(x => x.All(), Times.Once);
        }

        [Fact]
        public async Task GetCountryByNameShouldAddTheCountryWhenThereIsNotSuch()
        {
            var list = new List<Country>();

            var repository = new Mock<IDeletableEntityRepository<Country>>();
            repository.Setup(r => r.All()).Returns(() => list.AsQueryable());
            repository.Setup(r => r.AddAsync(It.IsAny<Country>())).Callback((Country country) => list.Add(country));
            var service = new CountriesService(repository.Object);

            var country = await service.GetCountry("Bulgaria");

            Assert.Equal("Bulgaria", country.Name);
            Assert.Equal(1, list.Count);
            repository.Verify(x => x.All(), Times.Once);
        }
    }
}
