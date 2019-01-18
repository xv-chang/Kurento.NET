using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class RTCCodec :RTCStats
	{
		public Int64 payloadType;
		public string codec;
		public Int64 clockRate;
		public Int64 channels;
		public string parameters;

	}
}


