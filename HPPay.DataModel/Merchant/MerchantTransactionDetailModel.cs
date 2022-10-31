using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    public class MerchantTransactionDetailModelInput : BaseClass
    {
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }


        [JsonPropertyName("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }


        [JsonPropertyName("TransactionType")]
        [DataMember]
        public string TransactionType { get; set; }

        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }


        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

    }

    public class MerchantTransactionDetailModelOutput
    {
        [JsonProperty("BatchId")]
        [DataMember]
        public Int64 BatchId { get; set; }

        [JsonProperty("InvoiceNo")]
        [DataMember]
        public int InvoiceNo { get; set; }


        [JsonProperty("ToDate")]
        [DataMember]
        public string ToDate { get; set; }


        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }


        [JsonProperty("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }


        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }

        [JsonProperty("TransactionDate")]
        [DataMember]
        public string TransactionDate { get; set; }


        [JsonProperty("TransactionType")]
        [DataMember]
        public string TransactionType { get; set; }


        [JsonProperty("Product")]
        [DataMember]
        public string Product { get; set; }


        [JsonProperty("Price")]
        [DataMember]
        public string Price { get; set; }


        [JsonProperty("Volume")]
        [DataMember]
        public string Volume { get; set; }

        [JsonProperty("Currency")]
        [DataMember]
        public string Currency { get; set; }

        [JsonProperty("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

        [JsonProperty("ServiceCharge")]
        [DataMember]
        public string ServiceCharge { get; set; }


        [JsonProperty("DriveStars")]
        [DataMember]
        public string DriveStars { get; set; }


        [JsonProperty("VoidedByRoc")]
        [DataMember]
        public string VoidedByRoc { get; set; }

        [JsonProperty("VoidedRoc")]
        [DataMember]
        public string VoidedRoc { get; set; }

        [JsonProperty("FSMName")]
        [DataMember]
        public string FSMName { get; set; }

        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }


        [JsonProperty("Status")]
        [DataMember]
        public string Status { get; set; }

    }
}
