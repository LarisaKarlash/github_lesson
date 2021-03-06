using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ObjectBD.Configurations;
using ObjectBD.Controllers;
using ObjectBD.Models;
using ObjectBD.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectBD
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //�������� �������� �� Action
            services.AddControllersWithViews(configure=>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                configure.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddScoped<IHumanRepository, HumanRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();

            services.UseMessageSender();
            //services.AddScoped<IMessageSender, EmailMessageSender>();
            //services.AddScoped<IMessageSender, SmsMessageSender>();

            // services.AddSingleton<IRestEkzClient, RestEkzClient>();
            services.AddScoped<IRestEkzClient, RestEkzClient>();

            services.AddSingleton<FileProcessingChannel>();

            services.AddMemoryCache();

            services.AddHostedService<LoadFileHostedService>();
            services.AddHostedService<UploadFileHostedService>();

            // services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ObjectBDDBContext>();
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ObjectBDDBContext>();          

            //�������������� ������ ������
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });

            services.AddDbContext<ObjectBDDBContext>(options =>
            options.UseSqlServer(_configuration.GetConnectionString("ObjectBDDbConnectionNew")).UseLazyLoadingProxies());
            //services.AddDbContext<ObjectBDDBContext>();

            //����������� � ������������ ������
            services.Configure<ObjectBDConfiguration>(_configuration.GetSection("ObjectBD"));
            services.Configure<FileConfiguration>(_configuration.GetSection("File"));

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseWriteToConsole("Hello");

            //app.UseSession();

            //app.Use(async (context, next) =>
            // {
            //     Console.WriteLine("Before");
            //     await next();
            //     Console.WriteLine("after");
            // });

            //app.Map("/Account", AccountHandling);

            //app.Run(async context =>
            //{
            //    Console.WriteLine("Before Run");
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        //private void AccountHandling(IApplicationBuilder app)
        //{
        //    app.Run(async context =>
        //    {
        //        Console.WriteLine("Run Map");
        //    });
        //}
    }
}
