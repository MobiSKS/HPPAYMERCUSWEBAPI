using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    public class MerchantApprovalRejectModelInput : BaseClass
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

    public class ApprovalRejectModelInput 
    {
        [Required]
        [JsonPropertyName("ErpCode")]
        [DataMember]
        public string ErpCode { get; set; }


        [Required]
        [JsonPropertyName("Comments")]
        [DataMember]
        public string Comments { get; set; }

        
    }

    public class MerchantApprovalRejectModelOutput : BaseClassOutput
    {
        [JsonProperty("ErpCode")]
        [DataMember]
        public string ErpCode { get; set; }

        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonProperty("DealerName")]
        [DataMember]
        public string DealerName { get; set; }

        [JsonProperty("UserName")]
        [DataMember]
        public string UserName { get; set; }


        [JsonProperty("Password")]
        [DataMember]
        public string Password { get; set; }

        [JsonProperty("EmailId")]
        [DataMember]
        public string EmailId { get; set; }

        [JsonProperty("SendStatus")]
        [DataMember]
        public int? SendStatus { get; set; }

        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }
    }
}
