using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class AlphaBlending :Hub
	{
		public AlphaBlending(MediaPipeline mediaPipeline)
		{
			constructorParams=new {mediaPipeline};
		}


		public async Task SetMasterAsync(HubPort source,int zOrder)
		{
			await client.InvokeAsync(this, "setMaster",new {source,zOrder});
		}
		public async Task SetPortPropertiesAsync(float relativeX,float relativeY,int zOrder,float relativeWidth,float relativeHeight,HubPort port)
		{
			await client.InvokeAsync(this, "setPortProperties",new {relativeX,relativeY,zOrder,relativeWidth,relativeHeight,port});
		}


	}
}


