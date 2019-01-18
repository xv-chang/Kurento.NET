using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class IceCandidate 
	{
		public string candidate;
		public string sdpMid;
		public int sdpMLineIndex;

	}
}


