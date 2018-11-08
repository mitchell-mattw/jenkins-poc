using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Identity.MongoDbCore;
using AspNetCore.Identity.MongoDbCore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoIDM.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDbGenericRepository;
using MongoIDM.Models;
using MongoIDM.Services;

namespace MongoIDM
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")));
                 services.AddIdentity<ApplicationUser, MongoIdentityRole>()
                .AddMongoDbStores<ApplicationUser, MongoIdentityRole, Guid>("mongodb://localhost:27017", "identities")
                .AddDefaultTokenProviders();

            //services.AddIdentity<ApplicationUser, MongoIdentityRole>()
            //    .AddMongoDbStores<ApplicationUser, MongoIdentityRole, Guid>
            //    (
            //        "mongodb://localhost:27017",
            //        "identities"
            //    )
            //.AddDefaultTokenProviders();


            //var mongoDbContext = new MongoDbContext("mongodb://localhost:27017", "MongoDbTests");
            //services.AddIdentity<ApplicationUser, MongoIdentityRole>()
            //    .AddMongoDbStores<IMongoDbContext>(mongoDbContext)
            //    .AddDefaultTokenProviders();
            ////services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<ApplicationDbContext>();
           
            //services.AddIdentityMongoDbProvider<ApplicationUser, ApplicationRole>(options =>
            //{
            //    options.ConnectionString = "mongodb://localhost/maddalena";

            //    options.Password.RequiredLength = 6;

            //    options.Password.RequireLowercase = false;

            //    options.Password.RequireUppercase = false;

            //    options.Password.RequireNonAlphanumeric = false;

            //    options.Password.RequireDigit = false;

            //});

            // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddRazorPagesOptions(options =>
                {
                    options.AllowAreas = true;
                    options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
                    options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
                });
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });
            //services.AddMvc().AddRazorPagesOptions(o => o.Conventions.AddAreaFolderRouteModelConvention("Identity", "/Account/", model =>
            //    {
            //        foreach (var selector in model.Selectors)
            //        {
            //            var attributeRouteModel = selector.AttributeRouteModel;
            //            attributeRouteModel.Order = -1;
            //            attributeRouteModel.Template = attributeRouteModel.Template.Remove(0, "Identity".Length);
            //        }
            //    })
            //).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //// Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
