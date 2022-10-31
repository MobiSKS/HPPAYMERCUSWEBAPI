using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.Merchant
{
    public class MerchantSaleReloadDeltaDetailModelInput : BaseClass
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

    public class MerchantSaleReloadDeltaDetailModelOutput
    {
        [JsonProperty("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }


        [JsonProperty("BatchId")]
        [DataMember]
        public Int64 BatchId { get; set; }


        [JsonProperty("SettlementDate")]
        [DataMember]
        public string SettlementDate { get; set; }


        [JsonProperty("SaleDelta")]
        [DataMember]
        public decimal SaleDelta { get; set; }


        [JsonProperty("ReloadDelta")]
        [DataMember]
        public decimal ReloadDelta { get; set; }
         
    }



    public class MerchantERPReloadSaleEarningDetailModelInput : BaseClass
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

    public class MerchantERPReloadSaleEarningDetailModelOutput
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


        [JsonProperty("Sale")]
        [DataMember]
        public decimal Sale { get; set; }


        [JsonProperty("Reload")]
        [DataMember]
        public decimal Reload { get; set; }

        [JsonProperty("Earning")]
        [DataMember]
        public decimal Earning { get; set; }


        [JsonProperty("JDEStatus")]
        [DataMember]
        public string JDEStatus { get; set; }

    }
}
