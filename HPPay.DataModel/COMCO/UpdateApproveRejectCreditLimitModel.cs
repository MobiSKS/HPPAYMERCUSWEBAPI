using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.COMCO
{
    public class UpdateApproveRejectCreditLimitModelInput:BaseClass
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
        [JsonPropertyName("TypeApproveRejectCreditLimit")]
        [DataMember]
        public List<GetTypeApproveRejectCreditLimit> TypeApproveRejectCreditLimit { get; set; }
    }


    public class GetTypeApproveRejectCreditLimit
    {
        

        [Required]
        [JsonPropertyName("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [JsonPropertyName("Comments")]
        [DataMember]
        public string Comments { get; set; }

        [Required]
        [JsonPropertyName("REQID")]
        [DataMember]
        public string REQID { get; set; }

        [Required]
        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

        [Required]
        [JsonPropertyName("CautionAmount")]
        [DataMember]
        public decimal CautionAmount { get; set; }
    }
    public class UpdateApproveRejectCreditLimitModelOutput : BaseClassOutput
    {

    }
}
