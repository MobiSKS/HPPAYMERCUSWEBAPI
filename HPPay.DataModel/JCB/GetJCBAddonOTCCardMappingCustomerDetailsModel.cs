using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.JCB
{
    public class GetJCBAddonOTCCardMappingCustomerDetailsModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
    }

    public class GetJCBAddonOTCCardMappingCustomerDetailsModelOutput
    {
        [JsonProperty("GetCustomerNameAndNameOnCard")]
        public List<GetJCBCustomerNameAndNameOnCardModelOutput> GetCustomerNameAndNameOnCardOutput { get; set; }

        [JsonProperty("GetStatus")]
        public List<GetJCBCustomerStatusOutput> GetCustomerStatusOutput { get; set; }
    }

    public class GetJCBCustomerNameAndNameOnCardModelOutput
    {
        [JsonProperty("CustomerOrgName")]
        [DataMember]
        public string CustomerOrgName { get; set; }

        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }
    }

    public class GetJCBCustomerStatusOutput : BaseClassOutput
    {
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }
}
