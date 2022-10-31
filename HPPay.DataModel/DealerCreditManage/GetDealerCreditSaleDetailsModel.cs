using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.DealerCreditManage
{
    public class GetDealerCreditSaleDetailsModelInput:BaseClass
    {
        
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [JsonPropertyName("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

        [Required]
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [Required]
        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }
    }

    public class GetDealerCreditSaleDetailsModelOutput
    {
        [Required]
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [JsonProperty("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

        [Required]
        [JsonProperty("TransactionType")]
        [DataMember]
        public string TransactionType { get; set; }

        [Required]
        [JsonProperty("TransactionDate")]
        [DataMember]
        public string TransactionDate { get; set; }


        [Required]
        [JsonProperty("AccountNumber")]
        [DataMember]
        public string AccountNumber { get; set; }

        [Required]
        [JsonProperty("TokenNumber")]
        [DataMember]
        public int TokenNumber { get; set; }

        [Required]
        [JsonProperty("TransactionAmount")]
        [DataMember]
        public decimal TransactionAmount { get; set; }

        [Required]
        [JsonProperty("Balance")]
        [DataMember]
        public string Balance { get; set; }
    }
}
