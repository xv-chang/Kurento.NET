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

		public int GetMinOuputBitrate()
        {
            return client.Invoke(this, "getMinOuputBitrate").GetValue<int>();
        }
        public void SetMinOuputBitrate(int minOuputBitrate)
        {
            client.Invoke(this, "setMinOuputBitrate", new { minOuputBitrate });
        }
		public int GetMinOutputBitrate()
        {
            return client.Invoke(this, "getMinOutputBitrate").GetValue<int>();
        }
        public void SetMinOutputBitrate(int minOutputBitrate)
        {
            client.Invoke(this, "setMinOutputBitrate", new { minOutputBitrate });
        }
		public int GetMaxOuputBitrate()
        {
            return client.Invoke(this, "getMaxOuputBitrate").GetValue<int>();
        }
        public void SetMaxOuputBitrate(int maxOuputBitrate)
        {
            client.Invoke(this, "setMaxOuputBitrate", new { maxOuputBitrate });
        }
		public int GetMaxOutputBitrate()
        {
            return client.Invoke(this, "getMaxOutputBitrate").GetValue<int>();
        }
        public void SetMaxOutputBitrate(int maxOutputBitrate)
        {
            client.Invoke(this, "setMaxOutputBitrate", new { maxOutputBitrate });
        }

		public ElementConnectionData[] GetSourceConnections(MediaType? mediaType=null,string description="")
		{
			return client.Invoke(this, "getSourceConnections",new {mediaType,description}).GetValue<ElementConnectionData[]>();
		}
		public ElementConnectionData[] GetSinkConnections(MediaType? mediaType=null,string description="")
		{
			return client.Invoke(this, "getSinkConnections",new {mediaType,description}).GetValue<ElementConnectionData[]>();
		}
		public void Connect(MediaElement sink,MediaType? mediaType=null,string sourceMediaDescription="",string sinkMediaDescription="")
		{
			client.Invoke(this, "connect",new {sink,mediaType,sourceMediaDescription,sinkMediaDescription});
		}
		public void Disconnect(MediaElement sink,MediaType? mediaType=null,string sourceMediaDescription="",string sinkMediaDescription="")
		{
			client.Invoke(this, "disconnect",new {sink,mediaType,sourceMediaDescription,sinkMediaDescription});
		}
		public void SetAudioFormat(AudioCaps caps)
		{
			client.Invoke(this, "setAudioFormat",new {caps});
		}
		public void SetVideoFormat(VideoCaps caps)
		{
			client.Invoke(this, "setVideoFormat",new {caps});
		}
		public string GetGstreamerDot(GstreamerDotDetails? details=null)
		{
			return client.Invoke(this, "getGstreamerDot",new {details}).GetValue<string>();
		}
		public void SetOutputBitrate(int bitrate)
		{
			client.Invoke(this, "setOutputBitrate",new {bitrate});
		}
		public Dictionary<string,Stats> GetStats(MediaType? mediaType=null)
		{
			return client.Invoke(this, "getStats",new {mediaType}).GetValue<Dictionary<string,Stats>>();
		}
		public bool IsMediaFlowingIn(MediaType mediaType,string sinkMediaDescription="default")
		{
			return client.Invoke(this, "isMediaFlowingIn",new {mediaType,sinkMediaDescription}).GetValue<bool>();
		}
		public bool IsMediaFlowingOut(MediaType mediaType,string sourceMediaDescription="default")
		{
			return client.Invoke(this, "isMediaFlowingOut",new {mediaType,sourceMediaDescription}).GetValue<bool>();
		}
		public bool IsMediaTranscoding(MediaType mediaType,string binName="default")
		{
			return client.Invoke(this, "isMediaTranscoding",new {mediaType,binName}).GetValue<bool>();
		}

		public KMSEventHandler<ElementConnectedEventArgs>  _ElementConnected;
		public event KMSEventHandler<ElementConnectedEventArgs> ElementConnected
		{
			add
			{
				_ElementConnected += value;
				client.Subscribe(this, "ElementConnected");
			}
			remove
			{
				_ElementConnected -= value;
				client.Unsubscribe(this, "ElementConnected");
			}
		}
		public KMSEventHandler<ElementDisconnectedEventArgs>  _ElementDisconnected;
		public event KMSEventHandler<ElementDisconnectedEventArgs> ElementDisconnected
		{
			add
			{
				_ElementDisconnected += value;
				client.Subscribe(this, "ElementDisconnected");
			}
			remove
			{
				_ElementDisconnected -= value;
				client.Unsubscribe(this, "ElementDisconnected");
			}
		}
		public KMSEventHandler<MediaFlowOutStateChangeEventArgs>  _MediaFlowOutStateChange;
		public event KMSEventHandler<MediaFlowOutStateChangeEventArgs> MediaFlowOutStateChange
		{
			add
			{
				_MediaFlowOutStateChange += value;
				client.Subscribe(this, "MediaFlowOutStateChange");
			}
			remove
			{
				_MediaFlowOutStateChange -= value;
				client.Unsubscribe(this, "MediaFlowOutStateChange");
			}
		}
		public KMSEventHandler<MediaFlowInStateChangeEventArgs>  _MediaFlowInStateChange;
		public event KMSEventHandler<MediaFlowInStateChangeEventArgs> MediaFlowInStateChange
		{
			add
			{
				_MediaFlowInStateChange += value;
				client.Subscribe(this, "MediaFlowInStateChange");
			}
			remove
			{
				_MediaFlowInStateChange -= value;
				client.Unsubscribe(this, "MediaFlowInStateChange");
			}
		}
		public KMSEventHandler<MediaTranscodingStateChangeEventArgs>  _MediaTranscodingStateChange;
		public event KMSEventHandler<MediaTranscodingStateChangeEventArgs> MediaTranscodingStateChange
		{
			add
			{
				_MediaTranscodingStateChange += value;
				client.Subscribe(this, "MediaTranscodingStateChange");
			}
			remove
			{
				_MediaTranscodingStateChange -= value;
				client.Unsubscribe(this, "MediaTranscodingStateChange");
			}
		}

	}
}


