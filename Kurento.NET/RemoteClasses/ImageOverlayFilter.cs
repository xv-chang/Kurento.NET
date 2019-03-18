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


		public async Task RemoveImageAsync(string id)
		{
			await client.InvokeAsync(this, "removeImage",new {id});
		}
		public async Task AddImageAsync(string id,string uri,float offsetXPercent,float offsetYPercent,float widthPercent,float heightPercent,bool keepAspectRatio,bool center)
		{
			await client.InvokeAsync(this, "addImage",new {id,uri,offsetXPercent,offsetYPercent,widthPercent,heightPercent,keepAspectRatio,center});
		}


	}
}


