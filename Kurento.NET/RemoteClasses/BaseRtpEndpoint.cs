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

		public async Task<int> GetMinVideoRecvBandwidthAsync()
        {
            return (await client.InvokeAsync(this, "getMinVideoRecvBandwidth")).GetValue<int>();
        }
        public async Task SetMinVideoRecvBandwidthAsync(int minVideoRecvBandwidth)
        {
            await client.InvokeAsync(this, "setMinVideoRecvBandwidth", new { minVideoRecvBandwidth });
        }
		public async Task<int> GetMinVideoSendBandwidthAsync()
        {
            return (await client.InvokeAsync(this, "getMinVideoSendBandwidth")).GetValue<int>();
        }
        public async Task SetMinVideoSendBandwidthAsync(int minVideoSendBandwidth)
        {
            await client.InvokeAsync(this, "setMinVideoSendBandwidth", new { minVideoSendBandwidth });
        }
		public async Task<int> GetMaxVideoSendBandwidthAsync()
        {
            return (await client.InvokeAsync(this, "getMaxVideoSendBandwidth")).GetValue<int>();
        }
        public async Task SetMaxVideoSendBandwidthAsync(int maxVideoSendBandwidth)
        {
            await client.InvokeAsync(this, "setMaxVideoSendBandwidth", new { maxVideoSendBandwidth });
        }
		public async Task<MediaState> GetMediaStateAsync()
        {
            return (await client.InvokeAsync(this, "getMediaState")).GetValue<MediaState>();
        }
		public async Task<ConnectionState> GetConnectionStateAsync()
        {
            return (await client.InvokeAsync(this, "getConnectionState")).GetValue<ConnectionState>();
        }
		public async Task<RembParams> GetRembParamsAsync()
        {
            return (await client.InvokeAsync(this, "getRembParams")).GetValue<RembParams>();
        }
        public async Task SetRembParamsAsync(RembParams rembParams)
        {
            await client.InvokeAsync(this, "setRembParams", new { rembParams });
        }


		public KMSEventHandler<MediaStateChangedEventArgs>  _MediaStateChanged;
		public event KMSEventHandler<MediaStateChangedEventArgs> MediaStateChanged
		{
			add
			{
				_MediaStateChanged += value;
				client.SubscribeAsync(this, "MediaStateChanged");
			}
			remove
			{
				_MediaStateChanged -= value;
				client.UnsubscribeAsync(this, "MediaStateChanged");
			}
		}
		public KMSEventHandler<ConnectionStateChangedEventArgs>  _ConnectionStateChanged;
		public event KMSEventHandler<ConnectionStateChangedEventArgs> ConnectionStateChanged
		{
			add
			{
				_ConnectionStateChanged += value;
				client.SubscribeAsync(this, "ConnectionStateChanged");
			}
			remove
			{
				_ConnectionStateChanged -= value;
				client.UnsubscribeAsync(this, "ConnectionStateChanged");
			}
		}

	}
}


