namespace NatureShot.Services.Data
{
    using System;
    using System.Threading.Tasks;
    using NatureShot.Data.Models;

    public interface ICountriesService
    {
        Task<Country> GetCountry(string name);
    }
}
