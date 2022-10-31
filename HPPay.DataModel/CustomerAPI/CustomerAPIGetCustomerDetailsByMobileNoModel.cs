using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
namespace HPPay.DataModel.CustomerAPI
{
    public class CustomerAPIGetCustomerDetailsByMobileNoModelInput:CustomerAPIBaseClassInput
    {

        [Required]
        [JsonPropertyName("mobile")]
        [DataMember]
        public string mobile { get; set; }
    }

    public class CustomerAPIGetCustomerDetailsByMobileNoModelOutput : CustomerAPIBaseClassOutput
    {
        [JsonProperty("productList")]
        [DataMember]
        public List<CustomerDetails> customerDtls { get; set; }
    }

    public class CustomerDetails
    {
        [JsonProperty("customerID")]
        [DataMember]
        public string customerID { get; set; }


        [JsonProperty("customerName")]
        [DataMember]
        public string customerName { get; set; }
    }
    public class MainResponse : CustomerAPIBaseClassOutput
    {

    }

    public class CustomerMainResponseList
    {
        [JsonProperty("customerDtlsTemp")]
        [DataMember]
        public List<CustomerDetails> customerDtlsTemp { get; set; }

        [JsonProperty("mainResponse")]
        [DataMember]
        public List<MainResponse> mainResponse { get; set; }
    }
}
