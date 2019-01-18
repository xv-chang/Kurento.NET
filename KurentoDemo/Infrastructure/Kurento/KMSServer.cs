using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Kurento.NET;
using Microsoft.Extensions.Logging;

namespace KurentoDemo.Infrastructure.Kurento
{
    public class KMSServer : KurentoClient
    {
        public string Id { set; get; }
        public string Uri { set; get; }
        public string IP { set; get; }
        public bool IsMaster { set; get; }
        public KMSServer(string id, string uri, bool isMaster, ILoggerFactory loggerFactory) : base(uri, loggerFactory)
        {
            Id = id;
            Uri = uri;
            IP = GetIP(uri);
            IsMaster = isMaster;
        }
        private string GetIP(string uri)
        {
            var match = Regex.Match(uri, @"(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})");
            if (!match.Success)
                throw new ArgumentException("参数uri 必须时ip 地址，不能是域名");
            return match.Value;
        }
        public MediaPipeline CreatePipleline() => Create(new MediaPipeline());
        public RtpEndpoint CreateRtpEndPoint(MediaPipeline pipeline) => Create(new RtpEndpoint(pipeline));

    }
}
