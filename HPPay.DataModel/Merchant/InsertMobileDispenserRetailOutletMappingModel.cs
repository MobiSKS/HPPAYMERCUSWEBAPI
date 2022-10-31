using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    public class InsertMobileDispenserRetailOutletMappingModelInput:BaseClass
    {
        [Required]
        [StringLength(10)]
        [JsonPropertyName("MobileDispenserId")]
        [DataMember]
        public string MobileDispenserId { get; set; }

        [Required]
        [JsonPropertyName("RetailOutletsId")]
        [DataMember]
        public string RetailOutletsId { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }
        
    }
    public class InsertMobileDispenserRetailOutletMappingModelOutput : BaseClassOutput
    {

    }
}
