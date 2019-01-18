using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class RembParams 
	{
			public int packetsRecvIntervalTop;
		public float exponentialFactor;
		public int linealFactorMin;
		public float linealFactorGrade;
		public float decrementFactor;
		public float thresholdFactor;
		public int upLosses;
		public int rembOnConnect;

	}
}


