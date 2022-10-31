using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.CustomerAPI
{
    public class CustomerAPIGetCustomerHotlistStatusModelInput: CustomerAPIBaseClassInput
    {

        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
    }

    public class CustomerAPIGetCustomerHotlistStatusModelOutput : CustomerAPIBaseClassOutput
    {
        [JsonProperty("hotlistStatus")]
        [DataMember]
        public string hotlistStatus { get; set; }

        [JsonProperty("customerID")]
        [DataMember]
        public string customerID { get; set; }

        [JsonProperty("hotlistingRemarks")]
        [DataMember]
        public string hotlistingRemarks { get; set; }

        [JsonProperty("hotlistReason")]
        [DataMember]
        public string hotlistReason { get; set; }

    }
}
