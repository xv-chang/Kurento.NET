using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class ServerManager :MediaObject
	{

		public async Task<ServerInfo> GetInfoAsync()
        {
            return (await client.InvokeAsync(this, "getInfo")).GetValue<ServerInfo>();
        }
		public async Task<MediaPipeline[]> GetPipelinesAsync()
        {
            return (await client.InvokeAsync(this, "getPipelines")).GetValue<MediaPipeline[]>();
        }
		public async Task<String[]> GetSessionsAsync()
        {
            return (await client.InvokeAsync(this, "getSessions")).GetValue<String[]>();
        }
		public async Task<string> GetMetadataAsync()
        {
            return (await client.InvokeAsync(this, "getMetadata")).GetValue<string>();
        }

		public async Task<string> GetKmdAsync(string moduleName)
		{
			return (await client.InvokeAsync(this, "getKmd",new {moduleName})).GetValue<string>();
		}
		public async Task<Int64> GetUsedMemoryAsync()
		{
			return (await client.InvokeAsync(this, "getUsedMemory",null)).GetValue<Int64>();
		}

		public KMSEventHandler<ObjectCreatedEventArgs>  _ObjectCreated;
		public event KMSEventHandler<ObjectCreatedEventArgs> ObjectCreated
		{
			add
			{
				_ObjectCreated += value;
				client.SubscribeAsync(this, "ObjectCreated");
			}
			remove
			{
				_ObjectCreated -= value;
				client.UnsubscribeAsync(this, "ObjectCreated");
			}
		}
		public KMSEventHandler<ObjectDestroyedEventArgs>  _ObjectDestroyed;
		public event KMSEventHandler<ObjectDestroyedEventArgs> ObjectDestroyed
		{
			add
			{
				_ObjectDestroyed += value;
				client.SubscribeAsync(this, "ObjectDestroyed");
			}
			remove
			{
				_ObjectDestroyed -= value;
				client.UnsubscribeAsync(this, "ObjectDestroyed");
			}
		}

	}
}


