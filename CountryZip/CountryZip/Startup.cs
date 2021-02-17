using CountryZip.Configurations;
using CountryZip.Models;
using CountryZip.Models.Repositories;
using CountryZip.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryZip
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
            //services.AddControllersWithViews();

            //Создание запретов на Action
            services.AddControllersWithViews(configure =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                configure.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ObjCountryDBContext>();

            //переопределяем логику пароля
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });

            services.AddDbContext<ObjCountryDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("CountryZipDbConnectionNew")).UseLazyLoadingProxies());

            services.AddScoped<ICountryNsiRepositories, CountryNsiRepositories>();
            services.AddScoped<ICountryZpRepositories, CountryZpRepositories>();
            services.AddScoped<IPlaceZpRepositories, PlaceZpRepositories>();
            services.AddScoped<IMessageSender, EmailMessageSender>();

            services.AddSingleton<IRestZipClient, RestZipClient>();
            services.AddSingleton<WebSocketHandler>();

            //привязывает к конфигурации секцию
            services.Configure<CountryZipConfiguration>(Configuration.GetSection("CountryZip"));
            services.Configure<FileConfiguration>(Configuration.GetSection("File"));

            services.AddMemoryCache();

            services.AddHostedService<LoadFileHostedService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseWebSockets();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
