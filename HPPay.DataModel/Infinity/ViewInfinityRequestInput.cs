using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
namespace HPPay.DataModel.Infinity
{
    
    public class ViewInfinityRequestInput : BaseClass
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("Status")]
        [DataMember]
        public string Status { get; set; }

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

        [JsonPropertyName("Amount")]
        [DataMember]
        public string Amount { get; set; }
    }

    public class ViewInfinityRequestOutput
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [JsonPropertyName("UTRNumber")]
        [DataMember]
        public string UTRNumber { get; set; }

        [JsonPropertyName("TxnDate")]
        [DataMember]
        public string TxnDate { get; set; }

        [JsonPropertyName("Amount")]
        [DataMember]
        public string Amount { get; set; }


        [JsonPropertyName("TransRefNumber")]
        [DataMember]
        public string TransRefNumber { get; set; }

        [JsonPropertyName("BatchId ")]
        [DataMember]
        public string BatchId { get; set; }

        [JsonPropertyName("RequestedBy ")]
        [DataMember]
        public string RequestedBy { get; set; }

        [JsonPropertyName("RequestedOn")]
        [DataMember]
        public string RequestedOn { get; set; }

        [JsonPropertyName("ApprovedOn")]
        [DataMember]
        public string ApprovedOn { get; set; }

        [JsonPropertyName("ApprovalStatus")]
        [DataMember]
        public string ApprovalStatus { get; set; }

        [JsonPropertyName("Type")]
        [DataMember]
        public string Type { get; set; }

    }
}
