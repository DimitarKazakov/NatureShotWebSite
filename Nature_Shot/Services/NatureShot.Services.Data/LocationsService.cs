namespace NatureShot.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;
    using NatureShot.Services.Data.Contracts;

    public class LocationsService : ILocationsService
    {
        private readonly IRepository<Location> locationRepository;

        public LocationsService(IRepository<Location> locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllLocationsAsKeyValuePair()
        {
            return this.locationRepository.AllAsNoTracking()
                                          .Select(x => new
                                          {
                                              x.Id,
                                              x.Name,
                                          })
                                          .Distinct()
                                          .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }

        public async Task<Location> GetLocation(string locationName, Country country)
        {
            var location = this.locationRepository.All().FirstOrDefault(x => x.Name == locationName + "/" + country.Name);
            if (location == null)
            {
                location = new Location
                {
                    Name = locationName + "/" + country.Name,
                    Country = country,
                };

                await this.locationRepository.AddAsync(location);
                await this.locationRepository.SaveChangesAsync();
            }

            return location;
        }
    }
}
