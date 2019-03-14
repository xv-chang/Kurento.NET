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

		public async Task<bool> GetLatencyStatsAsync()
        {
            return (await client.InvokeAsync(this, "getLatencyStats")).GetValue<bool>();
        }
        public async Task SetLatencyStatsAsync(bool latencyStats)
        {
            await client.InvokeAsync(this, "setLatencyStats", new { latencyStats });
        }

		public async Task<string> GetGstreamerDotAsync(GstreamerDotDetails? details=null)
		{
			return (await client.InvokeAsync(this, "getGstreamerDot",new {details})).GetValue<string>();
		}


	}
}


