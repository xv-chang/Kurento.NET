using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KurentoDemo.Infrastructure.Hub
{
    public class DynamicClientProxy : DynamicObject
    {
        public readonly WebSocket[] sockets;
        public DynamicClientProxy(WebSocket[] sockets)
        {
            this.sockets = sockets;
        }
        private async Task SendAsync(string method, object[] arguments)
        {
            var buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new
            {
                method,
                arguments
            }));
            foreach (var s in sockets)
            {
                await s.SendAsync(new ArraySegment<byte>(buffer, 0, buffer.Length), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            result = SendAsync(binder.Name, args);
            return true;
        }
    }
}
