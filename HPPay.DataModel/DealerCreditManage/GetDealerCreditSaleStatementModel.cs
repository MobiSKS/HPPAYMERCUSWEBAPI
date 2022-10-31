using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.DealerCreditManage
{
    public class GetDealerCreditSaleStatementModelInput : BaseClass
    {
        [Required]
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
    public class GetDealerCreditSaleStatementModelOutput 
    {
        
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        
        [JsonProperty("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

        [JsonProperty("TransactionType")]
        [DataMember]
        public string TransactionType { get; set; }

    
        [JsonProperty("TransactionDate")]
        [DataMember]
        public string TransactionDate { get; set; }


       
        [JsonProperty("AccountNumber")]
        [DataMember]
        public string AccountNumber { get; set; }

        
        [JsonProperty("TokenNumber")]
        [DataMember]
        public string TokenNumber { get; set; }

        
        [JsonProperty("TransactionAmount")]
        [DataMember]
        public decimal TransactionAmount { get; set; }

        [JsonProperty("Balance")]
        [DataMember]
        public string Balance { get; set; }

    }
}
