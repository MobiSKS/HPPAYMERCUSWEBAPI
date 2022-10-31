using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Card
{
    public class UpdateApproveCardReissuanceRequestModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("ApprovedBy")]
        [DataMember]
        public string ApprovedBy { get; set; }

        [Required]
        [JsonPropertyName("ActionType")]
        [DataMember]
        public string ActionType { get; set; }

        [Required]
        [JsonPropertyName("TypeApproveRejectCardReissuanceRequest")]
        [DataMember]
        public List<TypeApproveRejectCardReissuanceRequest> TypeApproveRejectCardReissuanceRequest { get; set; }
    }

    public class TypeApproveRejectCardReissuanceRequest
    {

        [Required]
        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonPropertyName("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }

        [JsonPropertyName("Remarks")]
        [DataMember]
        public string Remarks { get; set; }

        //[JsonPropertyName("HotlistReasonId")]
        //[DataMember]
        //public string HotlistReasonId { get; set; }
    }

    public class UpdateApproveCardReissuanceRequestModelOutput : BaseClassOutput
    {

    }
}
