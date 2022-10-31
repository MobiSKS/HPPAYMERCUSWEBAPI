using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Card
{
    public class CardUpdateApproveCardRenewalRequestsModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [Required]
        [JsonPropertyName("ActionType")]
        [DataMember]
        public string ActionType { get; set; }

        [Required]
        [JsonPropertyName("TypeApproveCardRenewalRequests")]
        [DataMember]
        public List<TypeApproveCardRenewalRequests> TypeApproveCardRenewalRequests { get; set; }
    }

    public class TypeApproveCardRenewalRequests
    {

        [Required]
        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonPropertyName("RenewalRemark")]
        [DataMember]
        public string RenewalRemark { get; set; }
    }

    public class CardUpdateApproveCardRenewalRequestsModelOutput : BaseClassOutput
    {

    }
}
