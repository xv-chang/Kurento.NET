using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class RTCRTPStreamStats :RTCStats
	{
			public string ssrc;
		public string associateStatsId;
		public bool isRemote;
		public string mediaTrackId;
		public string transportId;
		public string codecId;
		public Int64 firCount;
		public Int64 pliCount;
		public Int64 nackCount;
		public Int64 sliCount;
		public Int64 remb;
		public Int64 packetsLost;
		public double fractionLost;

	}
}


