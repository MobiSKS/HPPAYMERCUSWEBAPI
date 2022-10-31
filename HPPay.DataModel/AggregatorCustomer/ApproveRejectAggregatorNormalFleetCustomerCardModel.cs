using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.AggregatorCustomer
{
   
    public class ApproveRejectAggregatorNormalFleetCustomerCardModelInput : BaseClass
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

        [JsonPropertyName("ApprovedRemark")]
        [DataMember]
        public string ApprovedRemark { get; set; }

        [Required]
        [JsonPropertyName("Approvedby")]
        [DataMember]
        public string Approvedby { get; set; }

    }
    public class ApproveRejectAggregatorNormalFleetCustomerCardModelOutput : BaseClassOutput
    {

    }
}
