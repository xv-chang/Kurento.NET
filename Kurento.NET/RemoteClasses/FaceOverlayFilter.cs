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


		public void UnsetOverlayedImage()
		{
			client.Invoke(this, "unsetOverlayedImage",null);
		}
		public void SetOverlayedImage(string uri,float offsetXPercent,float offsetYPercent,float widthPercent,float heightPercent)
		{
			client.Invoke(this, "setOverlayedImage",new {uri,offsetXPercent,offsetYPercent,widthPercent,heightPercent});
		}


	}
}


