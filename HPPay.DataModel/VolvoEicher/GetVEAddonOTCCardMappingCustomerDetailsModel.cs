using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.VolvoEicher
{
    public class GetVEAddonOTCCardMappingCustomerDetailsModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
    }

    public class GetVEAddonOTCCardMappingCustomerDetailsModelOutput
    {
        [JsonProperty("GetCustomerNameAndNameOnCard")]
        public List<GetVECustomerNameAndNameOnCardModelOutput> GetCustomerNameAndNameOnCardOutput { get; set; }

        [JsonProperty("GetStatus")]
        public List<GetVECustomerStatusOutput> GetCustomerStatusOutput { get; set; }
    }

    public class GetVECustomerNameAndNameOnCardModelOutput
    {
        [JsonProperty("CustomerOrgName")]
        [DataMember]
        public string CustomerOrgName { get; set; }

        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }
    }

    public class GetVECustomerStatusOutput : BaseClassOutput
    {
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }
}
