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


		public void Connect(MediaType media,HubPort source,HubPort sink)
		{
			client.Invoke(this, "connect",new {media,source,sink});
		}
		public void Disconnect(MediaType media,HubPort source,HubPort sink)
		{
			client.Invoke(this, "disconnect",new {media,source,sink});
		}


	}
}


