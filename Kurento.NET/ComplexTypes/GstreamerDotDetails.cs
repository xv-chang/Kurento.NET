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
    public enum GstreamerDotDetails 
	{
		SHOW_MEDIA_TYPE,
		SHOW_CAPS_DETAILS,
		SHOW_NON_DEFAULT_PARAMS,
		SHOW_STATES,
		SHOW_FULL_PARAMS,
		SHOW_ALL,
		SHOW_VERBOSE,

	}
}


