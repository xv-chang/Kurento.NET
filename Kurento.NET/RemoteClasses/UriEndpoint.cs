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

		public async Task<string> GetUriAsync()
        {
            return (await client.InvokeAsync(this, "getUri")).GetValue<string>();
        }
        public async Task SetUriAsync(string uri)
        {
            await client.InvokeAsync(this, "setUri", new { uri });
        }
		public async Task<UriEndpointState> GetStateAsync()
        {
            return (await client.InvokeAsync(this, "getState")).GetValue<UriEndpointState>();
        }

		public async Task PauseAsync()
		{
			await client.InvokeAsync(this, "pause",null);
		}
		public async Task StopAsync()
		{
			await client.InvokeAsync(this, "stop",null);
		}

		public KMSEventHandler<UriEndpointStateChangedEventArgs>  _UriEndpointStateChanged;
		public event KMSEventHandler<UriEndpointStateChangedEventArgs> UriEndpointStateChanged
		{
			add
			{
				_UriEndpointStateChanged += value;
				client.SubscribeAsync(this, "UriEndpointStateChanged");
			}
			remove
			{
				_UriEndpointStateChanged -= value;
				client.UnsubscribeAsync(this, "UriEndpointStateChanged");
			}
		}

	}
}


