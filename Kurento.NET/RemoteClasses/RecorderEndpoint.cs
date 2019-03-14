using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class RecorderEndpoint :UriEndpoint
	{
		public RecorderEndpoint(MediaPipeline mediaPipeline,string uri,MediaProfileSpecType mediaProfile=MediaProfileSpecType.WEBM,bool stopOnEndOfStream=false)
		{
			constructorParams=new {mediaPipeline,uri,mediaProfile,stopOnEndOfStream};
		}


		public async Task RecordAsync()
		{
			await client.InvokeAsync(this, "record",null);
		}
		public async Task StopAndWaitAsync()
		{
			await client.InvokeAsync(this, "stopAndWait",null);
		}

		public KMSEventHandler<RecordingEventArgs>  _Recording;
		public event KMSEventHandler<RecordingEventArgs> Recording
		{
			add
			{
				_Recording += value;
				client.SubscribeAsync(this, "Recording");
			}
			remove
			{
				_Recording -= value;
				client.UnsubscribeAsync(this, "Recording");
			}
		}
		public KMSEventHandler<PausedEventArgs>  _Paused;
		public event KMSEventHandler<PausedEventArgs> Paused
		{
			add
			{
				_Paused += value;
				client.SubscribeAsync(this, "Paused");
			}
			remove
			{
				_Paused -= value;
				client.UnsubscribeAsync(this, "Paused");
			}
		}
		public KMSEventHandler<StoppedEventArgs>  _Stopped;
		public event KMSEventHandler<StoppedEventArgs> Stopped
		{
			add
			{
				_Stopped += value;
				client.SubscribeAsync(this, "Stopped");
			}
			remove
			{
				_Stopped -= value;
				client.UnsubscribeAsync(this, "Stopped");
			}
		}

	}
}


