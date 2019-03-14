using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class FaceOverlayFilter :Filter
	{
		public FaceOverlayFilter(MediaPipeline mediaPipeline)
		{
			constructorParams=new {mediaPipeline};
		}


		public async Task UnsetOverlayedImageAsync()
		{
			await client.InvokeAsync(this, "unsetOverlayedImage",null);
		}
		public async Task SetOverlayedImageAsync(string uri,float offsetXPercent,float offsetYPercent,float widthPercent,float heightPercent)
		{
			await client.InvokeAsync(this, "setOverlayedImage",new {uri,offsetXPercent,offsetYPercent,widthPercent,heightPercent});
		}


	}
}


