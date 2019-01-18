using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class ImageOverlayFilter :Filter
	{
		public ImageOverlayFilter(MediaPipeline mediaPipeline)
		{
			constructorParams=new {mediaPipeline};
		}


		public void RemoveImage(string id)
		{
			client.Invoke(this, "removeImage",new {id});
		}
		public void AddImage(string id,string uri,float offsetXPercent,float offsetYPercent,float widthPercent,float heightPercent,bool keepAspectRatio,bool center)
		{
			client.Invoke(this, "addImage",new {id,uri,offsetXPercent,offsetYPercent,widthPercent,heightPercent,keepAspectRatio,center});
		}


	}
}


