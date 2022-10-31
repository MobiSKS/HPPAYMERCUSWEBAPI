using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{
    public class CustomerGetCustomerCardWiseBalancesModelInput : BaseClass
    {
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }

    public class CustomerGetCustomerCardWiseBalancesModelOutput
    {
        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonProperty("LastDateOfTransaction")]
        [DataMember]
        public string LastDateOfTransaction { get; set; }

        [JsonProperty("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }

        [JsonProperty("Mobileno")]
        [DataMember]
        public string Mobileno { get; set; }

        [JsonProperty("CardBalance")]
        [DataMember]
        public decimal CardBalance { get; set; }
        
    }

    public class CustomerGetCcmsBalanceInfoForCustomerIdModelInput : BaseClass
    {
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }

    public class CustomerGetCcmsBalanceInfoForCustomerIdModelOutput
    {
        [JsonProperty("Mode")]
        [DataMember]
        public string Mode { get; set; }

        [JsonProperty("Description")]
        [DataMember]
        public string Description { get; set; }

        [JsonProperty("TransactionDate")]
        [DataMember]
        public string TransactionDate { get; set; }

        [JsonProperty("OpeningBalance")]
        [DataMember]
        public decimal OpeningBalance { get; set; }

        [JsonProperty("PostingMethod")]
        [DataMember]
        public string PostingMethod { get; set; }

        [JsonProperty("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

        [JsonProperty("ClosingBalance")]
        [DataMember]
        public decimal ClosingBalance { get; set; }

    }
}
