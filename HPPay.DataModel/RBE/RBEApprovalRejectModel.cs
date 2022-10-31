using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.RBE
{
    public class RBEApprovalRejectModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("TypesApproveRejectRBE")]
        [DataMember]
        public List<TypesApproveRejectRBE> TypesApproveRejectRBE { get; set; }


        [Required]
        [JsonPropertyName("Comments")]
        [DataMember]
        public string Comments { get; set; }


        [Required]
        [JsonPropertyName("Approvalstatus")]
        [DataMember]
        public Int32 Approvalstatus { get; set; }

        [Required]
        [JsonPropertyName("ApprovedBy")]
        [DataMember]
        public string ApprovedBy { get; set; }
    }

    public class TypesApproveRejectRBE
    {
        [Required]
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }
    }


    public class RBEApprovalRejectApprovalModelOutput : BaseClassOutput
    {
        [Required]
        [JsonProperty("FirstName")]
        [DataMember]
        public string FirstName { get; set; }

        [Required]
        [JsonProperty("LastName")]
        [DataMember]
        public string LastName { get; set; }

        [Required]
        [JsonProperty("EmailId")]
        [DataMember]
        public string EmailId { get; set; }

        [Required]
        [JsonProperty("RBEOTP")]
        [DataMember]
        public string RBEOTP { get; set; }
    }
}
