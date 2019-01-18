using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class RTCPeerConnectionStats :RTCStats
	{
		public Int64 dataChannelsOpened;
		public Int64 dataChannelsClosed;

	}
}


