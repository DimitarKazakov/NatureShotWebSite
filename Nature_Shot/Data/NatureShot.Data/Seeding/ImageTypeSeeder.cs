namespace NatureShot.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using NatureShot.Data.Models;

    public class ImageTypeSeeder : ISeeder
    {
        public ImageTypeSeeder()
        {
        }

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Tags.Any())
            {
                return;
            }

            await dbContext.ImageTypes.AddAsync(new ImageType { Name = "vertical" });
            await dbContext.ImageTypes.AddAsync(new ImageType { Name = "horizontal" });
            await dbContext.ImageTypes.AddAsync(new ImageType { Name = "small horizontal" });
            await dbContext.ImageTypes.AddAsync(new ImageType { Name = "small vertical" });
        }
    }
}
