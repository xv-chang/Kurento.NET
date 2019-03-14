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


		public async Task SetSourceAsync(HubPort source)
		{
			await client.InvokeAsync(this, "setSource",new {source});
		}
		public async Task RemoveSourceAsync()
		{
			await client.InvokeAsync(this, "removeSource",null);
		}


	}
}


