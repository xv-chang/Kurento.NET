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


		public void SetMaster(HubPort source,int zOrder)
		{
			client.Invoke(this, "setMaster",new {source,zOrder});
		}
		public void SetPortProperties(float relativeX,float relativeY,int zOrder,float relativeWidth,float relativeHeight,HubPort port)
		{
			client.Invoke(this, "setPortProperties",new {relativeX,relativeY,zOrder,relativeWidth,relativeHeight,port});
		}


	}
}


