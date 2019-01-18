using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class RTCCertificateStats :RTCStats
	{
		public string fingerprint;
		public string fingerprintAlgorithm;
		public string base64Certificate;
		public string issuerCertificateId;

	}
}


