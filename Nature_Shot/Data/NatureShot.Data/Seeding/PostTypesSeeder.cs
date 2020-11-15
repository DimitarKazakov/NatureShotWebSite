namespace NatureShot.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using NatureShot.Data.Models;

    public class PostTypesSeeder : ISeeder
    {
        public PostTypesSeeder()
        {
        }

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.PostTypes.Any())
            {
                return;
            }

            await dbContext.PostTypes.AddAsync(new PostType { Name = "Post" });
            await dbContext.PostTypes.AddAsync(new PostType { Name = "Image" });
            await dbContext.PostTypes.AddAsync(new PostType { Name = "Video" });

            await dbContext.SaveChangesAsync();
        }
    }
}
