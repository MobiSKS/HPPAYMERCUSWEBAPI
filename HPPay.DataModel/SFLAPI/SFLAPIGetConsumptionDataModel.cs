using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.SFLAPI
{
    public class SFLAPIGetConsumptionDataModelInput : SFLAPIBaseClassInput
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

    public class SFLAPIGetConsumptionDataModelOutput
    {

        [JsonProperty("consumptionRes")]
        [DataMember]
        public GetconsumptionRes consumptionRes { get; set; }

    }
    public class GetconsumptionRes : SFLAPIBaseClassOutput
    {
        [JsonProperty("headerDetails")]
        [DataMember]
        public GetheaderDetails headerDetails { get; set; }

        [JsonProperty("transactionsDetails")]
        [DataMember]
        public List<GetTransactionDetails> transactionsDetails { get; set; }
    }

    public class GetRespCodeMessageDetails : SFLAPIBaseClassOutput
    {

    }

    public class GetheaderDetails
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


    public class GetTransactionDetails
    {

        [JsonProperty("settlementStatus")]
        [DataMember]
        public string settlementStatus { get; set; }


        [JsonProperty("cardNumber")]
        [DataMember]
        public string cardNumber { get; set; }


        [JsonProperty("terminalID")]
        [DataMember]
        public string terminalID { get; set; }


        [JsonProperty("batchID")]
        [DataMember]
        public int batchID { get; set; }

        [JsonProperty("batchTransactionNumber")]
        [DataMember]
        public string batchTransactionNumber { get; set; }

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

        [JsonProperty("odometer")]
        [DataMember]
        public int odometer { get; set; }

        [JsonProperty("certificateNumber")]
        [DataMember]
        public string certificateNumber { get; set; }

        [JsonProperty("settlementDate")]
        [DataMember]
        public string settlementDate { get; set; }

        [JsonProperty("transactionDate")]
        [DataMember]
        public string transactionDate { get; set; }
    }
}
