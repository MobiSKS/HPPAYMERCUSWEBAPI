using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    public class MerchantApproveMobileDispenserRetailOutletMappingModelInput:BaseClass
    {

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [Required]
        [JsonPropertyName("ActionType")]
        [DataMember]
        public string ActionType { get; set; }


        [Required]
        [JsonPropertyName("TypeMobileDispenserRetailOutletMapping")]
        [DataMember]
        public List<TypeMobileDispenserRetailOutletMapping> TypeMobileDispenserRetailOutletMapping { get; set; }
    }

    public class TypeMobileDispenserRetailOutletMapping
    {

        [Required]
        [JsonPropertyName("MobileDispenserId")]
        [DataMember]
        public string MobileDispenserId { get; set; }

        [Required]
        [JsonPropertyName("RetailOutletsId")]
        [DataMember]
        public string RetailOutletsId { get; set; }

        [Required]
        [JsonPropertyName("Remarks")]
        [DataMember]
        public string Remarks { get; set; }
    }
    public class MerchantApproveMobileDispenserRetailOutletMappingModelOutput : BaseClassOutput
    {
        [JsonProperty("SendStatus")]
        [DataMember]
        public int? SendStatus { get; set; }
    }

}
