using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.DTP
{
    public  class GetBlockUnBlockCustomerCCMSAccountByCustomerIdModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }

    public class GetBlockUnBlockCustomerCCMSAccountByCustomerIdModelOutput : BaseClassOutput
    {
        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }
       
        [JsonProperty("CCMSBalanceStatusId")]
        [DataMember]
        public int CCMSBalanceStatusId { get; set; }

        [JsonProperty("CCMSBalanceStatusName")]
        [DataMember]
        public string CCMSBalanceStatusName { get; set; }


        [JsonProperty("CCMSBalanceRemarks")]
        [DataMember]
        public string CCMSBalanceRemarks { get; set; }
    }
}
