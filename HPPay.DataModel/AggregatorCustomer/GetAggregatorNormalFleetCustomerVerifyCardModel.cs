using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.AggregatorCustomer
{
    public class GetAggregatorNormalFleetCustomerVerifyCardModelInput : BaseClass
    {

        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string @CustomerId { get; set; }

        [JsonPropertyName("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }

        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }


    }

    public class GetAggregatorNormalFleetCustomerVerifyCardModelOutput
    {


        [JsonProperty("ZO")]
        [DataMember]
        public string ZO { get; set; }


        [JsonProperty("RO")]
        [DataMember]
        public string RO { get; set; }


        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }


        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }


        [JsonProperty("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }


        [JsonProperty("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }

        [JsonProperty("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }

        [JsonProperty("PaymentType")]
        [DataMember]
        public string PaymentType { get; set; }

        [JsonProperty("Createdby")]
        [DataMember]
        public string Createdby { get; set; }

        [JsonProperty("CreatedOn")]
        [DataMember]
        public string CreatedOn { get; set; }

        [JsonProperty("RCCopy")]
        [DataMember]
        public string RCCopy { get; set; }
    }
}
