using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class ElementDisconnectedEventArgs :MediaEventArgs
	{
		public MediaElement sink;
		public MediaType mediaType;
		public string sourceMediaDescription;
		public string sinkMediaDescription;

	}
}


