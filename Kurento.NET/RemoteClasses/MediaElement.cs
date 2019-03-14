using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class MediaElement :MediaObject
	{

		public async Task<int> GetMinOuputBitrateAsync()
        {
            return (await client.InvokeAsync(this, "getMinOuputBitrate")).GetValue<int>();
        }
        public async Task SetMinOuputBitrateAsync(int minOuputBitrate)
        {
            await client.InvokeAsync(this, "setMinOuputBitrate", new { minOuputBitrate });
        }
		public async Task<int> GetMinOutputBitrateAsync()
        {
            return (await client.InvokeAsync(this, "getMinOutputBitrate")).GetValue<int>();
        }
        public async Task SetMinOutputBitrateAsync(int minOutputBitrate)
        {
            await client.InvokeAsync(this, "setMinOutputBitrate", new { minOutputBitrate });
        }
		public async Task<int> GetMaxOuputBitrateAsync()
        {
            return (await client.InvokeAsync(this, "getMaxOuputBitrate")).GetValue<int>();
        }
        public async Task SetMaxOuputBitrateAsync(int maxOuputBitrate)
        {
            await client.InvokeAsync(this, "setMaxOuputBitrate", new { maxOuputBitrate });
        }
		public async Task<int> GetMaxOutputBitrateAsync()
        {
            return (await client.InvokeAsync(this, "getMaxOutputBitrate")).GetValue<int>();
        }
        public async Task SetMaxOutputBitrateAsync(int maxOutputBitrate)
        {
            await client.InvokeAsync(this, "setMaxOutputBitrate", new { maxOutputBitrate });
        }

		public async Task<ElementConnectionData[]> GetSourceConnectionsAsync(MediaType? mediaType=null,string description="")
		{
			return (await client.InvokeAsync(this, "getSourceConnections",new {mediaType,description})).GetValue<ElementConnectionData[]>();
		}
		public async Task<ElementConnectionData[]> GetSinkConnectionsAsync(MediaType? mediaType=null,string description="")
		{
			return (await client.InvokeAsync(this, "getSinkConnections",new {mediaType,description})).GetValue<ElementConnectionData[]>();
		}
		public async Task ConnectAsync(MediaElement sink,MediaType? mediaType=null,string sourceMediaDescription="",string sinkMediaDescription="")
		{
			await client.InvokeAsync(this, "connect",new {sink,mediaType,sourceMediaDescription,sinkMediaDescription});
		}
		public async Task DisconnectAsync(MediaElement sink,MediaType? mediaType=null,string sourceMediaDescription="",string sinkMediaDescription="")
		{
			await client.InvokeAsync(this, "disconnect",new {sink,mediaType,sourceMediaDescription,sinkMediaDescription});
		}
		public async Task SetAudioFormatAsync(AudioCaps caps)
		{
			await client.InvokeAsync(this, "setAudioFormat",new {caps});
		}
		public async Task SetVideoFormatAsync(VideoCaps caps)
		{
			await client.InvokeAsync(this, "setVideoFormat",new {caps});
		}
		public async Task<string> GetGstreamerDotAsync(GstreamerDotDetails? details=null)
		{
			return (await client.InvokeAsync(this, "getGstreamerDot",new {details})).GetValue<string>();
		}
		public async Task SetOutputBitrateAsync(int bitrate)
		{
			await client.InvokeAsync(this, "setOutputBitrate",new {bitrate});
		}
		public async Task<Dictionary<string,Stats>> GetStatsAsync(MediaType? mediaType=null)
		{
			return (await client.InvokeAsync(this, "getStats",new {mediaType})).GetValue<Dictionary<string,Stats>>();
		}
		public async Task<bool> IsMediaFlowingInAsync(MediaType mediaType,string sinkMediaDescription="default")
		{
			return (await client.InvokeAsync(this, "isMediaFlowingIn",new {mediaType,sinkMediaDescription})).GetValue<bool>();
		}
		public async Task<bool> IsMediaFlowingOutAsync(MediaType mediaType,string sourceMediaDescription="default")
		{
			return (await client.InvokeAsync(this, "isMediaFlowingOut",new {mediaType,sourceMediaDescription})).GetValue<bool>();
		}
		public async Task<bool> IsMediaTranscodingAsync(MediaType mediaType,string binName="default")
		{
			return (await client.InvokeAsync(this, "isMediaTranscoding",new {mediaType,binName})).GetValue<bool>();
		}

		public KMSEventHandler<ElementConnectedEventArgs>  _ElementConnected;
		public event KMSEventHandler<ElementConnectedEventArgs> ElementConnected
		{
			add
			{
				_ElementConnected += value;
				client.SubscribeAsync(this, "ElementConnected");
			}
			remove
			{
				_ElementConnected -= value;
				client.UnsubscribeAsync(this, "ElementConnected");
			}
		}
		public KMSEventHandler<ElementDisconnectedEventArgs>  _ElementDisconnected;
		public event KMSEventHandler<ElementDisconnectedEventArgs> ElementDisconnected
		{
			add
			{
				_ElementDisconnected += value;
				client.SubscribeAsync(this, "ElementDisconnected");
			}
			remove
			{
				_ElementDisconnected -= value;
				client.UnsubscribeAsync(this, "ElementDisconnected");
			}
		}
		public KMSEventHandler<MediaFlowOutStateChangeEventArgs>  _MediaFlowOutStateChange;
		public event KMSEventHandler<MediaFlowOutStateChangeEventArgs> MediaFlowOutStateChange
		{
			add
			{
				_MediaFlowOutStateChange += value;
				client.SubscribeAsync(this, "MediaFlowOutStateChange");
			}
			remove
			{
				_MediaFlowOutStateChange -= value;
				client.UnsubscribeAsync(this, "MediaFlowOutStateChange");
			}
		}
		public KMSEventHandler<MediaFlowInStateChangeEventArgs>  _MediaFlowInStateChange;
		public event KMSEventHandler<MediaFlowInStateChangeEventArgs> MediaFlowInStateChange
		{
			add
			{
				_MediaFlowInStateChange += value;
				client.SubscribeAsync(this, "MediaFlowInStateChange");
			}
			remove
			{
				_MediaFlowInStateChange -= value;
				client.UnsubscribeAsync(this, "MediaFlowInStateChange");
			}
		}
		public KMSEventHandler<MediaTranscodingStateChangeEventArgs>  _MediaTranscodingStateChange;
		public event KMSEventHandler<MediaTranscodingStateChangeEventArgs> MediaTranscodingStateChange
		{
			add
			{
				_MediaTranscodingStateChange += value;
				client.SubscribeAsync(this, "MediaTranscodingStateChange");
			}
			remove
			{
				_MediaTranscodingStateChange -= value;
				client.UnsubscribeAsync(this, "MediaTranscodingStateChange");
			}
		}

	}
}


