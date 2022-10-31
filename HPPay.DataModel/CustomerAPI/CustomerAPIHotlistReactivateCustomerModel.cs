using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.CustomerAPI
{

    public class CustomerAPIHotlistReactivateCustomerModelInput : CustomerAPIBaseClassInput
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
    public class CustomerAPIHotlistReactivateCustomerModelOutput : CustomerAPIBaseClassOutput
    {

        [JsonProperty("customerID ")]
        [DataMember]
        public string customerID { get; set; }


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
