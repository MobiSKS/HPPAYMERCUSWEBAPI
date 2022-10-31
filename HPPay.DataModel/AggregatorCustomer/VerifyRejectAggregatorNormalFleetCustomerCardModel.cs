using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
namespace HPPay.DataModel.AggregatorCustomer
{
    public class VerifyRejectAggregatorNormalFleetCustomerCardModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [Required]
        [JsonPropertyName("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }

        [Required]
        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [Required]
        [JsonPropertyName("CardStatus")]
        [DataMember]
        public string CardStatus { get; set; }

        [JsonPropertyName("VerifyRemark")]
        [DataMember]
        public string VerifyRemark { get; set; }

        [Required]
        [JsonPropertyName("VerifyBy")]
        [DataMember]
        public string VerifyBy { get; set; }

    }
    public class VerifyRejectAggregatorNormalFleetCustomerCardModelOutput : BaseClassOutput
    {

    }
}
