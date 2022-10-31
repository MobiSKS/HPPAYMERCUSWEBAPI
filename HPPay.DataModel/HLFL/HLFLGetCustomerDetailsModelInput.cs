using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace HPPay.DataModel.HLFL
{
    public class HLFLGetCustomerDetailsModelInput
    {
         

        [JsonPropertyName("AggrCustomerID")]
        [DataMember]
        public string AggrCustomerID { get; set; }         

    }

    public class HLFLGetCustomerDetailsModelOutput
    {

        [JsonProperty("hlflStatusCode")]
        [DataMember]
        public string hlflStatusCode { get; set; }

        [JsonProperty("hlflStatusRemark")]
        [DataMember]
        public string hlflStatusRemark { get; set; }

        [JsonProperty("aggrId")]
        [DataMember]
        public string aggrId { get; set; }


        [JsonProperty("hlflFacilityNumber")]
        [DataMember]
        public string hlflFacilityNumber { get; set; }


        [JsonProperty("AggrControlCardNumber")]
        [DataMember]
        public string AggrControlCardNumber { get; set; }

        [JsonProperty("HLFLCustomerId")]
        [DataMember]
        public string HLFLCustomerId { get; set; }

        [JsonProperty("AggrCustomerID")]
        [DataMember]
        public string AggrCustomerID { get; set; }

        [JsonProperty("aggrRequestId")]
        [DataMember]
        public string aggrRequestId { get; set; }

        [JsonProperty("hlflRequestId")]
        [DataMember]
        public string hlflRequestId { get; set; }

        [JsonProperty("orderId")]
        [DataMember]
        public string orderId { get; set; }

        [JsonProperty("FacilityNumber")]
        [DataMember]
        public string FacilityNumber { get; set; }
    }
    public class HLFLDetailsModelOutput:BaseClassOutput
    {
    }
}
