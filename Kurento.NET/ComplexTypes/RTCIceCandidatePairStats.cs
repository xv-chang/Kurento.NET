using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class RTCIceCandidatePairStats :RTCStats
	{
		public string transportId;
		public string localCandidateId;
		public string remoteCandidateId;
		public RTCStatsIceCandidatePairState state;
		public Int64 priority;
		public bool nominated;
		public bool writable;
		public bool readable;
		public Int64 bytesSent;
		public Int64 bytesReceived;
		public double roundTripTime;
		public double availableOutgoingBitrate;
		public double availableIncomingBitrate;

	}
}


