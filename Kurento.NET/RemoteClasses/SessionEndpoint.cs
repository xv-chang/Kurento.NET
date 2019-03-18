using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class SessionEndpoint :Endpoint
	{



		public KMSEventHandler<MediaSessionTerminatedEventArgs>  _MediaSessionTerminated;
		public event KMSEventHandler<MediaSessionTerminatedEventArgs> MediaSessionTerminated
		{
			add
			{
				_MediaSessionTerminated += value;
				client.SubscribeAsync(this, "MediaSessionTerminated");
			}
			remove
			{
				_MediaSessionTerminated -= value;
				client.UnsubscribeAsync(this, "MediaSessionTerminated");
			}
		}
		public KMSEventHandler<MediaSessionStartedEventArgs>  _MediaSessionStarted;
		public event KMSEventHandler<MediaSessionStartedEventArgs> MediaSessionStarted
		{
			add
			{
				_MediaSessionStarted += value;
				client.SubscribeAsync(this, "MediaSessionStarted");
			}
			remove
			{
				_MediaSessionStarted -= value;
				client.UnsubscribeAsync(this, "MediaSessionStarted");
			}
		}

	}
}


