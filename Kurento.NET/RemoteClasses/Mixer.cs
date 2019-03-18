using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class Mixer :Hub
	{
		public Mixer(MediaPipeline mediaPipeline)
		{
			constructorParams=new {mediaPipeline};
		}


		public async Task ConnectAsync(MediaType media,HubPort source,HubPort sink)
		{
			await client.InvokeAsync(this, "connect",new {media,source,sink});
		}
		public async Task DisconnectAsync(MediaType media,HubPort source,HubPort sink)
		{
			await client.InvokeAsync(this, "disconnect",new {media,source,sink});
		}


	}
}


