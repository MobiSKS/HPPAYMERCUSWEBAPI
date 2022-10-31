using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.Merchant
{
    public class MerchantGetMobileDispenserRetailOutletMappingModelInput : BaseClass
    {

        [JsonPropertyName("MobileDispenserId")]
        [DataMember]
        public string MobileDispenserId { get; set; }

        [JsonPropertyName("Status")]
        [DataMember]
        public string Status { get; set; }

    }
    public class MerchantGetMobileDispenserRetailOutletMappingModelOutput : BaseClassOutput
    {

        [JsonProperty("MobileDispenserId")]
        [DataMember]
        public string MobileDispenserId { get; set; }

        [JsonProperty("MappedMerchantId")]
        [DataMember]
        public string MappedMerchantId { get; set; }

        [JsonProperty("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonProperty("CreatedTime")]
        [DataMember]
        public string CreatedTime { get; set; }

        [JsonProperty("StatusVal")]
        [DataMember]
        public string StatusVal { get; set; }

        [JsonProperty("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [JsonProperty("ModifiedTime")]
        [DataMember]
        public string ModifiedTime { get; set; }

        [JsonProperty("Remarks")]
        [DataMember]
        public string Remarks { get; set; }

    }
}
