using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.M2PAPI
{
    public class M2PAPIGetConsumptionDataModelInput:M2PAPIBaseClassInput
    {
        [Required]
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [Required]
        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }
    }

    public class M2PAPIGetConsumptionDataModelOutput 
    {
        [JsonProperty("consumptionRes")]
        [DataMember]
        public List<GetconsumptionRes>consumptionRes { get; set; }

        [JsonProperty("headerDetails")]
        [DataMember]
        public List<headerDetail> headerDetails { get; set; }

        [JsonProperty("transactionsDetails")]
        [DataMember]
        public List<transactionsDetail> transactionsDetails { get; set; }
    }

    public class GetconsumptionRes
    {
        [JsonProperty("responseCode")]
        [DataMember]
        public string responseCode { get; set; }

        [JsonProperty("responseMessage")]
        [DataMember]
        public string responseMessage { get; set; }
    }

    public class headerDetail
    {
        [JsonProperty("numberOfRecords")]
        [DataMember]
        public int numberOfRecords { get; set; }

        [JsonProperty("sumOfAmount")]
        [DataMember]
        public decimal sumOfAmount { get; set; }

        [JsonProperty("webServiceCalId")]
        [DataMember]
        public string webServiceCalId { get; set; }
    }

    public class transactionsDetail
    {

        [JsonProperty("cardNumber")]
        [DataMember]
        public string cardNumber { get; set; }

        [JsonProperty("batchID")]
        [DataMember]
        public int batchID { get; set; }

        [JsonProperty("batchTransactionNumber")]
        [DataMember]
        public int batchTransactionNumber { get; set; }

        [JsonProperty("certificateNumber")]
        [DataMember]
        public string certificateNumber { get; set; }

        [JsonProperty("odometer")]
        [DataMember]
        public int odometer { get; set; }


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
        public int itemConsumed { get; set; }

        [JsonProperty("amount")]
        [DataMember]
        public decimal amount { get; set; }


        [JsonProperty("transactionDate")]
        [DataMember]
        public string transactionDate { get; set; }

        [JsonProperty("settlementDate")]
        [DataMember]
        public string settlementDate { get; set; }
    }
}
