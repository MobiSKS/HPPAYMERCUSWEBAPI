using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{

    public class MerchantReceivablePayableDetailModelInput : BaseClass
    {
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }


        [JsonPropertyName("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }


        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }


        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

    }

    public class MerchantReceivablePayableDetailModelOutput
    {
        [JsonProperty("SrNumber")]
        [DataMember]
        public int SrNumber { get; set; }

        [JsonProperty("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

        [JsonProperty("BatchId")]
        [DataMember]
        public Int64 BatchId { get; set; }


        [JsonProperty("SettlementDate")]
        [DataMember]
        public string SettlementDate { get; set; }


        [JsonProperty("Receivable")]
        [DataMember]
        public string Receivable { get; set; }


        [JsonProperty("Payable")]
        [DataMember]
        public string Payable { get; set; }

         

    }


}
