using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.Merchant
{
    public class MerchantSettlementDetailsModelInput : BaseClass
    {
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonPropertyName("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

        [Required]
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [Required]
        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }
        
    }

    public class MerchantSettlementDetailsModelOutput
    {
        [JsonProperty("BatchId")]
        [DataMember]
        public Int64 BatchId { get; set; }

        [JsonProperty("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

        [JsonProperty("Status")]
        [DataMember]
        public string Status { get; set; }

        [JsonProperty("NoofTransactions")]
        [DataMember]
        public string NoofTransactions { get; set; }

        [JsonProperty("SettlementDate")]
        [DataMember]
        public string SettlementDate { get; set; }

    }


    public class MerchantBatchDetailModelInput : BaseClass
    {
        
        [JsonPropertyName("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

        [JsonPropertyName("BatchId")]
        [DataMember]
        public Int64 BatchId { get; set; }


        //[Required]
        //[JsonPropertyName("FromDate")]
        //[DataMember]
        //public string FromDate { get; set; }

        //[Required]
        //[JsonPropertyName("ToDate")]
        //[DataMember]
        //public string ToDate { get; set; }

    }

    public class MerchantBatchDetailModelOutput
    {
        [JsonProperty("InvoiceNo")]
        [DataMember]
        public int InvoiceNo { get; set; }

        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonProperty("TransactionDate")]
        [DataMember]
        public string TransactionDate { get; set; }

        [JsonProperty("TransactionType")]
        [DataMember]
        public string TransactionType { get; set; }

        [JsonProperty("InvoiceAmount")]
        [DataMember]
        public decimal InvoiceAmount { get; set; }

        [JsonProperty("ProductName")]
        [DataMember]
        public string ProductName { get; set; }

        [JsonProperty("FuelPrice")]
        [DataMember]
        public decimal FuelPrice { get; set; }

        [JsonProperty("ServiceCharge")]
        [DataMember]
        public decimal ServiceCharge { get; set; }

        [JsonProperty("CcmsCashBalance")]
        [DataMember]
        public decimal CcmsCashBalance { get; set; }

        [JsonProperty("VoidedRoc")]
        [DataMember]
        public string VoidedRoc { get; set; }

        [JsonProperty("VoidedByRoc")]
        [DataMember]
        public string VoidedByRoc { get; set; }

        [JsonProperty("Volume")]
        [DataMember]
        public string Volume { get; set; }

    }
}
