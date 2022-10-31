using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.CustomerAPI
{
    public class CustomerAPIHotlistReactivateCardModelInput : CustomerAPIBaseClassInput
    {
        [Required]
        [JsonPropertyName("Username")]
        [DataMember]
        public new string Username { get; set; }

        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [JsonPropertyName("cardNumber")]
        [DataMember]
        public string cardNumber { get; set; }

        [Required]
        [JsonPropertyName("ReferenceNumber")]
        [DataMember]
        public string ReferenceNumber { get; set; }

        [Required]
        [JsonPropertyName("StatusCode")]
        [DataMember]
        public int StatusCode { get; set; }

        [Required]
        [JsonPropertyName("StatusChangeReasonCode")]
        [DataMember]
        public int StatusChangeReasonCode { get; set; }
    }

    public class CustomerAPIHotlistReactivateCardModelOutput : CustomerAPIBaseClassOutput
    {
     
        [JsonProperty("cardNumber ")]
        [DataMember]
        public string cardNumber { get; set; }


        [JsonProperty("referenceNumber ")]
        [DataMember]
        public string referenceNumber { get; set; }


        [JsonProperty("statusCode ")]
        [DataMember]
        public int statusCode { get; set; }


        [JsonProperty("statusChangeReasonCode ")]
        [DataMember]
        public int statusChangeReasonCode { get; set; }
    }
}
