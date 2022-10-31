using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    public class MerchantSaveTerminalParametersModelInput : BaseClass
    {

        [Required]
        [JsonPropertyName("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

        [Required]
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [Required]
        [JsonPropertyName("MechantName")]
        [DataMember]
        public string MechantName { get; set; }

        [JsonPropertyName("TypeTerminalDefaultServiceList")]
        [DataMember]
        public List<TypeTerminalDefaultServiceList> TypeTerminalDefaultServiceList { get; set; }


        [JsonPropertyName("TypeTerminalFastTagList")]
        [DataMember]
        public List<TypeTerminalFastTagList> TypeTerminalFastTagList { get; set; }


        [JsonPropertyName("TypeTerminalFormFactorList")]
        [DataMember]
        public List<TypeTerminalFormFactorList> TypeTerminalFormFactorList { get; set; }

        [JsonPropertyName("Header1")]
        [DataMember]
        public string Header1 { get; set; }

        [JsonPropertyName("Header2")]
        [DataMember]
        public string Header2 { get; set; }

        [JsonPropertyName("Footer1")]
        [DataMember]
        public string Footer1 { get; set; }

        [JsonPropertyName("Footer2")]
        [DataMember]
        public string Footer2 { get; set; }

        [JsonPropertyName("BatchSaleLimit")]
        [DataMember]
        public decimal BatchSaleLimit { get; set; }

        [JsonPropertyName("BatchReloadLimit")]
        [DataMember]
        public decimal BatchReloadLimit { get; set; }

        [JsonPropertyName("BatchSize")]
        [DataMember]
        public int BatchSize { get; set; }

        [JsonPropertyName("SettlementTime")]
        [DataMember]
        public int SettlementTime { get; set; }

        [JsonPropertyName("RemoteDownload")]
        [DataMember]
        public string RemoteDownload { get; set; }

        [JsonPropertyName("Url")]
        [DataMember]
        public string Url { get; set; }

        [JsonPropertyName("BatchNo")]
        [DataMember]
        public int BatchNo { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

      
    }
    public class TypeTerminalDefaultServiceList
    {
        [Required]
        [JsonPropertyName("TransactionType")]
        [DataMember]
        public string TransactionType { get; set; }

        [Required]
        [JsonPropertyName("StatusFlag")]
        [DataMember]
        public int StatusFlag { get; set; }
    }

    public class TypeTerminalFastTagList
    {
        [Required]
        [JsonPropertyName("FastagId")]
        [DataMember]
        public int FastagId { get; set; }

        [Required]
        [JsonPropertyName("FastagName")]
        [DataMember]
        public string FastagName { get; set; }

        [Required]
        [JsonPropertyName("StatusFlag")]
        [DataMember]
        public int StatusFlag { get; set; }
    }

    public class TypeTerminalFormFactorList
    {
        [Required]
        [JsonPropertyName("FormFactorId")]
        [DataMember]
        public int FormFactorId { get; set; }

        [Required]
        [JsonPropertyName("FormFactorName")]
        [DataMember]
        public string FormFactorName { get; set; }

        [Required]
        [JsonPropertyName("StatusFlag")]
        [DataMember]
        public int StatusFlag { get; set; }
    }



    public class MerchantSaveTerminalParametersModelOutput : BaseClassOutput
    {

    }
}
