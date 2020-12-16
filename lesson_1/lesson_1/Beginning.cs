using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lesson_1
{
    public class Beginning
    {
        private IConfiguration _configure { get; set; }
        public Beginning(IConfiguration configure )
        {
            _configure = configure;
        }
        public void ConfigureServices(IServiceCollection services)
        { 
        }
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync(_configure["Logging:LogLevel:Microsoft.Hosting.Lifetime"]);
                });
            });

        }
    }
}
