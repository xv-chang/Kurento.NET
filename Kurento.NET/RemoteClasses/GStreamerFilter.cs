using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class GStreamerFilter :Filter
	{
		public GStreamerFilter(MediaPipeline mediaPipeline,string command,FilterType filterType=FilterType.AUTODETECT)
		{
			constructorParams=new {mediaPipeline,command,filterType};
		}

		public string GetCommand()
        {
            return client.Invoke(this, "getCommand").GetValue<string>();
        }

		public void SetElementProperty(string propertyName,string propertyValue)
		{
			client.Invoke(this, "setElementProperty",new {propertyName,propertyValue});
		}


	}
}


