using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    public class ApproveRejectMerchantUpdateModelInput : BaseClass
    {
        [JsonPropertyName("ObjApprovalRejectDetail")]
        [DataMember]
        public List<ApprovalRejectModelInput> ObjApprovalRejectDetail { get; set; }

        [Required]
        [JsonPropertyName("StatusId")]
        [DataMember]
        public Int32 StatusId { get; set; }

        [Required]
        [JsonPropertyName("ApprovedBy")]
        [DataMember]
        public string ApprovedBy { get; set; }
    }

    public class ApproveRejectMerchantUpdateModelOutput : BaseClassOutput
    {
        [JsonProperty("SendStatus")]
        [DataMember]
        public int? SendStatus { get; set; }
    }
}
