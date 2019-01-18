using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class Hub :MediaObject
	{


		public string GetGstreamerDot(GstreamerDotDetails? details=null)
		{
			return client.Invoke(this, "getGstreamerDot",new {details}).GetValue<string>();
		}


	}
}


