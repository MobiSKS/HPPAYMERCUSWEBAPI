using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Infinity
{
    public class InfinityRechargeDataInsertInput : BaseClass
    {
        [Required]
        [JsonPropertyName("TransactionDetailFile")]
        [DataMember]
        public IFormFile TransactionDetailFile { get; set; }
    }
    public class InfinityRechargeDataInsertOutput : BaseClassOutput
    {
        [JsonPropertyName("ControlCardNumber")]
        [DataMember]
        public string ControlCardNumber { get; set; }
    }
    public class InfinityRechargeModel
    {
        [JsonPropertyName("ControlCardNumber")]
        [DataMember]
        public Int64 ControlCardNumber { get; set; }

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

        [JsonPropertyName("TransactionReferenceNo")]
        [DataMember]
        public string TransactionReferenceNo { get; set; }
    }
}
