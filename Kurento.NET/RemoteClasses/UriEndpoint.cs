using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class UriEndpoint :Endpoint
	{

		public string GetUri()
        {
            return client.Invoke(this, "getUri").GetValue<string>();
        }
        public void SetUri(string uri)
        {
            client.Invoke(this, "setUri", new { uri });
        }
		public UriEndpointState GetState()
        {
            return client.Invoke(this, "getState").GetValue<UriEndpointState>();
        }

		public void Pause()
		{
			client.Invoke(this, "pause",null);
		}
		public void Stop()
		{
			client.Invoke(this, "stop",null);
		}

		public KMSEventHandler<UriEndpointStateChangedEventArgs>  _UriEndpointStateChanged;
		public event KMSEventHandler<UriEndpointStateChangedEventArgs> UriEndpointStateChanged
		{
			add
			{
				_UriEndpointStateChanged += value;
				client.Subscribe(this, "UriEndpointStateChanged");
			}
			remove
			{
				_UriEndpointStateChanged -= value;
				client.Unsubscribe(this, "UriEndpointStateChanged");
			}
		}

	}
}


