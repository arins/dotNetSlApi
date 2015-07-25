using System;
using Newtonsoft.Json;
using SlApi.Models.RealtimeInformation.Response;

namespace SlApi.Models.RealtimeInformation.Serializer
{
    public class TransportModeSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return "";
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(TransportModeContainer) == objectType;
        }
    }
}
