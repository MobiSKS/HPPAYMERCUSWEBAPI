using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.CustomerAPI
{
    public class CustomerAPIGetTransactionsV2ModelInput : CustomerAPIBaseClassInput
    {
        [Required]
        [RegularExpression(@"\d{10}", ErrorMessage = "Invalid CustomerID")]
        [JsonPropertyName("customerID")]
        [DataMember]
        public string customerID { get; set; }

        [RegularExpression(@"\d{10}", ErrorMessage = "Invalid childID")]
        [JsonPropertyName("childID")]
        [DataMember]
        public string childID { get; set; }

        [Required]
        [JsonPropertyName("fromdate")]
        [DataMember]
        public string fromdate { get; set; }

        [Required]
        [JsonPropertyName("todate")]
        [DataMember]
        public string todate { get; set; }

    }

    public class CustomerAPIGetTransactionsV2FinalOutputModel
    {
        public CustomerAPIGetTransactionsV2FinalOutputModel()
        {
            customerAPIGetTransactionV2Status = new List<CustomerAPIGetTransactionV2Status>();
            customerAPIGetTransactionsV2ModelOutput = new List<CustomerAPIGetTransactionsV2ModelOutput>();
        }
        public List<CustomerAPIGetTransactionV2Status> customerAPIGetTransactionV2Status { get; set; }
        public List<CustomerAPIGetTransactionsV2ModelOutput> customerAPIGetTransactionsV2ModelOutput { get; set; }

    }

    public class CustomerAPIGetTransactionV2Status
    {
        [JsonProperty("responseMessage")]
        [DataMember]
        public string responseMessage { get; set; }
    }

    public class CustomerAPIGetTransactionsV2ModelOutput
    {
        [JsonProperty("terminalID")]
        [DataMember]
        public string terminalID { get; set; }

        [JsonProperty("merchantName")]
        [DataMember]
        public string merchantName { get; set; }

        [JsonProperty("merchantID")]
        [DataMember]
        public string merchantID { get; set; }

        [JsonProperty("customerID")]
        [DataMember]
        public string customerID { get; set; }

        [JsonProperty("batchIDROC")]
        [DataMember]
        public string batchIDROC { get; set; }

        [JsonProperty("accountNumber")]
        [DataMember]
        public string accountNumber { get; set; }

        [JsonProperty("transactionDate")]
        [DataMember]
        public string transactionDate { get; set; }

        [JsonProperty("transactionType")]
        [DataMember]
        public string transactionType { get; set; }

        [JsonProperty("product")]
        [DataMember]
        public string product { get; set; }

        [JsonProperty("price")]
        [DataMember]
        public string price { get; set; }

        [JsonProperty("volume")]
        [DataMember]
        public string volume { get; set; }

        [JsonProperty("currency")]
        [DataMember]
        public string currency { get; set; }

        [JsonProperty("serviceCharge")]
        [DataMember]
        public string serviceCharge { get; set; }

        [JsonProperty("amount")]
        [DataMember]
        public string amount { get; set; }

        [JsonProperty("balance")]
        [DataMember]
        public string balance { get; set; }

        [JsonProperty("odometerReading")]
        [DataMember]
        public string odometerReading { get; set; }

        [JsonProperty("drivestars")]
        [DataMember]
        public string drivestars { get; set; }

        [JsonProperty("rewardType")]
        [DataMember]
        public string rewardType { get; set; }

        [JsonProperty("status")]
        [DataMember]
        public string status { get; set; }

        [JsonProperty("uniqueTransactionID")]
        [DataMember]
        public string uniqueTransactionID { get; set; }


        [JsonProperty("customerCardNumber")]
        [DataMember]
        public string customerCardNumber { get; set; }


    }

}
