

namespace BusinessOwnerDetails
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class BusinessOwner
    {
        [JsonProperty("license_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long LicenseId { get; set; }

        [JsonProperty("account_number")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long AccountNumber { get; set; }

        [JsonProperty("legal_name")]
        public string LegalName { get; set; }

        [JsonProperty("doing_business_as_name")]
        public string DoingBusinessAsName { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("license_status")]
        public string LicenseStatus { get; set; }

        [JsonProperty("license_description")]
        public string LicenseDescription { get; set; }

        [JsonProperty("business_activity")]
        public string BusinessActivity { get; set; }

        [JsonProperty("license_start_date")]
        public DateTimeOffset LicenseStartDate { get; set; }

        [JsonProperty("expiration_date")]
        public DateTimeOffset ExpirationDate { get; set; }
    }

    public partial class BusinessOwner
    {
        public static BusinessOwner[] FromJson(string json) => JsonConvert.DeserializeObject<BusinessOwner[]>(json, BusinessOwnerDetails.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this BusinessOwner[] self) => JsonConvert.SerializeObject(self, BusinessOwnerDetails.Converter.Settings);
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
