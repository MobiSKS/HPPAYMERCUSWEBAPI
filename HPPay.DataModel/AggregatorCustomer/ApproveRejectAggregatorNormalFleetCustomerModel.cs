using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.AggregatorCustomer
{
  
    public class ApproveRejectAggregatorNormalFleetCustomerModelInput : BaseClass
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
        [JsonPropertyName("CustomerStatus")]
        [DataMember]
        public string CustomerStatus { get; set; }

        [JsonPropertyName("ApprovedRemark")]
        [DataMember]
        public string ApprovedRemark { get; set; }

        [Required]
        [JsonPropertyName("Approvedby")]
        [DataMember]
        public string Approvedby { get; set; }

    }
    public class ApproveRejectAggregatorNormalFleetCustomerModelOutput : BaseClassOutput
    {

    }
}
