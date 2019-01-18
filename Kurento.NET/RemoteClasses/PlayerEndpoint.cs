using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class PlayerEndpoint :UriEndpoint
	{
		public PlayerEndpoint(MediaPipeline mediaPipeline,string uri,bool useEncodedMedia=false,int networkCache=2000)
		{
			constructorParams=new {mediaPipeline,uri,useEncodedMedia,networkCache};
		}

		public VideoInfo GetVideoInfo()
        {
            return client.Invoke(this, "getVideoInfo").GetValue<VideoInfo>();
        }
		public string GetElementGstreamerDot()
        {
            return client.Invoke(this, "getElementGstreamerDot").GetValue<string>();
        }
		public Int64 GetPosition()
        {
            return client.Invoke(this, "getPosition").GetValue<Int64>();
        }
        public void SetPosition(Int64 position)
        {
            client.Invoke(this, "setPosition", new { position });
        }

		public void Play()
		{
			client.Invoke(this, "play",null);
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


