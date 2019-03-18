using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public class HttpEndpoint :SessionEndpoint
	{


		public async Task<string> GetUrlAsync()
		{
			return (await client.InvokeAsync(this, "getUrl",null)).GetValue<string>();
		}


	}
}


