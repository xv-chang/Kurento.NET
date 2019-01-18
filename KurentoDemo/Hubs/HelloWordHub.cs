using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Kurento;
using KurentoDemo.Hubs;
using KurentoDemo.Infrastructure.Kurento;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Kurento.NET;
using KurentoDemo.Infrastructure.Hub;
using Hub = KurentoDemo.Infrastructure.Hub.Hub;

namespace KurentoDemo
{
    public class HelloWorldHub : Hub
    {
        private readonly KurentoClient client;
        private readonly MediaPipeline pipeline;
        private readonly WebRtcEndpoint webRtcEndPoint;
        private readonly ServerManager serverManager;

        public HelloWorldHub(ILoggerFactory loggerFactory)
        {
            client = new KurentoClient("ws://vm.gydfsoft.com:8888/kurento", loggerFactory);
            pipeline = client.Create(new MediaPipeline());
            webRtcEndPoint = client.Create(new WebRtcEndpoint(pipeline));
            serverManager = client.GetServerManager();
            webRtcEndPoint.OnIceCandidate += WebRtcEndPoint_OnIceCandidate;
        }
        private void WebRtcEndPoint_OnIceCandidate(OnIceCandidateEventArgs obj)
        {
            Caller.AddCandidate(obj.candidate);
        }

        public dynamic Caller
        {
            get
            {
                return new DynamicClientProxy(new WebSocket[] { Context.WebSocket });
            }
        }
        public void ReceiveOffer(string sdpOffer)
        {
            webRtcEndPoint.Connect(webRtcEndPoint);
            //处理offer
            var answer = webRtcEndPoint.ProcessOffer(sdpOffer);
            //caller 处理answer
            Caller.ProcessAnswer(answer);
            //开始收集 candidate
            webRtcEndPoint.GatherCandidates();
        }


        /// <summary>
        /// 添加候选项
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="candidate">候选项</param>
        /// <returns></returns>
        public void AddCandidate(IceCandidate candidate)
        {
            webRtcEndPoint.AddIceCandidate(candidate);
        }
        public void Ping()
        {
            Caller.Pong();
        }
    }
}
