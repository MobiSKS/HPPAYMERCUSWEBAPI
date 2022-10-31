using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{


    public class CustomerAddCustomerCardMerchantMappingModelInput : BaseClass
    {
       

        [Required]
        [JsonPropertyName("Status")]
        [DataMember]
        public string Status { get; set; }


        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonPropertyName("ObjCardMerchantMap")]
        [DataMember]
        public List<CardMerchantMapModelInput> ObjCardMerchantMap { get; set; }
    }

    public class CardMerchantMapModelInput
    {
        [Required]
        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [Required]
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }


        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }


    }
    public class CustomerAddCustomerCardMerchantMappingModelOutput : BaseClassOutput
    {
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }
}
