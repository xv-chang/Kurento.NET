using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kurento.NET
{
    public delegate void KMSEventHandler<T>(T obj);
    [JsonConverter(typeof(KMSObjectJsonConverter))]
    public class KMSObject : IDisposable
    {
        public KurentoClient client;
        public object constructorParams;
        public string id;
        public void Dispose()
        {
            client.Release(this);
        }
    }
}