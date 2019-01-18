using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class BaseRtpEndpoint :SdpEndpoint
	{

		public int GetMinVideoRecvBandwidth()
        {
            return client.Invoke(this, "getMinVideoRecvBandwidth").GetValue<int>();
        }
        public void SetMinVideoRecvBandwidth(int minVideoRecvBandwidth)
        {
            client.Invoke(this, "setMinVideoRecvBandwidth", new { minVideoRecvBandwidth });
        }
		public int GetMinVideoSendBandwidth()
        {
            return client.Invoke(this, "getMinVideoSendBandwidth").GetValue<int>();
        }
        public void SetMinVideoSendBandwidth(int minVideoSendBandwidth)
        {
            client.Invoke(this, "setMinVideoSendBandwidth", new { minVideoSendBandwidth });
        }
		public int GetMaxVideoSendBandwidth()
        {
            return client.Invoke(this, "getMaxVideoSendBandwidth").GetValue<int>();
        }
        public void SetMaxVideoSendBandwidth(int maxVideoSendBandwidth)
        {
            client.Invoke(this, "setMaxVideoSendBandwidth", new { maxVideoSendBandwidth });
        }
		public MediaState GetMediaState()
        {
            return client.Invoke(this, "getMediaState").GetValue<MediaState>();
        }
		public ConnectionState GetConnectionState()
        {
            return client.Invoke(this, "getConnectionState").GetValue<ConnectionState>();
        }
		public RembParams GetRembParams()
        {
            return client.Invoke(this, "getRembParams").GetValue<RembParams>();
        }
        public void SetRembParams(RembParams rembParams)
        {
            client.Invoke(this, "setRembParams", new { rembParams });
        }


		public KMSEventHandler<MediaStateChangedEventArgs>  _MediaStateChanged;
		public event KMSEventHandler<MediaStateChangedEventArgs> MediaStateChanged
		{
			add
			{
				_MediaStateChanged += value;
				client.Subscribe(this, "MediaStateChanged");
			}
			remove
			{
				_MediaStateChanged -= value;
				client.Unsubscribe(this, "MediaStateChanged");
			}
		}
		public KMSEventHandler<ConnectionStateChangedEventArgs>  _ConnectionStateChanged;
		public event KMSEventHandler<ConnectionStateChangedEventArgs> ConnectionStateChanged
		{
			add
			{
				_ConnectionStateChanged += value;
				client.Subscribe(this, "ConnectionStateChanged");
			}
			remove
			{
				_ConnectionStateChanged -= value;
				client.Unsubscribe(this, "ConnectionStateChanged");
			}
		}

	}
}


