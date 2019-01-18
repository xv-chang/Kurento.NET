using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KurentoDemo.Infrastructure.Hub
{
    public class HubRouteBuilder
    {
        private readonly RouteBuilder _routes;
        private readonly HubManager _manager;

        public HubRouteBuilder(RouteBuilder routes, HubManager manager)
        {
            _routes = routes;
            _manager = manager;
        }
        public void MapHub<T>(PathString path)
        {
            _routes.MapRoute(path, async c =>
            {
                if (c.WebSockets.IsWebSocketRequest)
                {
                    var hub = _manager.GetHub(c.Connection.Id, typeof(T));
                    var webSocket = await c.WebSockets.AcceptWebSocketAsync();
                    await ReceviedAsync(webSocket, c, hub);
                    webSocket.Dispose();
                    _manager.RemoveHub(c.Connection.Id);
                }
            });
        }
        private async Task ReceviedAsync(WebSocket webSocket, HttpContext context, IHub hub)
        {
            try
            {
                hub.Context = new HubContext()
                {
                    HttpContext = context,
                    WebSocket = webSocket
                };
                await hub.OnConnectedAsync();
                var buffer = new byte[1024 * 4];
                var r = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                var json = string.Empty;
                while (r.MessageType != WebSocketMessageType.Close)
                {
                    if (r.MessageType == WebSocketMessageType.Text)
                    {
                        json += Encoding.UTF8.GetString(buffer, 0, r.Count);
                        if (r.EndOfMessage)
                        {
                            try
                            {
                                var invokeInfo = JObject.Parse(json);
                                var methodName = (string)invokeInfo.SelectToken("method");
                                var method = hub.GetType().GetMethods()
                                  .FirstOrDefault(m => m.Name.Equals(methodName, StringComparison.CurrentCultureIgnoreCase));
                                var parameters = new List<object>();
                                var methodParameters = method.GetParameters();
                                for (int i = 0; i < methodParameters.Length; i++)
                                {
                                    var p = methodParameters[i];
                                    parameters.Add(invokeInfo.SelectToken($"arguments[{i}]").ToObject(p.ParameterType));
                                }
                                method.Invoke(hub, parameters.ToArray());
                            }
                            catch (Exception ex)
                            {
                                hub.OnError(ex);
                            }
                            finally
                            {
                                json = string.Empty;
                            }
                        }
                    }
                    r = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                }
                await webSocket.CloseAsync(r.CloseStatus.Value, r.CloseStatusDescription, CancellationToken.None);
                await hub.OnDisconnectedAsync(new Exception("连接断开"));
            }
            catch (Exception ex)
            {
                await hub.OnDisconnectedAsync(ex);
            }
        }
    }
}
