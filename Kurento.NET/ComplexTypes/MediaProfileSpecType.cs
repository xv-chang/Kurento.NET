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
    public enum MediaProfileSpecType 
	{
		WEBM,
		MP4,
		WEBM_VIDEO_ONLY,
		WEBM_AUDIO_ONLY,
		MP4_VIDEO_ONLY,
		MP4_AUDIO_ONLY,
		JPEG_VIDEO_ONLY,
		KURENTO_SPLIT_RECORDER,

	}
}


