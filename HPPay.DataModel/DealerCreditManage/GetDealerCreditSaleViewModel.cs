using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.DealerCreditManage
{
    public class GetDealerCreditSaleViewModelInput: BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

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

    public class GetDealerCreditSaleViewModelOutput 
    {
        [JsonProperty("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

        [JsonProperty("OutletNameAndLocation")]
        [DataMember]
        public string OutletNameAndLocation { get; set; }

        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("TransactionType")]
        [DataMember]
        public string TransactionType { get; set; }

        [JsonProperty("AccountNumber")]
        [DataMember]
        public string AccountNumber { get; set; }

        [JsonProperty("TransactionAmount")]
        [DataMember]
        public string TransactionAmount { get; set; }

        [JsonProperty("TransactionDate")]
        [DataMember]
        public string TransactionDate { get; set; }

        [JsonProperty("Balance")]
        [DataMember]
        public string Balance { get; set; }

        [JsonProperty("RSP")]
        [DataMember]
        public string RSP { get; set; }
       
        [JsonProperty("TokenNumber")]
        [DataMember]
        public string TokenNumber { get; set; }



    }
}
