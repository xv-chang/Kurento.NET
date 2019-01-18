using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kurento.NET
{
    public class KMSObjectJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(KMSObject));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                var id = reader.Value.ToString();
                var obj = (KMSObject)Activator.CreateInstance(objectType);
                obj.id = id;
                return obj;
            }
            throw new Exception("KMSObject转换出错");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var obj = value as KMSObject;
            writer.WriteValue(obj.id);
        }
    }
}
