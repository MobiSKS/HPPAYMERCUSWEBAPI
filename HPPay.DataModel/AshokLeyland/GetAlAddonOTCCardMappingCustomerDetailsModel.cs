using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.AshokLeyland
{
    public class GetAlAddonOTCCardMappingCustomerDetailsModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
    }

    public class GetAlAddonOTCCardMappingCustomerDetailsModelOutput
    {
        [JsonProperty("GetCustomerNameAndNameOnCard")]
        public List<GetCustomerNameAndNameOnCardModelOutput> GetCustomerNameAndNameOnCardOutput { get; set; }

        [JsonProperty("GetStatus")]
        public List<GetCustomerStatusOutput> GetCustomerStatusOutput { get; set; }
    }

    public class GetCustomerNameAndNameOnCardModelOutput
    {
        [JsonProperty("CustomerOrgName")]
        [DataMember]
        public string CustomerOrgName { get; set; }

        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }
    }

    public class GetCustomerStatusOutput : BaseClassOutput
    {
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }
}
