using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ObjectBD.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectBD.Services
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseWriteToConsole(this IApplicationBuilder app, string output)
        {
            return app.UseMiddleware<WriteToConsoleMiddleWare>(output);
        }

        public static IServiceCollection UseMessageSender(this IServiceCollection services)
        {
           ServiceSendViewModel serviceSend = new ServiceSendViewModel();

           var tip = serviceSend.TipSend.ToString();

            if (tip == "Sms")
            {
                return services.AddScoped<IMessageSender, SmsMessageSender>();
            }
            else
            {
                return services.AddScoped<IMessageSender, EmailMessageSender>();
            }
        }

    }
}
