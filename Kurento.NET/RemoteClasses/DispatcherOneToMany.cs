using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class DispatcherOneToMany :Hub
	{
		public DispatcherOneToMany(MediaPipeline mediaPipeline)
		{
			constructorParams=new {mediaPipeline};
		}


		public void SetSource(HubPort source)
		{
			client.Invoke(this, "setSource",new {source});
		}
		public void RemoveSource()
		{
			client.Invoke(this, "removeSource",null);
		}


	}
}


