namespace NatureShot.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using NatureShot.Data.Models;

    public class TagSeeder : ISeeder
    {
        public TagSeeder()
        {
        }

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Tags.Any())
            {
                return;
            }

            await dbContext.Tags.AddAsync(new Tag { Name = "#nature" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#night" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#day" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#mountains" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#mountains" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#lake" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#river" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#home" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#hot" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#cold" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#freezing" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#town" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#city" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#village" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#photo" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#new camera" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#video" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#sad" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#happy" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#boring" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#angry" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#dog" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#cat" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#animal" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#sun" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#moon" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#plants" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#green" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#red" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#blue" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#brown" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#black" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#white" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#yellow" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#winter" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#summer" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#autumn" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#spring" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#clouds" });
            await dbContext.Tags.AddAsync(new Tag { Name = "#rain" });

            await dbContext.SaveChangesAsync();
        }
    }
}
