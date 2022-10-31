using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.AggregatorCustomer
{
    public class GetAggregateUserDetailForApprovalModelInput : BaseClass
    {
       
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }

       
        [JsonPropertyName("AggregatorID")]
        [DataMember]
        public string AggregatorID { get; set; }
    }

    public class GetAggregateUserDetailForApprovalModelOutput : BaseClassOutput
    {
        [JsonProperty("UserName")]
        [DataMember]
        public string UserName { get; set; }

        [JsonProperty("Email")]
        [DataMember]
        public string Email { get; set; }

        [JsonProperty("RequestedBy")]
        [DataMember]
        public string RequestedBy { get; set; }

        [JsonProperty("RequestedOn")]
        [DataMember]
        public string RequestedOn { get; set; }

        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

       

    }

    public class ApproveRejectAggregateUserApprovalModelInput : BaseClass
    {

        [Required]
        [JsonPropertyName("Approvalstatus")]
        [DataMember]
        public Int32 Approvalstatus { get; set; }



        [Required]
        [JsonPropertyName("UserDetail")]
        [DataMember]
        public List<AggregatorUserForApproval> UserDetail { get; set; }
    }

    public class AggregatorUserForApproval
    {
        [Required]
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }

        [Required]
        [JsonPropertyName("Comments")]
        [DataMember]
        public string Comments { get; set; }

    }

    public class ApproveRejectAggregateUserApprovalModelOutput : BaseClassOutput
    {
    }
}
