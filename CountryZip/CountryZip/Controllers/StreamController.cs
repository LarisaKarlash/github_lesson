using CountryZip.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebSocketsExample.Controllers
{
    public class StreamController : Controller
    {
        private readonly WebSocketHandler _webSocketHandler;
        public StreamController(WebSocketHandler webSocketHandler)
        {
            _webSocketHandler = webSocketHandler;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Chat()
        {
            return View();
        }

        public async Task Get()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                // запрашивает соединение
                 WebSocket webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
              
                // Вызов из Stream
                  await _webSocketHandler.Handler(Guid.NewGuid(), webSocket);

            }
            else
            {
                HttpContext.Response.StatusCode = 400;
            }
        }
       
    }
}
