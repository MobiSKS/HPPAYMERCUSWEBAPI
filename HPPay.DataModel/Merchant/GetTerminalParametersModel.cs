using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Merchant
{
    public class GetTerminalParametersModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [Required]
        [JsonPropertyName("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }
    }

    public class GetTerminalParametersModelOutput
    {
        [JsonProperty("ObjMerchantTerminalDetails")]
        public List<MerchantTerminalDetailsModelOutput> ObjMerchantTerminalDetails { get; set; }

        [JsonProperty("ObjTerminalDefaultService")]
        public List<TerminalDefaultServiceModelOutput> ObjTerminalDefaultService { get; set; }

        [JsonProperty("ObjTerminalFastTag")]
        public List<TerminalFastTagModelOutput> ObjTerminalFastTag { get; set; }

        [JsonProperty("ObjTerminalFormFactor")]
        public List<TerminalFormFactorModelOutput> ObjTerminalFormFactor { get; set; }

        [JsonProperty("ObjMerchantConfiguration")]
        public List<MerchantConfigurationModelOutput> ObjMerchantConfiguration { get; set; }
    }

    public class MerchantTerminalDetailsModelOutput : BaseClassOutput
    {
        [JsonProperty("MerchantId")]
        public string MerchantId { get; set; }

        [JsonProperty("TerminalId")]
        public string TerminalId { get; set; }

        [JsonProperty("MerchantName")]
        public string MerchantName { get; set; }
    }

    public class TerminalDefaultServiceModelOutput
    {
        [JsonProperty("TransactionType")]
        public string TransactionType { get; set; }
    }

    public class TerminalFastTagModelOutput
    {
        [JsonProperty("FastagId")]
        public string FastagId { get; set; }

        [JsonProperty("FastagName")]
        public string FastagName { get; set; }
    }
    public class TerminalFormFactorModelOutput
    {
        [JsonProperty("FormFactorId")]
        public string FormFactorId { get; set; }

        [JsonProperty("FormFactorName")]
        public string FormFactorName { get; set; }
    }

    public class MerchantConfigurationModelOutput
    {
        [JsonProperty("Header1")]
        public string Header1 { get; set; }

        [JsonProperty("Header2")]
        public string Header2 { get; set; }

        [JsonProperty("Footer1")]
        public string Footer1 { get; set; }

        [JsonProperty("Footer2")]
        public string Footer2 { get; set; }

        [JsonProperty("BatchSaleLimit")]
        public string BatchSaleLimit { get; set; }

        [JsonProperty("BatchReloadLimit")]
        public string BatchReloadLimit { get; set; }

        [JsonProperty("BatchSize")]
        public string BatchSize { get; set; }

        [JsonProperty("SettlementTime")]
        public string SettlementTime { get; set; }

        [JsonProperty("RemoteDownload")]
        public string RemoteDownload { get; set; }

        [JsonProperty("Url")]
        public string Url { get; set; }

        [JsonProperty("BatchNo")]
        public string BatchNo { get; set; }
    }
}
