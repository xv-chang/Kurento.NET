using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class VideoInfo 
	{
		public bool isSeekable;
		public Int64 seekableInit;
		public Int64 seekableEnd;
		public Int64 duration;

	}
}


