using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStores.Models
{
    public class BusinessOwnerAPIService
    {
        
        [JsonProperty("license_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long LicenseId { get; set; }

        [JsonProperty("license_description")]
        public string LicenseDescription { get; set; }

        [JsonProperty("business_activity")]
        public string BusinessActivity { get; set; }

        [JsonProperty("legal_name")]
        public string LegalName { get; set; }

       
        [JsonProperty("license_status")]
        public string LicenseStatus { get; set; }

        [JsonProperty("zip_code")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ZipCode { get; set; }



    }
}
