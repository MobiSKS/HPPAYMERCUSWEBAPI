using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    public class MerchantInsertMobileDispenserCustomerModelInput:BaseClass
    {

        [Required]
        [JsonPropertyName("MerchantID ")]
        [DataMember]
        public string MerchantID { get; set; }


        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }


        [Required]
        [JsonPropertyName("ReferenceId")]
        [DataMember]
        public string ReferenceId { get; set; }

    }
    public class MerchantInsertMobileDispenserCustomerModelOutput : BaseClassOutput
    {

    }
}
