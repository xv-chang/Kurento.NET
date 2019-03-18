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

		public async Task<VideoInfo> GetVideoInfoAsync()
        {
            return (await client.InvokeAsync(this, "getVideoInfo")).GetValue<VideoInfo>();
        }
		public async Task<string> GetElementGstreamerDotAsync()
        {
            return (await client.InvokeAsync(this, "getElementGstreamerDot")).GetValue<string>();
        }
		public async Task<Int64> GetPositionAsync()
        {
            return (await client.InvokeAsync(this, "getPosition")).GetValue<Int64>();
        }
        public async Task SetPositionAsync(Int64 position)
        {
            await client.InvokeAsync(this, "setPosition", new { position });
        }

		public async Task PlayAsync()
		{
			await client.InvokeAsync(this, "play",null);
		}

		public KMSEventHandler<EndOfStreamEventArgs>  _EndOfStream;
		public event KMSEventHandler<EndOfStreamEventArgs> EndOfStream
		{
			add
			{
				_EndOfStream += value;
				client.SubscribeAsync(this, "EndOfStream");
			}
			remove
			{
				_EndOfStream -= value;
				client.UnsubscribeAsync(this, "EndOfStream");
			}
		}

	}
}


