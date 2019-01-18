using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class RTCMediaStreamTrackStats :RTCStats
	{
		public string trackIdentifier;
		public bool remoteSource;
		public String[] ssrcIds;
		public Int64 frameWidth;
		public Int64 frameHeight;
		public double framesPerSecond;
		public Int64 framesSent;
		public Int64 framesReceived;
		public Int64 framesDecoded;
		public Int64 framesDropped;
		public Int64 framesCorrupted;
		public double audioLevel;
		public double echoReturnLoss;
		public double echoReturnLossEnhancement;

	}
}


