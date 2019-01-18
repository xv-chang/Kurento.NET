using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Kurento.NET;
using Newtonsoft.Json;
using System.Collections.Concurrent;

namespace KurentoDemo.Hubs
{
    public class User
    {
        public string Id { set; get; }
        [JsonIgnore]
        public WebSocket WebSocket { set; get; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public UserType Type { set; get; }

        public string Role { set; get; }
        /// <summary>
        /// 发送信息端点
        /// </summary>
        [JsonIgnore]
        public WebRtcEndpoint SendEndPoint { set; get; }
        /// <summary>
        /// 接收信息端点
        /// </summary>
        [JsonIgnore]
        public ConcurrentDictionary<string,WebRtcEndpoint> ReceiveEndPoints { set; get; }

    }
    public enum UserType
    {
        Receiver,
        Sender
    }
}
