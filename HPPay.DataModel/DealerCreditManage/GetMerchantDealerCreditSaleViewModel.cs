using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.DealerCreditManage
{
    public class GetMerchantDealerCreditSaleStatementModelInput
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
        [JsonPropertyName("StatementDate")]
        [DataMember]
        public string StatementDate { get; set; }
    }
    public class GetMerchantDealerCreditSaleStatementModelOutput 
    {
        [JsonProperty("ViewStatementDetails")]

        public List<ViewStatementDetails> ViewStatementDetails { get; set; }


        [JsonProperty("TransactionDetails")]

        public List<TransactionDetails> TransactionDetails { get; set; }


    }

    public class ViewStatementDetails : BaseClassOutput
    {
        [JsonProperty("StatementDate")]
        [DataMember]
        public string StatementDate { get; set; }

        [JsonProperty("StatementPeriod")]
        [DataMember]
        public string StatementPeriod { get; set; }

        [JsonProperty("Purchase")]
        [DataMember]
        public string Purchase { get; set; }

        [JsonProperty("Payment")]
        [DataMember]
        public string Payment { get; set; }

        [JsonProperty("PreviousOutstanding")]
        [DataMember]
        public string PreviousOutstanding { get; set; }

        [JsonProperty("AmountDue")]
        [DataMember]
        public string AmountDue { get; set; }

        
    }
    public class TransactionDetails
    { 


        [JsonProperty("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }


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

        [JsonProperty("TokenNumber")]
        [DataMember]
        public string TokenNumber { get; set; }

        [JsonProperty("TransactionAmount")]
        [DataMember]
        public decimal TransactionAmount { get; set; }

        [JsonProperty("TransactionDate")]
        [DataMember]
        public string TransactionDate { get; set; }

        [JsonProperty("Balance")]
        [DataMember]
        public decimal Balance { get; set; }

       

    }
}