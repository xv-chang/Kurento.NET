using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class ElementConnectionData 
	{
			public MediaElement source;
		public MediaElement sink;
		public MediaType type;
		public string sourceDescription;
		public string sinkDescription;

	}
}


