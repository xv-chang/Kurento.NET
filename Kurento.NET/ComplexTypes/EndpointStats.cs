using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class EndpointStats :ElementStats
	{
			public double audioE2ELatency;
		public double videoE2ELatency;
		public MediaLatencyStat[] E2ELatency;

	}
}


