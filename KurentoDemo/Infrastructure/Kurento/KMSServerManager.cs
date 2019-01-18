using Kurento.NET;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using System;
using System.Text.RegularExpressions;

namespace KurentoDemo.Infrastructure.Kurento
{
    public class KMSServersManager
    {
        private List<KMSServer> servers;
        private List<ServerPipeline> pipelines;
        private readonly ILoggerFactory loggerFactory;

        public KMSServersManager(ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
            servers = new List<KMSServer>
            {
                new KMSServer("master","ws://120.79.101.14:8888/kurento", true, loggerFactory),
                new KMSServer("slave1","ws://119.23.174.246:8888/kurento", false, loggerFactory)
            };
            pipelines = new List<ServerPipeline>();
        }
        public void CreatePipeline(string id)
        {
            var masterServer = servers.FirstOrDefault(x => x.IsMaster);
            var slaveServers = servers.Where(x => !x.IsMaster).ToList();
            var masterPipeline = masterServer.CreatePipleline();
            var serverPipeline = new ServerPipeline
            {
                Id = id,
                MasterPipeline = masterPipeline,
                SlavePipelines = new Dictionary<string, MediaPipeline>(),
                MasterRtpEndPoints = new Dictionary<string, RtpEndpoint>(),
                SlaveRtpEndPoints = new Dictionary<string, RtpEndpoint>(),
            };
            foreach (var slaveServer in slaveServers)
            {
                var pipeline = slaveServer.CreatePipleline();
                var rtpEndPoint = slaveServer.CreateRtpEndPoint(pipeline);
                var masterRtpEndPoint = masterServer.CreateRtpEndPoint(masterPipeline);
               
                var offer = masterRtpEndPoint.GenerateOffer();
                var answer = rtpEndPoint.ProcessOffer(OverWriteSDP(offer, masterServer.IP));
                var answer2 = masterRtpEndPoint.ProcessAnswer(OverWriteSDP(answer, slaveServer.IP));

                serverPipeline.SlavePipelines[id] = pipeline;
                serverPipeline.MasterRtpEndPoints[id] = masterRtpEndPoint;
                serverPipeline.SlaveRtpEndPoints[id] = rtpEndPoint;
            }
            pipelines.Add(serverPipeline);
        }
        private string OverWriteSDP(string sdp, string ip) => Regex.Replace(sdp, @"(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})", ip);
        public WebRtcEndpoint CreateSlaveWebRtcEndPoint(string id)
        {
            var serverPipeline = pipelines.FirstOrDefault(x => x.Id == id);
            //随机分配一个接收节点
            var randomNode = serverPipeline.SlavePipelines.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            var slaveServerId = randomNode.Key;
            var slavePipeline = randomNode.Value;
            var webRtcEndPoint = slavePipeline.client.Create(new WebRtcEndpoint(slavePipeline));
            //rtpEndPoint 连接到 webRtcEndPoint
            var rtpEndPoint = serverPipeline.SlaveRtpEndPoints[slaveServerId];
            rtpEndPoint.Connect(webRtcEndPoint);
            return webRtcEndPoint;
        }
        public WebRtcEndpoint CreateMasterWebRtcEndPoint(string id)
        {
            var serverPipeline = pipelines.FirstOrDefault(x => x.Id == id);
            //随机分配一个接收节点
            var masterPipeline = serverPipeline.MasterPipeline;
            var webRtcEndPoint = masterPipeline.client.Create(new WebRtcEndpoint(masterPipeline));
            //webRtcEndPoint 连接到 rtpEndPoint
            foreach (var rtpEndpoint in serverPipeline.MasterRtpEndPoints.Values)
            {
                webRtcEndPoint.Connect(rtpEndpoint);
            }
            return webRtcEndPoint;
        }
    }

    public class ServerPipeline
    {
        public string Id { set; get; }
        public MediaPipeline MasterPipeline { set; get; }
        public Dictionary<string, RtpEndpoint> MasterRtpEndPoints { set; get; }
        public Dictionary<string, RtpEndpoint> SlaveRtpEndPoints { set; get; }
        public Dictionary<string, MediaPipeline> SlavePipelines { set; get; }
    }
}
