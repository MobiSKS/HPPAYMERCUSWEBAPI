using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    public class MerchantApproveMerchantReactivationRequestModelInput:BaseClass
    {


        [Required]
        [JsonPropertyName("MerchantStatus")]
        [DataMember]
        public int MerchantStatus { get; set; }

        [Required]
        [JsonPropertyName("ActionType")]
        [DataMember]
        public string ActionType { get; set; }

        [Required]
        [JsonPropertyName("ApprovedBy")]
        [DataMember]
        public string ApprovedBy { get; set; }

        [Required]
        [JsonPropertyName("TypeApproveMerchantRequest")]
        [DataMember]
        public List<TypeApproveMerchantRequest> TypeApproveMerchantRequest { get; set; }
    }


    public class TypeApproveMerchantRequest
    {

        [Required]
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [Required]
        [JsonPropertyName("Remarks")]
        [DataMember]
        public string Remarks { get; set; }
    }

    public class MerchantApproveMerchantReactivationRequestModelOuput:BaseClassOutput
    {
        [JsonProperty("SendStatus")]
        [DataMember]
        public int? SendStatus { get; set; }


    }

}
