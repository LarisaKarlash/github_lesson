using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectBD.Services
{
    public class WriteToConsoleMiddleWare
    {
        public RequestDelegate _next;
        public string _message;
        public WriteToConsoleMiddleWare(RequestDelegate next, string message)
        {
            _next = next;
            _message = message;
        }
        public async Task InvokeAsync(HttpContext context )
        {
            Console.WriteLine("Custom before " + _message);
            await _next(context);
            Console.WriteLine("Custom after");
        }
    }
}
