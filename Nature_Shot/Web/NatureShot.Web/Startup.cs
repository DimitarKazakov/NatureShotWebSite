namespace NatureShot.Web
{
    using System.Reflection;
    using System.Web.Http.Cors;

    using CloudinaryDotNet;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using NatureShot.Data;
    using NatureShot.Data.Common;
    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;
    using NatureShot.Data.Repositories;
    using NatureShot.Data.Seeding;
    using NatureShot.Services.Data;
    using NatureShot.Services.Data.NormalPosts;
    using NatureShot.Services.Data.PhotoPosts;
    using NatureShot.Services.Mapping;
    using NatureShot.Services.Messaging;
    using NatureShot.Web.ViewModels;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<CookiePolicyOptions>(
                options =>
                    {
                        options.CheckConsentNeeded = context => true;
                        options.MinimumSameSitePolicy = SameSiteMode.None;
                    });

            // Social Account Login

            // services.AddAuthentication()
            //    .AddFacebook(
            //    options =>
            // {
            //    options.AppId = this.configuration["Facebook:AppId"];
            //    options.AppSecret = this.configuration["Facebook:AppSecret"];
            //    options.Events.OnRemoteFailure = (context) =>
            //    {
            //        context.Response.Redirect("/Identity/Account/Login");
            //        context.HandleResponse();
            //        return System.Threading.Tasks.Task.CompletedTask;
            //    };
            // });
            services.AddControllersWithViews(
                options =>
                    {
                        options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                    }).AddRazorRuntimeCompilation();
            services.AddRazorPages();

            services.AddSingleton(this.configuration);
            services.AddAntiforgery(options =>
            {
                options.HeaderName = "X-CSRF-TOKEN";
            });
            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<IEmailSender, NullMessageSender>();
            services.AddTransient<ISettingsService, SettingsService>();

            services.AddTransient<IPostsService, PostsService>();
            services.AddTransient<ICameraService, CameraService>();
            services.AddTransient<IImagesService, ImagesService>();
            services.AddTransient<ICountriesService, CountriesService>();
            services.AddTransient<ILocationsService, LocationsService>();
            services.AddTransient<ITagsService, TagsService>();
            services.AddTransient<IReactionService, ReactionService>();
            services.AddTransient<ICommentService, CommentService>();

            services.AddTransient<IPhotoPostsMostLikes, PhotoPostsMostLikes>();
            services.AddTransient<IPhotoPostsLeastLikes, PhotoPostsLeastLikes>();
            services.AddTransient<IPhotoPostsMostDislikes, PhotoPostsMostDislikes>();
            services.AddTransient<IPhotoPostsLeastDislikes, PhotoPostsLeastDislikes>();
            services.AddTransient<IPhotoPostsNewest, PhotoPostsNewest>();
            services.AddTransient<IPhotoPostsOldest, PhotoPostsOldest>();

            services.AddTransient<INormalPostsMostLikes, NormalPostsMostLikes>();
            services.AddTransient<INormalPostsLeastLikes, NormalPostsLeastLikes>();
            services.AddTransient<INormalPostsMostDislikes, NormalPostsMostDislikes>();
            services.AddTransient<INormalPostsLeastDislikes, NormalPostsLeastDislikes>();
            services.AddTransient<INormalPostsNewest, NormalPostsNewest>();
            services.AddTransient<INormalPostsOldest, NormalPostsOldest>();

            // Cloudinary Configuration
            Account account = new Account(
                    this.configuration["Cloudinary:AppName"],
                    this.configuration["Cloudinary:AppKey"],
                    this.configuration["Cloudinary:AppSecret"]);

            Cloudinary cloudinary = new Cloudinary(account);
            services.AddSingleton(cloudinary);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                    {
                        endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapRazorPages();
                    });
        }
    }
}
