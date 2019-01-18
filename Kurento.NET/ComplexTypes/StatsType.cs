using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
	[JsonConverter(typeof(StringEnumConverter))]
    public enum StatsType 
	{
		inboundrtp,
		outboundrtp,
		session,
		datachannel,
		track,
		transport,
		candidatepair,
		localcandidate,
		remotecandidate,
		element,
		endpoint,

	}
}


