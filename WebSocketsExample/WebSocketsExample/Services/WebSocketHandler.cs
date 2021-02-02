using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebSocketsExample.Services
{
    public class WebSocketHandler
    {
        private ConcurrentDictionary<Guid, WebSocket> websocketConnections = new ConcurrentDictionary<Guid, WebSocket>();

        public async Task Handler(Guid connectionGuid, WebSocket webSocket)
        {
            //установили соединение по уникальному ключу
            bool addedSucessfully = websocketConnections.TryAdd(connectionGuid, webSocket);

            if (addedSucessfully)
            {
                 await SendToAllSockets($"User {connectionGuid} joined the chat.");

                while (webSocket.State == WebSocketState.Open)
                {
                    //пока открыт WebSocket, должны получать сообщения
                    string message = await Receive(webSocket);
                    if (message != null)
                    {
                        await SendToAllSockets(message);
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
            }

        }

        //получаем сообщение всем участникам
        public async Task<String> Receive(WebSocket webSocket)
        {
            ArraySegment<byte> arraySegment = new ArraySegment<byte>(new byte[1024]);
            WebSocketReceiveResult receiveResult = await webSocket.ReceiveAsync(arraySegment, CancellationToken.None);

            if (receiveResult.MessageType == WebSocketMessageType.Text)
            {
                string message = Encoding.UTF8.GetString(arraySegment).TrimEnd('\0');
                return message;
            }
            return null;

        }
    }
}
