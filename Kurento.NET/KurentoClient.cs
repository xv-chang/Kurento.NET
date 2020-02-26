using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Reflection;

namespace Kurento.NET
{

    public class KurentoClient
    {
        const double checkHBInterval = 1000 * 5;  //5秒
        private int requestId = 0;
        private ClientWebSocket clientWebSocket;
        private ConcurrentDictionary<int, string> requests = new ConcurrentDictionary<int, string>();
        private ConcurrentDictionary<int, KMSResponse> repsonses = new ConcurrentDictionary<int, KMSResponse>();
        private ConcurrentDictionary<string, KMSObject> objects = new ConcurrentDictionary<string, KMSObject>();
        private readonly ILogger _logger;
        private readonly string _uri;
        private readonly ManualResetEvent resetEvent = new ManualResetEvent(false);
        private readonly System.Timers.Timer timer;
        private int tryCount = 0;
        private readonly Task receiveTask;
        public KurentoClient(string uri, ILogger logger = null)
        {
            _logger = logger ?? new NullLogger();
            _uri = uri;
            timer = new System.Timers.Timer(checkHBInterval);
            timer.Elapsed += Timer_Elapsed;
            receiveTask = Task.Run(ReceiveAsync);
            WaitConnectedAsync();
        }
        private async Task CheckHeartBeatAsync()
        {
            if (clientWebSocket.State == WebSocketState.Aborted || clientWebSocket.State == WebSocketState.Closed)
            {
                await WaitConnectedAsync();
            }
            SendAsync("ping", new { interval = checkHBInterval });
        }
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            CheckHeartBeatAsync();
        }
        private async Task WaitConnectedAsync()
        {
            try
            {
                clientWebSocket = new ClientWebSocket();
                await clientWebSocket.ConnectAsync(new Uri(_uri), CancellationToken.None);
                resetEvent.Set();
                tryCount = 0;
            }
            catch (Exception ex)
            {
                tryCount++;
                _logger.LogError(ex, $"{ex.Message},尝试重连次数{tryCount}");
            }
        }
        private async Task ReceiveAsync()
        {
            while (resetEvent.WaitOne())
            {
                if (clientWebSocket.State == WebSocketState.Open)
                {
                    var buffer = new byte[1024 * 4];
                    //接收到消息
                    var r = await clientWebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    var content = new StringBuilder();
                    while (r.MessageType != WebSocketMessageType.Close && r.MessageType == WebSocketMessageType.Text)
                    {
                        content.Append(Encoding.UTF8.GetString(buffer, 0, r.Count));
                        if (r.EndOfMessage)
                        {
                            OnMessage(content.ToString());
                            content.Clear();
                        }
                        //没接收完继续接受
                        r = await clientWebSocket.ReceiveAsync(new ArraySegment<byte>(buffer, 0, r.Count), CancellationToken.None);
                    }
                    await clientWebSocket.CloseAsync(r.CloseStatus.Value, r.CloseStatusDescription, CancellationToken.None);
                    clientWebSocket.Dispose();
                }
            }
        }
        private void OnMessage(string data)
        {
            _logger.LogInformation(data);
            var resp = JsonConvert.DeserializeObject<KMSResponse>(data);
            if (resp.Method == "onEvent")
            {
                var instance = objects[resp.Params.Value.Object];
                var eventDelegate = (MulticastDelegate)instance.GetType()
                    .GetField($"_{resp.Params.Value.Type}")
                    .GetValue(instance);
                //获取委托方法的参数类型
                var pt = eventDelegate.Method
                    .GetParameters()
                    .FirstOrDefault()
                    .ParameterType;
                //参数类型转换
                var arg = resp.Params.Value.Data.ToObject(pt);
                var delegates = eventDelegate.GetInvocationList();
                foreach (var dlg in delegates)
                {
                    dlg.Method.Invoke(dlg.Target, new object[] { arg });
                }
            }
            repsonses[resp.Id] = resp;
        }
        public async Task<KMSResponse> SendAsync(string rpcType, object @params)
        {
            int requestId = ++this.requestId;
            var request = new
            {
                jsonrpc = "2.0",
                id = requestId,
                method = rpcType,
                @params
            };
            var jsonSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            var jsonStr = JsonConvert.SerializeObject(request, jsonSetting);
            _logger.LogInformation(jsonStr);
            requests[requestId] = jsonStr;
            var buffer = Encoding.UTF8.GetBytes(jsonStr);
            await clientWebSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
            while (!repsonses.ContainsKey(requestId))
                Thread.Sleep(100);
            KMSResponse resp = repsonses[requestId];
            requests.TryRemove(requestId, out string _);
            repsonses.TryRemove(requestId, out _);
            if (resp.Error != null)
                _logger.LogError(resp.Error.Message);
            return resp;
        }
        public async Task<T> CreateAsync<T>(T instance) where T : KMSObject
        {
            KMSResponse r = await SendAsync("create", new
            {
                type = typeof(T).Name,
                instance.constructorParams
            });
            instance.client = this;
            instance.id = r.GetStringValue();
            objects[instance.id] = instance;
            return instance;
        }
        public async Task<KMSResponse> InvokeAsync<T>(T instance, string operation, object operationParams = null) where T : KMSObject
        {
            return await SendAsync("invoke", new
            {
                @object = instance.id,
                operation,
                operationParams
            });
        }
        public async Task SubscribeAsync<T>(T instance, string type) where T : KMSObject
        {
            await SendAsync("subscribe", new
            {
                @object = instance.id,
                type
            });
        }
        public async Task UnsubscribeAsync<T>(T instance, string subscription) where T : KMSObject
        {
            await SendAsync("unsubscribe", new
            {
                @object = instance.id,
                subscription
            });
        }
        public async Task ReleaseAsync<T>(T instance) where T : KMSObject
        {
            await SendAsync("release", new
            {
                @object = instance.id
            });
            objects.TryRemove(instance.id, out KMSObject _);
        }
        public ServerManager GetServerManager()
        {
            var obj = GetObjectById("manager_ServerManager");
            if (obj == null)
            {
                obj = new ServerManager();
                obj.client = this;
                obj.id = "manager_ServerManager";
                objects.TryAdd(obj.id, obj);
            }
            return (ServerManager)obj;
        }

        public KMSObject GetObjectById(string id)
        {
            objects.TryGetValue(id, out KMSObject obj);
            return obj;
        }
    }

    public class KMSResponse
    {
        public string JsonRpc { set; get; }
        public int Id { set; get; }
        public KMSParams Params { set; get; }
        public string Method { set; get; }
        public JObject Result { set; get; }
        public KMSError Error { set; get; }

        public T GetValue<T>()
        {
            return Result.SelectToken("value").ToObject<T>();
        }
        public string GetStringValue()
        {
            return GetValue<string>();
        }
        public string GetSessionId()
        {
            return Result.SelectToken("sessionId").ToObject<string>();
        }
    }
    public class KMSResult
    {
        public string SessionId { set; get; }
        public JObject Value { set; get; }
    }
    public class KMSParams
    {
        public KMSValue Value { set; get; }
    }
    public class KMSValue
    {
        public JObject Data { set; get; }
        public string Object { set; get; }
        public string Type { set; get; }
        public string Subscription { set; get; }
    }
    public class KMSError
    {
        public string Code { set; get; }
        public string Message { set; get; }
    }


}
