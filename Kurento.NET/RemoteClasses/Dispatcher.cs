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


		public void Connect(HubPort source,HubPort sink)
		{
			client.Invoke(this, "connect",new {source,sink});
		}


	}
}


