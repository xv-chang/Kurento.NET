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

		public async Task<string> GetCommandAsync()
        {
            return (await client.InvokeAsync(this, "getCommand")).GetValue<string>();
        }

		public async Task SetElementPropertyAsync(string propertyName,string propertyValue)
		{
			await client.InvokeAsync(this, "setElementProperty",new {propertyName,propertyValue});
		}


	}
}


