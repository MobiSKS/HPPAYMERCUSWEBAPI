using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.ISurePay
{
    public class ISurePayPendingApprovalSearchInput : BaseClass
    {
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

        [JsonPropertyName("BatchCode")]
        [DataMember]
        public string BatchCode { get; set; }

        [JsonPropertyName("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [JsonPropertyName("ISureId")]
        [DataMember]
        public string ISureId { get; set; }
    }
    public class ISurePayPendingApprovalSearchOutput 
    {
        [JsonPropertyName("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("ValidateNo")]
        [DataMember]
        public string ValidateNo { get; set; }

        [JsonPropertyName("Amount")]
        [DataMember]
        public string Amount { get; set; }

        [JsonPropertyName("TransactionDate")]
        [DataMember]
        public string TransactionDate { get; set; }

        [JsonPropertyName("TransactionId")]
        [DataMember]
        public string TransactionId { get; set; }

        [JsonPropertyName("PayMode")]
        [DataMember]
        public string PayMode { get; set; }

        [JsonPropertyName("ISureId")]
        [DataMember]
        public string ISureId { get; set; }

        [JsonPropertyName("MICRCode")]
        [DataMember]
        public string MICRCode { get; set; }

        [JsonPropertyName("BankName")]
        [DataMember]
        public string Bank_Name { get; set; }

        [JsonPropertyName("BranchName")]
        [DataMember]
        public string BranchName { get; set; }

        [JsonPropertyName("InstrumentNumber")]
        [DataMember]
        public string InstrumentNumber { get; set; }

        [JsonPropertyName("RequestedBy")]
        [DataMember]
        public string RequestedBy { get; set; }

        [JsonPropertyName("RequestedOn")]
        [DataMember]
        public string RequestedOn { get; set; }

        [JsonPropertyName("BatchCode")]
        [DataMember]
        public string BatchCode { get; set; }

        [JsonPropertyName("ReferenceNo")]
        [DataMember]
        public string ReferenceNo { get; set; }
    }
}
