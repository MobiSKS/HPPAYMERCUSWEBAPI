using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.RBE
{
    public class GetPendingRbeConsentModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("RBEId")]
        [DataMember]
        public string RBEId { get; set; }
    }
    public class GetPendingRbeConsentModelOutput
    {
        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("CustomerMobile")]
        [DataMember]
        public string CustomerMobile { get; set; }

        [JsonProperty("CustomerReferenceNo")]
        [DataMember]
        public string CustomerReferenceNo { get; set; }

        [JsonProperty("CustomerFormNumber")]
        [DataMember]
        public string CustomerFormNumber { get; set; }

        [JsonProperty("CustomerType")]
        [DataMember]
        public string CustomerType { get; set; }

        [JsonProperty("EmailId")]
        [DataMember]
        public string EmailId { get; set; }

        [JsonProperty("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }
    }
}
