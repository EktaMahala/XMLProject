namespace GroceryStores
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class BusinessLicense
    {
        [JsonProperty("STORE NAME")]
        public string StoreName { get; set; }

        [JsonProperty("LICENSE ID")]
        public long LicenseId { get; set; }

        [JsonProperty("ACCOUNT NUMBER")]
        public long AccountNumber { get; set; }

        [JsonProperty("SQUARE FEET")]
        public long SquareFeet { get; set; }

        [JsonProperty("ADDRESS")]
        public string Address { get; set; }

        [JsonProperty("ZIP CODE")]
        public long ZipCode { get; set; }

        [JsonProperty("BUSINESS NAME")]
        public string BusinessName { get; set; }

        [JsonProperty("LICENSE STATUS")]
        public string LicenseStatus { get; set; }

        [JsonProperty("LICENSE DESCRIPTION")]
        public string LicenseDescription { get; set; }

        [JsonProperty("BUSINESS ACTIVITY")]
        public string BusinessActivity { get; set; }

        [JsonProperty("LICENSE TERM EXPIRATION DATE")]
        public string LicenseTermExpirationDate { get; set; }
    }

    public partial class BusinessLicense
    {
        public static BusinessLicense[] FromJson(string json) => JsonConvert.DeserializeObject<BusinessLicense[]>(json, GroceryStores.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this BusinessLicense[] self) => JsonConvert.SerializeObject(self, GroceryStores.Converter.Settings);
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
}

