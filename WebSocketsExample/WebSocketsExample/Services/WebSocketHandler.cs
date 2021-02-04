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
        //private ConcurrentDictionary<Guid, WebSocket> websocketConnections = new ConcurrentDictionary<Guid, WebSocket>();
        private ConcurrentDictionary<string, WebSocket> websocketConnections = new ConcurrentDictionary<string, WebSocket>();

        //public async Task Handler(Guid connectionGuid, WebSocket webSocket)
        public async Task Handler(string username, WebSocket webSocket)
        {
            //установили соединение по уникальному ключу
            bool addedSucessfully = websocketConnections.TryAdd(username, webSocket);

            if (addedSucessfully)
            {
                 await SendToAllSockets($"User {username} joined the chat.");

                while (webSocket.State == WebSocketState.Open)
                {
                    //пока открыт WebSocket, должны получать сообщения
                    string message = await Receive(username,webSocket);
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
        public async Task<String> Receive(string username, WebSocket webSocket)
        {
            ArraySegment<byte> arraySegment = new ArraySegment<byte>(new byte[4096]);
            WebSocketReceiveResult receiveResult = await webSocket.ReceiveAsync(arraySegment, CancellationToken.None);

            if (receiveResult.MessageType == WebSocketMessageType.Text)
            {
                string message = Encoding.Default.GetString(arraySegment).TrimEnd('\0');
                if (!string.IsNullOrWhiteSpace(message))
                    return $"<b>{username}</b>: {message}";

            }
            return null;

        }
    }
}
