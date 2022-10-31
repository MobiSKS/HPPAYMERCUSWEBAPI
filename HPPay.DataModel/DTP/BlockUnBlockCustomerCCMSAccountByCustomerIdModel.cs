using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.DTP
{
    public  class BlockUnBlockCustomerCCMSAccountInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [JsonPropertyName("CCMSBalanceStatus")]
        [DataMember]
        public int CCMSBalanceStatus { get; set; }

        [Required]
        [JsonPropertyName("CCMSBalanceRemarks")]
        [DataMember]
        public string CCMSBalanceRemarks { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }
    }

    public class BlockUnBlockCustomerCCMSAccountOutput : BaseClassOutput
    {
         
    }
}
