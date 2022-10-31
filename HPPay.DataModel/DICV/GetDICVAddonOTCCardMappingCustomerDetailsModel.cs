using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.DICV
{
    public class GetDICVAddonOTCCardMappingCustomerDetailsModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
    }

    public class GetDICVAddonOTCCardMappingCustomerDetailsModelOutput
    {
        [JsonProperty("GetCustomerNameAndNameOnCard")]
        public List<GetDICVCustomerNameAndNameOnCardModelOutput> GetCustomerNameAndNameOnCardOutput { get; set; }

        [JsonProperty("GetStatus")]
        public List<GetDICVCustomerStatusOutput> GetCustomerStatusOutput { get; set; }
    }

    public class GetDICVCustomerNameAndNameOnCardModelOutput
    {
        [JsonProperty("CustomerOrgName")]
        [DataMember]
        public string CustomerOrgName { get; set; }

        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }
    }

    public class GetDICVCustomerStatusOutput : BaseClassOutput
    {
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }
}
