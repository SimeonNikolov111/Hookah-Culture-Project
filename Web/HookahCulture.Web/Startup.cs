namespace HookahCulture.Web
{
    using System.Reflection;
    using ForumSystem.Services.Data;
    using HookahCulture.Data;
    using HookahCulture.Data.Common;
    using HookahCulture.Data.Common.Repositories;
    using HookahCulture.Data.Models;
    using HookahCulture.Data.Repositories;
    using HookahCulture.Data.Seeding;
    using HookahCulture.Services.Data;
    using HookahCulture.Services.Mapping;
    using HookahCulture.Services.Messaging;
    using HookahCulture.Web.Hub;
    using HookahCulture.Web.ViewModels;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        private readonly IConfiguration configuration;

        //adding test line
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options =>  options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<CookiePolicyOptions>(
                options =>
                    {
                        options.CheckConsentNeeded = context => true;
                        options.MinimumSameSitePolicy = SameSiteMode.None;
                    });



            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddSingleton(this.configuration);

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<IEmailSender>(x => new SendGridEmailSender(configuration.GetSection("SendGridApiKey").Value));
            services.AddTransient<ISettingsService, SettingsService>();
            services.AddTransient<IPostsService, PostsService>();
            services.AddTransient<LoginPageInfoService>();
            services.AddTransient<IVotesService, VotesService>();
            services.AddTransient<IGalleryVotesService, GalleryVotesService>();
            services.AddTransient<ICommentsService, CommentsService>();
            services.AddTransient<IUploadsService, UploadService>();
            services.AddTransient<IRolesService, RoleService>();
            services.AddTransient<IImagesService, ImageService>();
            services.AddTransient<IChatService, ChatService>();
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                //if (env.IsDevelopment())
                //{
                //}

                dbContext.Database.Migrate();


                //new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseStatusCodePagesWithRedirects("/Home/Error");
                //app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                    {
                        endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapControllerRoute("routeWithPaging", "{controller=Home}/{action=Index}/", new { controller = "Home", action = "Index"});
                        endpoints.MapControllerRoute("personalTimeline", "{controller=Timeline}/{action=PersonalTimeline}/", new { controler = "Timeline", action = "PersonalTimeline" });
                        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapRazorPages();
                        endpoints.MapHub<ChatHub>("/chat");
                    });
        }
    }
}
