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

		public ServerInfo GetInfo()
        {
            return client.Invoke(this, "getInfo").GetValue<ServerInfo>();
        }
		public MediaPipeline[] GetPipelines()
        {
            return client.Invoke(this, "getPipelines").GetValue<MediaPipeline[]>();
        }
		public String[] GetSessions()
        {
            return client.Invoke(this, "getSessions").GetValue<String[]>();
        }
		public string GetMetadata()
        {
            return client.Invoke(this, "getMetadata").GetValue<string>();
        }

		public string GetKmd(string moduleName)
		{
			return client.Invoke(this, "getKmd",new {moduleName}).GetValue<string>();
		}
		public Int64 GetUsedMemory()
		{
			return client.Invoke(this, "getUsedMemory",null).GetValue<Int64>();
		}

		public KMSEventHandler<ObjectCreatedEventArgs>  _ObjectCreated;
		public event KMSEventHandler<ObjectCreatedEventArgs> ObjectCreated
		{
			add
			{
				_ObjectCreated += value;
				client.Subscribe(this, "ObjectCreated");
			}
			remove
			{
				_ObjectCreated -= value;
				client.Unsubscribe(this, "ObjectCreated");
			}
		}
		public KMSEventHandler<ObjectDestroyedEventArgs>  _ObjectDestroyed;
		public event KMSEventHandler<ObjectDestroyedEventArgs> ObjectDestroyed
		{
			add
			{
				_ObjectDestroyed += value;
				client.Subscribe(this, "ObjectDestroyed");
			}
			remove
			{
				_ObjectDestroyed -= value;
				client.Unsubscribe(this, "ObjectDestroyed");
			}
		}

	}
}


