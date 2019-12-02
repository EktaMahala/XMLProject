
namespace GroceryStores
{
   
        using System;
        using System.Collections.Generic;

        using System.Globalization;
        using Newtonsoft.Json;
        using Newtonsoft.Json.Converters;

        public partial class GroceryStore
        {
            [JsonProperty("store_name")]
            public string StoreName { get; set; }

            [JsonProperty("license_id")]
            [JsonConverter(typeof(ParseStringConverter))]
            public long LicenseId { get; set; }

            [JsonProperty("account_number")]
            [JsonConverter(typeof(ParseStringConverter))]
            public long AccountNumber { get; set; }

            [JsonProperty("square_feet")]
            [JsonConverter(typeof(ParseStringConverter))]
            public long SquareFeet { get; set; }


            [JsonProperty("address")]
            public string Address { get; set; }

            [JsonProperty("zip_code")]
            [JsonConverter(typeof(ParseStringConverter))]
            public long ZipCode { get; set; }

            [JsonProperty("latitude")]
            public string Latitude { get; set; }

            [JsonProperty("longitude")]
            public string Longitude { get; set; }

            [JsonProperty("location")]
            public Location Location { get; set; }
        }
        public partial class Location
        {
            [JsonProperty("latitude")]
            public string Latitude { get; set; }

            [JsonProperty("longitude")]
            public string Longitude { get; set; }
        }

        public partial class GroceryStore
    {
            public static GroceryStore[] FromJson(string json) => JsonConvert.DeserializeObject<GroceryStore[]>(json, GroceryStores.Converter.Settings);
        }

        public static class Serialize
        {
            public static string ToJson(this GroceryStore[] self) => JsonConvert.SerializeObject(self, GroceryStores.Converter.Settings);
        }

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }

        internal class ParseStringConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                long l;
                if (Int64.TryParse(value, out l))
                {
                    return l;
                }
                throw new Exception("Cannot unmarshal type long");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (long)untypedValue;
                serializer.Serialize(writer, value.ToString());
                return;
            }

            public static readonly ParseStringConverter Singleton = new ParseStringConverter();
        }
    
}