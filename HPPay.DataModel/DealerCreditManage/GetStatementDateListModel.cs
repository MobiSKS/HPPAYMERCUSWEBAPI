using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.DealerCreditManage
{
    public class GetStatementDateListModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }

    public class GetStatementDateListModelOutput: BaseClassOutput
    {
       
        [JsonProperty("StatementDate")]
        [DataMember]
        public string StatementDate { get; set; }
    }
}
