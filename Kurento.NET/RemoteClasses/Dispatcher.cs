using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class Dispatcher :Hub
	{
		public Dispatcher(MediaPipeline mediaPipeline)
		{
			constructorParams=new {mediaPipeline};
		}


		public async Task ConnectAsync(HubPort source,HubPort sink)
		{
			await client.InvokeAsync(this, "connect",new {source,sink});
		}


	}
}


