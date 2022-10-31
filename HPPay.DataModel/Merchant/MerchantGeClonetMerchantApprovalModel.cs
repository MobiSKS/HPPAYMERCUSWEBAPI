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
    public class MerchantGeClonetMerchantApprovalModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("Category")]
        [DataMember]
        public string Category { get; set; }

        [Required]
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }


        [Required]
        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

    }

    public class MerchantGeClonetMerchantApprovalModelOutput : BaseClassOutput
    {
        [JsonProperty("ErpCode")]
        [DataMember]
        public string ErpCode { get; set; }


        [JsonProperty("OldMerchantId")]
        [DataMember]
        public string OldMerchantId { get; set; }

        [JsonProperty("RegionalOfficeId")]
        [DataMember]
        public string RegionalOfficeId { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }

        [JsonProperty("ZonalOfficeId")]
        [DataMember]
        public string ZonalOfficeId { get; set; }

        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }

        [JsonProperty("RetailOutletCity")]
        [DataMember]
        public string RetailOutletCity { get; set; }


        [JsonProperty("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonProperty("CreatedTime")]
        [DataMember]
        public string CreatedTime { get; set; }

        [JsonProperty("VerifiedDate")]
        [DataMember]
        public string VerifiedDate { get; set; }

        [JsonProperty("VerifiedBy")]
        [DataMember]
        public string VerifiedBy { get; set; }


        [JsonProperty("Comments")]
        [DataMember]
        public string Comments { get; set; }

        [JsonProperty("MerchantTypeId")]
        [DataMember]
        public string MerchantTypeId { get; set; }

        [JsonProperty("MerchantTypeName")]
        [DataMember]
        public string MerchantTypeName { get; set; }

        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }

    }
}
