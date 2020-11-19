namespace NatureShot.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using NatureShot.Scraping;
    using NatureShot.Data.Models;
    using System.Collections.Generic;

    public class LocationSeeder : ISeeder
    {
        public LocationSeeder()
        {
        }

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Locations.Any())
            {
                return;
            }

            var locationNames = new List<string>();
            await dbContext.Locations.AddAsync(new Location { Name = "/Bulgaria", Country = new Country { Name = "Bulgaria" } });
            await dbContext.Locations.AddAsync(new Location { Name = "/Germany", Country = new Country { Name = "Germany" } });
            await dbContext.Locations.AddAsync(new Location { Name = "/Greece", Country = new Country { Name = "Greece" } });
            await dbContext.Locations.AddAsync(new Location { Name = "/Macedonia", Country = new Country { Name = "Macedonia" } });
            await dbContext.Locations.AddAsync(new Location { Name = "/Serbia", Country = new Country { Name = "Serbia" } });
            await dbContext.Locations.AddAsync(new Location { Name = "/Romania", Country = new Country { Name = "Romania" } });
            await dbContext.Locations.AddAsync(new Location { Name = "/Turkey", Country = new Country { Name = "Turkey" } });
            await dbContext.Locations.AddAsync(new Location { Name = "/Norway", Country = new Country { Name = "Norway" } });
            await dbContext.Locations.AddAsync(new Location { Name = "/Finland", Country = new Country { Name = "Finland" } });
            await dbContext.Locations.AddAsync(new Location { Name = "/France", Country = new Country { Name = "France" } });
            await dbContext.Locations.AddAsync(new Location { Name = "/Italy", Country = new Country { Name = "Italy" } });
            await dbContext.Locations.AddAsync(new Location { Name = "/England", Country = new Country { Name = "England" } });

            await Program.GetTowns(locationNames);
            var country = new Country { Name = "Bulgaria" };
            foreach (var town in locationNames)
            {
                await dbContext.Locations.AddAsync(new Location { Name = town + "/" + country.Name, Country = country, Town = new Town { Name = town, Country = country } });
            }

            locationNames.Clear();
            Program.GetCaves(locationNames);
            Program.GetLakes(locationNames);
            await Program.GetMountains(locationNames);
            await Program.GetRivers(locationNames);

            foreach (var location in locationNames)
            {
                await dbContext.Locations.AddAsync(new Location { Name = location + " / " + country.Name, Country = country });
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
