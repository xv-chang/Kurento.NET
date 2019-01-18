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

		public int GetMaxVideoRecvBandwidth()
        {
            return client.Invoke(this, "getMaxVideoRecvBandwidth").GetValue<int>();
        }
        public void SetMaxVideoRecvBandwidth(int maxVideoRecvBandwidth)
        {
            client.Invoke(this, "setMaxVideoRecvBandwidth", new { maxVideoRecvBandwidth });
        }
		public int GetMaxAudioRecvBandwidth()
        {
            return client.Invoke(this, "getMaxAudioRecvBandwidth").GetValue<int>();
        }
        public void SetMaxAudioRecvBandwidth(int maxAudioRecvBandwidth)
        {
            client.Invoke(this, "setMaxAudioRecvBandwidth", new { maxAudioRecvBandwidth });
        }

		public string GenerateOffer()
		{
			return client.Invoke(this, "generateOffer",null).GetValue<string>();
		}
		public string ProcessOffer(string offer)
		{
			return client.Invoke(this, "processOffer",new {offer}).GetValue<string>();
		}
		public string ProcessAnswer(string answer)
		{
			return client.Invoke(this, "processAnswer",new {answer}).GetValue<string>();
		}
		public string GetLocalSessionDescriptor()
		{
			return client.Invoke(this, "getLocalSessionDescriptor",null).GetValue<string>();
		}
		public string GetRemoteSessionDescriptor()
		{
			return client.Invoke(this, "getRemoteSessionDescriptor",null).GetValue<string>();
		}


	}
}


