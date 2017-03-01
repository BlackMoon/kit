using System;
using Newtonsoft.Json;
using Kit.Core.Encryption;

namespace Kit.Core.Web.Mvc.Converters
{
    public class ByteArrayConvertor : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(byte[]);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value != null)
            {
                byte[] data = (byte[])value;                
                writer.WriteValue(data.ToHexString());                
            }
            else
                writer.WriteNull();
        }
    }
}
