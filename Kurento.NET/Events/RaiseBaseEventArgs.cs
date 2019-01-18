using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class RaiseBaseEventArgs 
	{
		public MediaObject source;
		public string timestamp;
		public Tag[] tags;

	}
}


