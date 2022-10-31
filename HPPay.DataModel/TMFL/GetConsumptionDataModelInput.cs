using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HPPay.DataModel.TMFL
{
    public  class GetConsumptionDataModelInput
    {
        [Required]
        [JsonPropertyName("ClientCode")]
        [DataMember]
        public string ClientCode { get; set; }

        [Required]
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [Required]
        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }


        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [JsonPropertyName("TMFLCustomerID")]
        [DataMember]
        public string TMFLCustomerID { get; set; }
    }

    public class consumptionRes
    {
    //    [JsonProperty("consumptionRes")]
    //    [DataMember]
    //    public string consumptionRes { get; set; }

        [JsonProperty("responseMessage")]
        [DataMember]
        public string responseMessage { get; set; }

        [JsonProperty("status")]
        [DataMember]
        public string status { get; set; }

        [JsonProperty("headerDetails")]
        public List<headerDetailsGetConsumptionDataModelOutput> headerDetails { get; set; }

        [JsonProperty("transactionsDetails")]
        public List<transactionsDetailsGetConsumptionDataModelOutPut> transactionsDetails { get; set; }
        


    }
    public class headerDetailsGetConsumptionDataModelOutput
    {
        [JsonProperty("fromDate")]
        [DataMember]
        public string fromDate { get; set; }

        [JsonProperty("toDate")]
        [DataMember]
        public string toDate { get; set; }

        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }


        [JsonProperty("NumberOfRecords")]
        [DataMember]
        public int NumberOfRecords { get; set; }

        [JsonProperty("SumOfAmount")]
        [DataMember]
        public int SumOfAmount { get; set; }

        
    }

    public class transactionsDetailsGetConsumptionDataModelOutPut
    {
        [JsonProperty("CardNumber")]
        [DataMember]
        public int CardNumber { get; set; }


        [JsonProperty("TerminalID")]
        [DataMember]
        public string TerminalID { get; set; }


        [JsonProperty("BatchID")]
        [DataMember]
        public string BatchID { get; set; }


        [JsonProperty("BatchTransactionNumber")]
        [DataMember]
        public int BatchTransactionNumber { get; set; }


        [JsonProperty("MerchantName")]
        [DataMember]
        public string MerchantName { get; set; }


        [JsonProperty("MerchantPlace")]
        [DataMember]
        public string MerchantPlace { get; set; }


        [JsonProperty("ItemConsumed")]
        [DataMember]
        public string ItemConsumed { get; set; }


        [JsonProperty("Amount")]
        [DataMember]
        public int Amount { get; set; }


        [JsonProperty("Odometer")]
        [DataMember]
        public string  Odometer { get; set; }


        [JsonProperty("CertificateNumber")]
        [DataMember]
        public string CertificateNumber { get; set; }


        [JsonProperty("SettlementDate")]
        [DataMember]
        public string SettlementDate { get; set; }


        [JsonProperty("TransactionDate")]
        [DataMember]
        public string TransactionDate { get; set; }
    }
}
