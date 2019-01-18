using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class RTCDataChannelStats :RTCStats
	{
			public string label;
		public string protocol;
		public Int64 datachannelid;
		public RTCDataChannelState state;
		public Int64 messagesSent;
		public Int64 bytesSent;
		public Int64 messagesReceived;
		public Int64 bytesReceived;

	}
}


