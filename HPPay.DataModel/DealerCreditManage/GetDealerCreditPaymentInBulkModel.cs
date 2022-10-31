using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.DealerCreditManage
{
    public class GetDealerCreditPaymentInBulkModelInput:BaseClass
    {

        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }

    public class GetDealerCreditPaymentInBulkModelOutput
    {
        
        [JsonProperty("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

      
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }

        [JsonProperty("Outstanding")]
        [DataMember]
        public decimal Outstanding { get; set; }

        [JsonProperty("Amount")]
        [DataMember]
        public decimal Amount { get; set; }
    }
}
