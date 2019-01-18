using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class RTCTransportStats :RTCStats
	{
		public Int64 bytesSent;
		public Int64 bytesReceived;
		public string rtcpTransportStatsId;
		public bool activeConnection;
		public string selectedCandidatePairId;
		public string localCertificateId;
		public string remoteCertificateId;

	}
}


