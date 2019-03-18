using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class WebRtcEndpoint :BaseRtpEndpoint
	{
		public WebRtcEndpoint(MediaPipeline mediaPipeline,bool recvonly=false,bool sendonly=false,bool useDataChannels=false,CertificateKeyType certificateKeyType=CertificateKeyType.RSA)
		{
			constructorParams=new {mediaPipeline,recvonly,sendonly,useDataChannels,certificateKeyType};
		}

		public async Task<string> GetStunServerAddressAsync()
        {
            return (await client.InvokeAsync(this, "getStunServerAddress")).GetValue<string>();
        }
        public async Task SetStunServerAddressAsync(string stunServerAddress)
        {
            await client.InvokeAsync(this, "setStunServerAddress", new { stunServerAddress });
        }
		public async Task<int> GetStunServerPortAsync()
        {
            return (await client.InvokeAsync(this, "getStunServerPort")).GetValue<int>();
        }
        public async Task SetStunServerPortAsync(int stunServerPort)
        {
            await client.InvokeAsync(this, "setStunServerPort", new { stunServerPort });
        }
		public async Task<string> GetTurnUrlAsync()
        {
            return (await client.InvokeAsync(this, "getTurnUrl")).GetValue<string>();
        }
        public async Task SetTurnUrlAsync(string turnUrl)
        {
            await client.InvokeAsync(this, "setTurnUrl", new { turnUrl });
        }
		public async Task<IceCandidatePair[]> GetICECandidatePairsAsync()
        {
            return (await client.InvokeAsync(this, "getICECandidatePairs")).GetValue<IceCandidatePair[]>();
        }
		public async Task<IceConnection[]> GetIceConnectionStateAsync()
        {
            return (await client.InvokeAsync(this, "getIceConnectionState")).GetValue<IceConnection[]>();
        }

		public async Task GatherCandidatesAsync()
		{
			await client.InvokeAsync(this, "gatherCandidates",null);
		}
		public async Task AddIceCandidateAsync(IceCandidate candidate)
		{
			await client.InvokeAsync(this, "addIceCandidate",new {candidate});
		}
		public async Task CreateDataChannelAsync(string label="",bool ordered=true,int maxPacketLifeTime=-1,int maxRetransmits=-1,string protocol="")
		{
			await client.InvokeAsync(this, "createDataChannel",new {label,ordered,maxPacketLifeTime,maxRetransmits,protocol});
		}
		public async Task CloseDataChannelAsync(int channelId)
		{
			await client.InvokeAsync(this, "closeDataChannel",new {channelId});
		}

		public KMSEventHandler<OnIceCandidateEventArgs>  _OnIceCandidate;
		public event KMSEventHandler<OnIceCandidateEventArgs> OnIceCandidate
		{
			add
			{
				_OnIceCandidate += value;
				client.SubscribeAsync(this, "OnIceCandidate");
			}
			remove
			{
				_OnIceCandidate -= value;
				client.UnsubscribeAsync(this, "OnIceCandidate");
			}
		}
		public KMSEventHandler<IceCandidateFoundEventArgs>  _IceCandidateFound;
		public event KMSEventHandler<IceCandidateFoundEventArgs> IceCandidateFound
		{
			add
			{
				_IceCandidateFound += value;
				client.SubscribeAsync(this, "IceCandidateFound");
			}
			remove
			{
				_IceCandidateFound -= value;
				client.UnsubscribeAsync(this, "IceCandidateFound");
			}
		}
		public KMSEventHandler<OnIceGatheringDoneEventArgs>  _OnIceGatheringDone;
		public event KMSEventHandler<OnIceGatheringDoneEventArgs> OnIceGatheringDone
		{
			add
			{
				_OnIceGatheringDone += value;
				client.SubscribeAsync(this, "OnIceGatheringDone");
			}
			remove
			{
				_OnIceGatheringDone -= value;
				client.UnsubscribeAsync(this, "OnIceGatheringDone");
			}
		}
		public KMSEventHandler<IceGatheringDoneEventArgs>  _IceGatheringDone;
		public event KMSEventHandler<IceGatheringDoneEventArgs> IceGatheringDone
		{
			add
			{
				_IceGatheringDone += value;
				client.SubscribeAsync(this, "IceGatheringDone");
			}
			remove
			{
				_IceGatheringDone -= value;
				client.UnsubscribeAsync(this, "IceGatheringDone");
			}
		}
		public KMSEventHandler<OnIceComponentStateChangedEventArgs>  _OnIceComponentStateChanged;
		public event KMSEventHandler<OnIceComponentStateChangedEventArgs> OnIceComponentStateChanged
		{
			add
			{
				_OnIceComponentStateChanged += value;
				client.SubscribeAsync(this, "OnIceComponentStateChanged");
			}
			remove
			{
				_OnIceComponentStateChanged -= value;
				client.UnsubscribeAsync(this, "OnIceComponentStateChanged");
			}
		}
		public KMSEventHandler<IceComponentStateChangeEventArgs>  _IceComponentStateChange;
		public event KMSEventHandler<IceComponentStateChangeEventArgs> IceComponentStateChange
		{
			add
			{
				_IceComponentStateChange += value;
				client.SubscribeAsync(this, "IceComponentStateChange");
			}
			remove
			{
				_IceComponentStateChange -= value;
				client.UnsubscribeAsync(this, "IceComponentStateChange");
			}
		}
		public KMSEventHandler<OnDataChannelOpenedEventArgs>  _OnDataChannelOpened;
		public event KMSEventHandler<OnDataChannelOpenedEventArgs> OnDataChannelOpened
		{
			add
			{
				_OnDataChannelOpened += value;
				client.SubscribeAsync(this, "OnDataChannelOpened");
			}
			remove
			{
				_OnDataChannelOpened -= value;
				client.UnsubscribeAsync(this, "OnDataChannelOpened");
			}
		}
		public KMSEventHandler<DataChannelOpenEventArgs>  _DataChannelOpen;
		public event KMSEventHandler<DataChannelOpenEventArgs> DataChannelOpen
		{
			add
			{
				_DataChannelOpen += value;
				client.SubscribeAsync(this, "DataChannelOpen");
			}
			remove
			{
				_DataChannelOpen -= value;
				client.UnsubscribeAsync(this, "DataChannelOpen");
			}
		}
		public KMSEventHandler<OnDataChannelClosedEventArgs>  _OnDataChannelClosed;
		public event KMSEventHandler<OnDataChannelClosedEventArgs> OnDataChannelClosed
		{
			add
			{
				_OnDataChannelClosed += value;
				client.SubscribeAsync(this, "OnDataChannelClosed");
			}
			remove
			{
				_OnDataChannelClosed -= value;
				client.UnsubscribeAsync(this, "OnDataChannelClosed");
			}
		}
		public KMSEventHandler<DataChannelCloseEventArgs>  _DataChannelClose;
		public event KMSEventHandler<DataChannelCloseEventArgs> DataChannelClose
		{
			add
			{
				_DataChannelClose += value;
				client.SubscribeAsync(this, "DataChannelClose");
			}
			remove
			{
				_DataChannelClose -= value;
				client.UnsubscribeAsync(this, "DataChannelClose");
			}
		}
		public KMSEventHandler<NewCandidatePairSelectedEventArgs>  _NewCandidatePairSelected;
		public event KMSEventHandler<NewCandidatePairSelectedEventArgs> NewCandidatePairSelected
		{
			add
			{
				_NewCandidatePairSelected += value;
				client.SubscribeAsync(this, "NewCandidatePairSelected");
			}
			remove
			{
				_NewCandidatePairSelected -= value;
				client.UnsubscribeAsync(this, "NewCandidatePairSelected");
			}
		}

	}
}


