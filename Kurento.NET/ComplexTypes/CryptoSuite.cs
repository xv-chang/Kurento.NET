using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
	[JsonConverter(typeof(StringEnumConverter))]
    public enum CryptoSuite 
	{
		AES_128_CM_HMAC_SHA1_32,
		AES_128_CM_HMAC_SHA1_80,
		AES_256_CM_HMAC_SHA1_32,
		AES_256_CM_HMAC_SHA1_80,

	}
}


