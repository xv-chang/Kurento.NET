using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class MediaObject :KMSObject
	{

		public MediaPipeline GetMediaPipeline()
        {
            return client.Invoke(this, "getMediaPipeline").GetValue<MediaPipeline>();
        }
        public void SetMediaPipeline(MediaPipeline mediaPipeline)
        {
            client.Invoke(this, "setMediaPipeline", new { mediaPipeline });
        }
		public MediaObject GetParent()
        {
            return client.Invoke(this, "getParent").GetValue<MediaObject>();
        }
        public void SetParent(MediaObject parent)
        {
            client.Invoke(this, "setParent", new { parent });
        }
		public string GetId()
        {
            return client.Invoke(this, "getId").GetValue<string>();
        }
        public void SetId(string id)
        {
            client.Invoke(this, "setId", new { id });
        }
		public MediaObject[] GetChilds()
        {
            return client.Invoke(this, "getChilds").GetValue<MediaObject[]>();
        }
		public MediaObject[] GetChildren()
        {
            return client.Invoke(this, "getChildren").GetValue<MediaObject[]>();
        }
		public string GetName()
        {
            return client.Invoke(this, "getName").GetValue<string>();
        }
        public void SetName(string name)
        {
            client.Invoke(this, "setName", new { name });
        }
		public bool GetSendTagsInEvents()
        {
            return client.Invoke(this, "getSendTagsInEvents").GetValue<bool>();
        }
        public void SetSendTagsInEvents(bool sendTagsInEvents)
        {
            client.Invoke(this, "setSendTagsInEvents", new { sendTagsInEvents });
        }
		public int GetCreationTime()
        {
            return client.Invoke(this, "getCreationTime").GetValue<int>();
        }
        public void SetCreationTime(int creationTime)
        {
            client.Invoke(this, "setCreationTime", new { creationTime });
        }

		public void AddTag(string key,string value)
		{
			client.Invoke(this, "addTag",new {key,value});
		}
		public void RemoveTag(string key)
		{
			client.Invoke(this, "removeTag",new {key});
		}
		public string GetTag(string key)
		{
			return client.Invoke(this, "getTag",new {key}).GetValue<string>();
		}
		public Tag[] GetTags()
		{
			return client.Invoke(this, "getTags",null).GetValue<Tag[]>();
		}

		public KMSEventHandler<ErrorEventArgs>  _Error;
		public event KMSEventHandler<ErrorEventArgs> Error
		{
			add
			{
				_Error += value;
				client.Subscribe(this, "Error");
			}
			remove
			{
				_Error -= value;
				client.Unsubscribe(this, "Error");
			}
		}

	}
}


