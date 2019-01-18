using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class ServerInfo 
	{
			public string version;
		public ModuleInfo[] modules;
		public ServerType type;
		public String[] capabilities;

	}
}


