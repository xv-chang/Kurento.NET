using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class RTCOutboundRTPStreamStats :RTCRTPStreamStats
	{
			public Int64 packetsSent;
		public Int64 bytesSent;
		public double targetBitrate;
		public double roundTripTime;

	}
}


