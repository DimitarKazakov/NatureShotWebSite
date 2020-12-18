namespace NatureShot.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;
    using NatureShot.Services.Data.Contracts;

    public class CountriesService : ICountriesService
    {
        private readonly IDeletableEntityRepository<Country> countryRepository;

        public CountriesService(IDeletableEntityRepository<Country> countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        public async Task<Country> GetCountry(string name)
        {
            var country = this.countryRepository.All().FirstOrDefault(x => x.Name == name);
            if (country == null)
            {
                country = new Country
                {
                    Name = name,
                };

                await this.countryRepository.AddAsync(country);
                await this.countryRepository.SaveChangesAsync();
            }

            return country;
        }
    }
}
