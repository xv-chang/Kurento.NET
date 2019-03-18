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

		public async Task<MediaPipeline> GetMediaPipelineAsync()
        {
            return (await client.InvokeAsync(this, "getMediaPipeline")).GetValue<MediaPipeline>();
        }
        public async Task SetMediaPipelineAsync(MediaPipeline mediaPipeline)
        {
            await client.InvokeAsync(this, "setMediaPipeline", new { mediaPipeline });
        }
		public async Task<MediaObject> GetParentAsync()
        {
            return (await client.InvokeAsync(this, "getParent")).GetValue<MediaObject>();
        }
        public async Task SetParentAsync(MediaObject parent)
        {
            await client.InvokeAsync(this, "setParent", new { parent });
        }
		public async Task<string> GetIdAsync()
        {
            return (await client.InvokeAsync(this, "getId")).GetValue<string>();
        }
        public async Task SetIdAsync(string id)
        {
            await client.InvokeAsync(this, "setId", new { id });
        }
		public async Task<MediaObject[]> GetChildsAsync()
        {
            return (await client.InvokeAsync(this, "getChilds")).GetValue<MediaObject[]>();
        }
		public async Task<MediaObject[]> GetChildrenAsync()
        {
            return (await client.InvokeAsync(this, "getChildren")).GetValue<MediaObject[]>();
        }
		public async Task<string> GetNameAsync()
        {
            return (await client.InvokeAsync(this, "getName")).GetValue<string>();
        }
        public async Task SetNameAsync(string name)
        {
            await client.InvokeAsync(this, "setName", new { name });
        }
		public async Task<bool> GetSendTagsInEventsAsync()
        {
            return (await client.InvokeAsync(this, "getSendTagsInEvents")).GetValue<bool>();
        }
        public async Task SetSendTagsInEventsAsync(bool sendTagsInEvents)
        {
            await client.InvokeAsync(this, "setSendTagsInEvents", new { sendTagsInEvents });
        }
		public async Task<int> GetCreationTimeAsync()
        {
            return (await client.InvokeAsync(this, "getCreationTime")).GetValue<int>();
        }
        public async Task SetCreationTimeAsync(int creationTime)
        {
            await client.InvokeAsync(this, "setCreationTime", new { creationTime });
        }

		public async Task AddTagAsync(string key,string value)
		{
			await client.InvokeAsync(this, "addTag",new {key,value});
		}
		public async Task RemoveTagAsync(string key)
		{
			await client.InvokeAsync(this, "removeTag",new {key});
		}
		public async Task<string> GetTagAsync(string key)
		{
			return (await client.InvokeAsync(this, "getTag",new {key})).GetValue<string>();
		}
		public async Task<Tag[]> GetTagsAsync()
		{
			return (await client.InvokeAsync(this, "getTags",null)).GetValue<Tag[]>();
		}

		public KMSEventHandler<ErrorEventArgs>  _Error;
		public event KMSEventHandler<ErrorEventArgs> Error
		{
			add
			{
				_Error += value;
				client.SubscribeAsync(this, "Error");
			}
			remove
			{
				_Error -= value;
				client.UnsubscribeAsync(this, "Error");
			}
		}

	}
}


