using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using Newtonsoft.Json;

namespace MetroBlooms.Api.JsonConverters
{
    public class DateTimeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType == typeof(DateTime))
            {
                return GetDateTime(reader, new DateTime()).Value;
            }
            if (objectType == typeof(DateTime?))
            {
                return GetDateTime(reader, null);
            }
            throw new ArgumentException("Invalid type for converter", "objectType");
        }

        private static DateTime? GetDateTime(JsonReader reader, DateTime? defaultValue)
        {
            var value = reader.Value;
            return value == null || string.IsNullOrEmpty(value.ToString()) || value.ToString() == "0000-00-00 00:00:00" //Year 0 isn't valid for DateTime
                ? defaultValue 
                : DateTime.ParseExact(value.ToString(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime) || objectType == typeof(DateTime?);
        }
    }
}