using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.CustomerAPI
{
    public class CustomerAPIGetConsumptionDataModelInput : CustomerAPIBaseClassInput
    {
        
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [Required]
        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }
    }

    public class CustomerAPIGetConsumptionDataModelOutput: CustomerAPIBaseClassOutput
    {

        [JsonProperty("consumptionRes")]
        [DataMember]
        public List<GetHeaderDetails> consumptionRes { get; set; }

        [JsonProperty("transactionsDetails")]
        [DataMember]
        public List<GetTransactionDetails> transactionsDetails { get; set; }

    }

    //public class CustomerAPIGetConsumptionDataModelFInalOutput
    //{
    //    //[JsonProperty("responseCode")]
    //    //[DataMember]
    //    //public string responseCode { get; set; }

    //    //[JsonProperty("responseMessage")]
    //    //[DataMember]
    //    //public string responseMessage { get; set; }

    //    //[JsonProperty("numberOfRecords")]
    //    //[DataMember]
    //    //public int numberOfRecords { get; set; }

    //    //[JsonProperty("sumOfAmount")]
    //    //[DataMember]
    //    //public decimal sumOfAmount { get; set; }


    //    //[JsonProperty("customerID")]
    //    //[DataMember]
    //    //public string customerID { get; set; }


    //    //[JsonProperty("fromDate")]
    //    //[DataMember]
    //    //public string fromDate { get; set; }

    //    //[JsonProperty("toDate")]
    //    //[DataMember]
    //    //public string toDate { get; set; }


    //    [JsonProperty("TransactionDetails")]
    //    [DataMember]
    //    public List<GetTransactionDetails> TransactionDetails { get; set; }

    //}

    public class GetHeaderDetails 
    {

        [JsonProperty("numberOfRecords")]
        [DataMember]
        public int numberOfRecords { get; set; }

        [JsonProperty("sumOfAmount")]
        [DataMember]
        public decimal sumOfAmount { get; set; }

        [JsonProperty("customerID")]
        [DataMember]
        public string customerID { get; set; }

        [JsonProperty("fromDate")]
        [DataMember]
        public string fromDate { get; set; }

        [JsonProperty("toDate")]
        [DataMember]
        public string toDate { get; set; }
    }

    public class GetTransactionDetails
    {
        [JsonProperty("cardNumber")]
        [DataMember]
        public string cardNumber { get; set; }

        [JsonProperty("batchID")]
        [DataMember]
        public int batchID { get; set; }

        [JsonProperty("batchTransactionNumber")]
        [DataMember]
        public string batchTransactionNumber { get; set; }

        [JsonProperty("certificateNumber")]
        [DataMember]
        public string certificateNumber { get; set; }

        [JsonProperty("odometer")]
        [DataMember]
        public decimal odometer { get; set; }

        [JsonProperty("terminalID")]
        [DataMember]
        public string terminalID { get; set; }


        [JsonProperty("merchantName")]
        [DataMember]
        public string merchantName { get; set; }


        [JsonProperty("merchantPlace")]
        [DataMember]
        public string merchantPlace { get; set; }


        [JsonProperty("itemConsumed")]
        [DataMember]
        public decimal itemConsumed { get; set; }


        [JsonProperty("transactionDate")]
        [DataMember]
        public string transactionDate { get; set; }


        [JsonProperty("settlementDate")]
        [DataMember]
        public string settlementDate { get; set; }
    }
}
