using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.TMS
{

    public class BindEnrollTransportManagementSystemModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
    }
    public class BindEnrollTransportManagementSystemModelOutput
    {
       
        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("ContactNo")]
        [DataMember]
        public string ContactNo { get; set; }

        [JsonProperty("Address1")]
        [DataMember]
        public string Address1 { get; set; }
        [JsonProperty("Address2")]
        [DataMember]
        public string Address2 { get; set; }

        [JsonProperty("City")]
        [DataMember]
        public string City { get; set; }
        [JsonProperty("State")]
        [DataMember]
        public string State { get; set; }

        [JsonProperty("Pincode")]
        [DataMember]
        public string Pincode { get; set; }

        [JsonProperty("Email")]
        [DataMember]
        public string Email { get; set; }
        
    }
}
