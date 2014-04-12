using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

namespace MetroBlooms.Api.JsonConverters
{
    public class BoolConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((bool)value) ? 1 : 0);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType == typeof(bool))
            {
                return reader.Value != null && reader.Value.ToString() == "1";
            }
            if (objectType == typeof(bool?))
            {
                return reader.Value == null ? (bool?)null : reader.Value.ToString() == "1";
            }
            throw new ArgumentException("Invalid type for converter", "objectType");
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(bool) || objectType == typeof(bool?);
        }
    }
}