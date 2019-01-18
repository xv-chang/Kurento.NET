using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class RTCInboundRTPStreamStats :RTCRTPStreamStats
	{
		public Int64 packetsReceived;
		public Int64 bytesReceived;
		public double jitter;

	}
}


