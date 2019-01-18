using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class IceCandidatePair 
	{
			public string streamID;
		public int componentID;
		public string localCandidate;
		public string remoteCandidate;

	}
}


