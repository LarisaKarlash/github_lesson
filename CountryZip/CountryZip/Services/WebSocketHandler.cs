using CountryZip.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CountryZip.Services
{
    public class WebSocketHandler
    {
        private ConcurrentDictionary<Guid, WebSocket> websocketConnections = new ConcurrentDictionary<Guid, WebSocket>();
        private readonly IServiceProvider _provider;

        public WebSocketHandler(IServiceProvider provider)
        {
            _provider = provider;
        }
        public async Task Handler(Guid connectionGuid, WebSocket webSocket)
        {
            //установили соединение по уникальному ключу
            bool addedSucessfully = websocketConnections.TryAdd(connectionGuid, webSocket);

            if (addedSucessfully)
            {
                //  await SendToAllSockets($"User {connectionGuid} joined the chat.");
                var scope = _provider.CreateScope();
                var _restClient = scope.ServiceProvider.GetRequiredService<IRestZipClient>();
                var _context = scope.ServiceProvider.GetRequiredService<ObjCountryDBContext>();

                CountryNsi countryNsis = new CountryNsi();
                var countries = _context.CountriesNsi.ToList();
           
                while (webSocket.State == WebSocketState.Open)
                {
                    
                    foreach (var obj in countries)
                    {
                        await SendToAllSockets(obj.Country+" "+obj.ExampleURL);
                    }

                }
            }
        }

        //рассылаем сообщение всем участникам
        private async Task SendToAllSockets(string message)
        {

            foreach (var pair in websocketConnections)
            {
                byte[] messagebyte = Encoding.UTF8.GetBytes(message);
                await pair.Value.SendAsync(new ArraySegment<byte>(messagebyte), WebSocketMessageType.Text, true, CancellationToken.None);
                await Task.Delay(TimeSpan.FromSeconds(3));
            }

        }

    
    }
}
