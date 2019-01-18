using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class HttpPostEndpoint :HttpEndpoint
	{
		public HttpPostEndpoint(MediaPipeline mediaPipeline,int disconnectionTimeout=2,bool useEncodedMedia=false)
		{
			constructorParams=new {mediaPipeline,disconnectionTimeout,useEncodedMedia};
		}



		public KMSEventHandler<EndOfStreamEventArgs>  _EndOfStream;
		public event KMSEventHandler<EndOfStreamEventArgs> EndOfStream
		{
			add
			{
				_EndOfStream += value;
				client.Subscribe(this, "EndOfStream");
			}
			remove
			{
				_EndOfStream -= value;
				client.Unsubscribe(this, "EndOfStream");
			}
		}

	}
}


