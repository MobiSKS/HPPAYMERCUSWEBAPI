using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.CustomerAPI
{
    public class CustomerAPIGetTransactionsModelInput : CustomerAPIBaseClassInput
    {
        [Required]
        [JsonPropertyName("customerID")]
        [DataMember]
        public string customerID { get; set; }

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

    public class CustomerAPIGetTransactionsFinalOutputModel
    {
        public CustomerAPIGetTransactionsFinalOutputModel()
        {
            customerAPIGetTransactionStatus = new List<CustomerAPIGetTransactionStatus>();
            customerAPIGetTransactionsModelOutput = new List<CustomerAPIGetTransactionsModelOutput>();
        }
        public List<CustomerAPIGetTransactionStatus> customerAPIGetTransactionStatus { get; set; }
        public List<CustomerAPIGetTransactionsModelOutput> customerAPIGetTransactionsModelOutput { get; set; }

    }

    public class CustomerAPIGetTransactionStatus
    {
        [JsonProperty("responseMessage")]
        [DataMember]
        public string responseMessage { get; set; }
    }
    public class CustomerAPIGetTransactionsModelOutput
    {
      
        [JsonProperty("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }


        [JsonProperty("BatchId")]
        [DataMember]
        public string BatchId { get; set; }


        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonProperty("VehicleNo")]
        [DataMember]
        public string VehicleNo { get; set; }


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

    }
}
