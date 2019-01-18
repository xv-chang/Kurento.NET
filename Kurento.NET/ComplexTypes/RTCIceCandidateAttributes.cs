using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class RTCIceCandidateAttributes :RTCStats
	{
			public string ipAddress;
		public Int64 portNumber;
		public string transport;
		public RTCStatsIceCandidateType candidateType;
		public Int64 priority;
		public string addressSourceUrl;

	}
}


