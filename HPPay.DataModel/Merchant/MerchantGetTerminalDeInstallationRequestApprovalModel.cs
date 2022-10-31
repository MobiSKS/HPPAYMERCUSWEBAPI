using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
namespace HPPay.DataModel.Merchant
{
   

    public class MerchantGetTerminalDeInstallationRequestApprovalModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [Required]
        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }


        [JsonPropertyName("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }


        [JsonPropertyName("ZonalOfficeId")]
        [DataMember]
        public string ZonalOfficeId { get; set; }

        [JsonPropertyName("RegionalOfficeId")]
        [DataMember]
        public string RegionalOfficeId { get; set; }

        [JsonPropertyName("SBUTypeId")]
        [DataMember]
        public int SBUTypeId { get; set; }
    }

    public class MerchantGetTerminalDeInstallationRequestApprovalModelOutput
    {

        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }


        [JsonProperty("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }


        [JsonProperty("TerminalType")]
        [DataMember]
        public string TerminalType { get; set; }



        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }

        [JsonProperty("SpendsOfLastQuater")]
        [DataMember]
        public decimal SpendsOfLastQuater { get; set; }


        [JsonProperty("NoOfTransactionsOfLastQuater")]
        [DataMember]
        public Int32 NoOfTransactionsOfLastQuater { get; set; }



        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }
       

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }


        [JsonProperty("ApprovalRemark")]
        [DataMember]
        public string ApprovalRemark { get; set; }



        [JsonProperty("RequestedBy")]
        [DataMember]
        public string RequestedBy { get; set; }

        [JsonProperty("RequestedDate")]
        [DataMember]
        public string RequestedDate { get; set; }


        [JsonProperty("SBUTypeId")]
        [DataMember]
        public int SBUTypeId { get; set; }

        [JsonProperty("SBUName")]
        [DataMember]
        public string SBUName { get; set; }


    }
}
