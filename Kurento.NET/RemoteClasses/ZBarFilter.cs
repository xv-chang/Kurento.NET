using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class ZBarFilter :Filter
	{
		public ZBarFilter(MediaPipeline mediaPipeline)
		{
			constructorParams=new {mediaPipeline};
		}



		public KMSEventHandler<CodeFoundEventArgs>  _CodeFound;
		public event KMSEventHandler<CodeFoundEventArgs> CodeFound
		{
			add
			{
				_CodeFound += value;
				client.SubscribeAsync(this, "CodeFound");
			}
			remove
			{
				_CodeFound -= value;
				client.UnsubscribeAsync(this, "CodeFound");
			}
		}

	}
}


