using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class SdpEndpoint :SessionEndpoint
	{

		public async Task<int> GetMaxVideoRecvBandwidthAsync()
        {
            return (await client.InvokeAsync(this, "getMaxVideoRecvBandwidth")).GetValue<int>();
        }
        public async Task SetMaxVideoRecvBandwidthAsync(int maxVideoRecvBandwidth)
        {
            await client.InvokeAsync(this, "setMaxVideoRecvBandwidth", new { maxVideoRecvBandwidth });
        }
		public async Task<int> GetMaxAudioRecvBandwidthAsync()
        {
            return (await client.InvokeAsync(this, "getMaxAudioRecvBandwidth")).GetValue<int>();
        }
        public async Task SetMaxAudioRecvBandwidthAsync(int maxAudioRecvBandwidth)
        {
            await client.InvokeAsync(this, "setMaxAudioRecvBandwidth", new { maxAudioRecvBandwidth });
        }

		public async Task<string> GenerateOfferAsync()
		{
			return (await client.InvokeAsync(this, "generateOffer",null)).GetValue<string>();
		}
		public async Task<string> ProcessOfferAsync(string offer)
		{
			return (await client.InvokeAsync(this, "processOffer",new {offer})).GetValue<string>();
		}
		public async Task<string> ProcessAnswerAsync(string answer)
		{
			return (await client.InvokeAsync(this, "processAnswer",new {answer})).GetValue<string>();
		}
		public async Task<string> GetLocalSessionDescriptorAsync()
		{
			return (await client.InvokeAsync(this, "getLocalSessionDescriptor",null)).GetValue<string>();
		}
		public async Task<string> GetRemoteSessionDescriptorAsync()
		{
			return (await client.InvokeAsync(this, "getRemoteSessionDescriptor",null)).GetValue<string>();
		}


	}
}


