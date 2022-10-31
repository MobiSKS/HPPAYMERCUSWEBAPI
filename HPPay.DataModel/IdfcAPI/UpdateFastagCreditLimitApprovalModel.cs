using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.IdfcAPI
{
    public class UpdateFastagCreditLimitApprovalModelInput:BaseClass
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
        [JsonPropertyName("TypeFastagCreditLimitApproval")]
        [DataMember]
        public List<GetTypeFastagCreditLimitApproval> TypeFastagCreditLimitApproval { get; set; }

    }



    public class GetTypeFastagCreditLimitApproval
    {


        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [JsonPropertyName("RequestedCreditLimit")]
        [DataMember]
        public string RequestedCreditLimit { get; set; }

        [Required]
        [JsonPropertyName("CCMSRechargeType")]
        [DataMember]
        public string CCMSRechargeType { get; set; }


        [Required]
        [JsonPropertyName("Remarks")]
        [DataMember]
        public string Remarks { get; set; }
    }



    public class UpdateFastagCreditLimitApprovalModelOutput:BaseClassOutput
    {

    }

}
