using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.HDFCCreditPouch
{
    public class HdfcTransactionStatusModelInput : BaseClass
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

    }

    public class HdfcTransactionStatusModelOutPut
    {
        [JsonProperty("ZO")]
        [DataMember]
        public string ZO { get; set; }

        [JsonProperty("RO")]
        [DataMember]
        public string RO { get; set; }

        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }

        [JsonProperty("TrackID")]
        [DataMember]
        public string TrackID { get; set; }

        [JsonProperty("PaymentID")]
        [DataMember]
        public string PaymentID { get; set; }


        [JsonProperty("TransactionId")]
        [DataMember]
        public string TransactionId { get; set; }

        [JsonProperty("PlanName")]
        [DataMember]
        public string PlanName { get; set; }

        [JsonProperty("RequestAmount")]
        [DataMember]
        public string RequestAmount { get; set; }

        [JsonProperty("TransactionDate")]
        [DataMember]
        public string TransactionDate { get; set; }

        [JsonProperty("TransactionStatus")]
        [DataMember]
        public string TransactionStatus { get; set; }

        [JsonProperty("OperationType")]
        [DataMember]
        public string OperationType { get; set; }
        
    }

    public class HdfcTransactionStatusReportModelInput
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        

        [JsonPropertyName("OrderId")]
        [DataMember]
        public string OrderId { get; set; }

    }
}

