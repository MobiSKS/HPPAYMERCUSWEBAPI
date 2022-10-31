using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Infinity
{
    public class InfinityRechargeApprovalPendingInput :BaseClass
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

        [JsonPropertyName("BatchCode")]
        [DataMember]
        public string BatchCode { get; set; }

        [JsonPropertyName("UTRNumber")]
        [DataMember]
        public string UTRNumber { get; set; }

        [JsonPropertyName("TransRefNumber")]
        [DataMember]
        public string TransRefNumber { get; set; }
    }
    public class InfinityRechargeApprovalPendingOutput
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [JsonPropertyName("PaymentDate")]
        [DataMember]
        public string PaymentDate { get; set; }

        [JsonPropertyName("UTRNumber")]
        [DataMember]
        public string UTRNumber { get; set; }

        [JsonPropertyName("Amount")]
        [DataMember]
        public string Amount { get; set; }


        [JsonPropertyName("IFSCCode")]
        [DataMember]
        public string IFSCCode { get; set; }

        [JsonPropertyName("BankName")]
        [DataMember]
        public string BankName { get; set; }

        [JsonPropertyName("TransRefNumber")]
        [DataMember]
        public string TransRefNumber { get; set; }

        [JsonPropertyName("SenderName ")]
        [DataMember]
        public string SenderName { get; set; }

        [JsonPropertyName("TransactionType ")]
        [DataMember]
        public string TransactionType { get; set; }

        [JsonPropertyName("ReferenceNo")]
        [DataMember]
        public string ReferenceNo { get; set; }

        [JsonPropertyName("BatchCode")]
        [DataMember]
        public string BatchCode { get; set; }
    }
}
