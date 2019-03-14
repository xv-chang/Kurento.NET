using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class RtpEndpoint :BaseRtpEndpoint
	{
		public RtpEndpoint(MediaPipeline mediaPipeline,SDES crypto=null,bool useIpv6=false)
		{
			constructorParams=new {mediaPipeline,crypto,useIpv6};
		}



		public KMSEventHandler<OnKeySoftLimitEventArgs>  _OnKeySoftLimit;
		public event KMSEventHandler<OnKeySoftLimitEventArgs> OnKeySoftLimit
		{
			add
			{
				_OnKeySoftLimit += value;
				client.SubscribeAsync(this, "OnKeySoftLimit");
			}
			remove
			{
				_OnKeySoftLimit -= value;
				client.UnsubscribeAsync(this, "OnKeySoftLimit");
			}
		}

	}
}


