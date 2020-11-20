namespace NatureShot.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using NatureShot.Data.Models;

    public interface ILocationsService
    {
        Task<Location> GetLocation(string locationName, Country country);

        IEnumerable<KeyValuePair<string, string>> GetAllLocationsAsKeyValuePair();
    }
}
