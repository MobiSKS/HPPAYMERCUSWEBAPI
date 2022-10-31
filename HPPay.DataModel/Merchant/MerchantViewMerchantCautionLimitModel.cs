using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    public class MerchantViewMerchantCautionLimitModelInput : BaseClass
    {
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonPropertyName("MerchantStatus")]
        [DataMember]
        public string MerchantStatus { get; set; }

        [Required]
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [Required]
        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

        [JsonPropertyName("RegionalOffice")]
        [DataMember]
        public string RegionalOffice { get; set; }

        [JsonPropertyName("SalesArea")]
        [DataMember]
        public string SalesArea { get; set; }
    }

    public class MerchantViewMerchantCautionLimitModelOutput
    {
        [JsonProperty("SrNumber")]
        [DataMember]
        public int SrNumber { get; set; }

        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonProperty("ErpCode")]
        [DataMember]
        public string ErpCode { get; set; }

        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }

        [JsonProperty("SalesArea")]
        [DataMember]
        public string SalesArea { get; set; }

        [JsonProperty("RetailOutletCity")]
        [DataMember]
        public string RetailOutletCity { get; set; }

        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; }

        [JsonProperty("AvgHsdSale")]
        [DataMember]
        public decimal AvgHsdSale { get; set; }

        [JsonProperty("HsdRspValue")]
        [DataMember]
        public decimal HsdRspValue { get; set; }

        [JsonProperty("DtplusCautionLimit")]
        [DataMember]
        public decimal DtplusCautionLimit { get; set; }

        [JsonProperty("AvgMsSale")]
        [DataMember]
        public decimal AvgMsSale { get; set; }

        [JsonProperty("MsRspValue")]
        [DataMember]
        public decimal MsRspValue { get; set; }

        [JsonProperty("HpPayCautionLimit")]
        [DataMember]
        public decimal HpPayCautionLimit { get; set; }

        [JsonProperty("LastUpdatedOn")]
        [DataMember]
        public string LastUpdatedOn { get; set; }

    }
}
