using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class MediaPipeline :MediaObject
	{
		public MediaPipeline()
		{
			constructorParams=null;
		}

		public bool GetLatencyStats()
        {
            return client.Invoke(this, "getLatencyStats").GetValue<bool>();
        }
        public void SetLatencyStats(bool latencyStats)
        {
            client.Invoke(this, "setLatencyStats", new { latencyStats });
        }

		public string GetGstreamerDot(GstreamerDotDetails? details=null)
		{
			return client.Invoke(this, "getGstreamerDot",new {details}).GetValue<string>();
		}


	}
}


