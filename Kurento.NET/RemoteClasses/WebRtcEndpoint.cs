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

		public string GetStunServerAddress()
        {
            return client.Invoke(this, "getStunServerAddress").GetValue<string>();
        }
        public void SetStunServerAddress(string stunServerAddress)
        {
            client.Invoke(this, "setStunServerAddress", new { stunServerAddress });
        }
		public int GetStunServerPort()
        {
            return client.Invoke(this, "getStunServerPort").GetValue<int>();
        }
        public void SetStunServerPort(int stunServerPort)
        {
            client.Invoke(this, "setStunServerPort", new { stunServerPort });
        }
		public string GetTurnUrl()
        {
            return client.Invoke(this, "getTurnUrl").GetValue<string>();
        }
        public void SetTurnUrl(string turnUrl)
        {
            client.Invoke(this, "setTurnUrl", new { turnUrl });
        }
		public IceCandidatePair[] GetICECandidatePairs()
        {
            return client.Invoke(this, "getICECandidatePairs").GetValue<IceCandidatePair[]>();
        }
		public IceConnection[] GetIceConnectionState()
        {
            return client.Invoke(this, "getIceConnectionState").GetValue<IceConnection[]>();
        }

		public void GatherCandidates()
		{
			client.Invoke(this, "gatherCandidates",null);
		}
		public void AddIceCandidate(IceCandidate candidate)
		{
			client.Invoke(this, "addIceCandidate",new {candidate});
		}
		public void CreateDataChannel(string label="",bool ordered=true,int maxPacketLifeTime=-1,int maxRetransmits=-1,string protocol="")
		{
			client.Invoke(this, "createDataChannel",new {label,ordered,maxPacketLifeTime,maxRetransmits,protocol});
		}
		public void CloseDataChannel(int channelId)
		{
			client.Invoke(this, "closeDataChannel",new {channelId});
		}

		public KMSEventHandler<OnIceCandidateEventArgs>  _OnIceCandidate;
		public event KMSEventHandler<OnIceCandidateEventArgs> OnIceCandidate
		{
			add
			{
				_OnIceCandidate += value;
				client.Subscribe(this, "OnIceCandidate");
			}
			remove
			{
				_OnIceCandidate -= value;
				client.Unsubscribe(this, "OnIceCandidate");
			}
		}
		public KMSEventHandler<IceCandidateFoundEventArgs>  _IceCandidateFound;
		public event KMSEventHandler<IceCandidateFoundEventArgs> IceCandidateFound
		{
			add
			{
				_IceCandidateFound += value;
				client.Subscribe(this, "IceCandidateFound");
			}
			remove
			{
				_IceCandidateFound -= value;
				client.Unsubscribe(this, "IceCandidateFound");
			}
		}
		public KMSEventHandler<OnIceGatheringDoneEventArgs>  _OnIceGatheringDone;
		public event KMSEventHandler<OnIceGatheringDoneEventArgs> OnIceGatheringDone
		{
			add
			{
				_OnIceGatheringDone += value;
				client.Subscribe(this, "OnIceGatheringDone");
			}
			remove
			{
				_OnIceGatheringDone -= value;
				client.Unsubscribe(this, "OnIceGatheringDone");
			}
		}
		public KMSEventHandler<IceGatheringDoneEventArgs>  _IceGatheringDone;
		public event KMSEventHandler<IceGatheringDoneEventArgs> IceGatheringDone
		{
			add
			{
				_IceGatheringDone += value;
				client.Subscribe(this, "IceGatheringDone");
			}
			remove
			{
				_IceGatheringDone -= value;
				client.Unsubscribe(this, "IceGatheringDone");
			}
		}
		public KMSEventHandler<OnIceComponentStateChangedEventArgs>  _OnIceComponentStateChanged;
		public event KMSEventHandler<OnIceComponentStateChangedEventArgs> OnIceComponentStateChanged
		{
			add
			{
				_OnIceComponentStateChanged += value;
				client.Subscribe(this, "OnIceComponentStateChanged");
			}
			remove
			{
				_OnIceComponentStateChanged -= value;
				client.Unsubscribe(this, "OnIceComponentStateChanged");
			}
		}
		public KMSEventHandler<IceComponentStateChangeEventArgs>  _IceComponentStateChange;
		public event KMSEventHandler<IceComponentStateChangeEventArgs> IceComponentStateChange
		{
			add
			{
				_IceComponentStateChange += value;
				client.Subscribe(this, "IceComponentStateChange");
			}
			remove
			{
				_IceComponentStateChange -= value;
				client.Unsubscribe(this, "IceComponentStateChange");
			}
		}
		public KMSEventHandler<OnDataChannelOpenedEventArgs>  _OnDataChannelOpened;
		public event KMSEventHandler<OnDataChannelOpenedEventArgs> OnDataChannelOpened
		{
			add
			{
				_OnDataChannelOpened += value;
				client.Subscribe(this, "OnDataChannelOpened");
			}
			remove
			{
				_OnDataChannelOpened -= value;
				client.Unsubscribe(this, "OnDataChannelOpened");
			}
		}
		public KMSEventHandler<DataChannelOpenEventArgs>  _DataChannelOpen;
		public event KMSEventHandler<DataChannelOpenEventArgs> DataChannelOpen
		{
			add
			{
				_DataChannelOpen += value;
				client.Subscribe(this, "DataChannelOpen");
			}
			remove
			{
				_DataChannelOpen -= value;
				client.Unsubscribe(this, "DataChannelOpen");
			}
		}
		public KMSEventHandler<OnDataChannelClosedEventArgs>  _OnDataChannelClosed;
		public event KMSEventHandler<OnDataChannelClosedEventArgs> OnDataChannelClosed
		{
			add
			{
				_OnDataChannelClosed += value;
				client.Subscribe(this, "OnDataChannelClosed");
			}
			remove
			{
				_OnDataChannelClosed -= value;
				client.Unsubscribe(this, "OnDataChannelClosed");
			}
		}
		public KMSEventHandler<DataChannelCloseEventArgs>  _DataChannelClose;
		public event KMSEventHandler<DataChannelCloseEventArgs> DataChannelClose
		{
			add
			{
				_DataChannelClose += value;
				client.Subscribe(this, "DataChannelClose");
			}
			remove
			{
				_DataChannelClose -= value;
				client.Unsubscribe(this, "DataChannelClose");
			}
		}
		public KMSEventHandler<NewCandidatePairSelectedEventArgs>  _NewCandidatePairSelected;
		public event KMSEventHandler<NewCandidatePairSelectedEventArgs> NewCandidatePairSelected
		{
			add
			{
				_NewCandidatePairSelected += value;
				client.Subscribe(this, "NewCandidatePairSelected");
			}
			remove
			{
				_NewCandidatePairSelected -= value;
				client.Unsubscribe(this, "NewCandidatePairSelected");
			}
		}

	}
}


