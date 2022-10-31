using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    public class MerchantSearchForTerminalInstallationRequestModelInput : BaseClass
    {
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonPropertyName("ZonalOfficeId")]
        [DataMember]
        public string ZonalOfficeId { get; set; }

        [JsonPropertyName("RegionalOfficeId")]
        [DataMember]
        public string RegionalOfficeId { get; set; }

        [JsonPropertyName("SBUTypeId")]
        [DataMember]
        public string SBUTypeId { get; set; }
    }

    public class MerchantSearchForTerminalInstallationRequestModelOutput
    {
        [JsonProperty("ObjMerchantDetail")]
        public List<MerchantDetailOutput> ObjMerchantDetail { get; set; }

        [JsonProperty("ObjTerminalDetail")]
        public List<TerminalDetailOutput> ObjTerminalDetail { get; set; }

        [JsonProperty("ObjStatusDetail")]
        public List<StatusOutput> ObjStatusDetail { get; set; }
    }

    public class StatusOutput : BaseClassOutput
    {

    }

    public class MerchantDetailOutput
    {

        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }

        [JsonProperty("ZonalOfficeId")]
        [DataMember]
        public Int32 ZonalOfficeId { get; set; }

        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }


        [JsonProperty("RegionalOfficeId")]
        [DataMember]
        public Int32 RegionalOfficeId { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }


        [JsonProperty("SalesAreaId")]
        [DataMember]
        public Int32 SalesAreaId { get; set; }


        [JsonProperty("SalesAreaName")]
        [DataMember]
        public string SalesAreaName { get; set; }


        [JsonProperty("RetailOutletAddress")]
        [DataMember]
        public string RetailOutletAddress { get; set; }

        [JsonProperty("RetailOutletCity")]
        [DataMember]
        public string RetailOutletCity { get; set; }


        [JsonProperty("RetailOutletStateId")]
        [DataMember]
        public Int32 RetailOutletStateId { get; set; }


        [JsonProperty("StateName")]
        [DataMember]
        public string StateName { get; set; }


        [JsonProperty("RetailOutletDistrictId")]
        [DataMember]
        public Int32 RetailOutletDistrictId { get; set; }


        [JsonProperty("DistrictName")]
        [DataMember]
        public string DistrictName { get; set; }

        [JsonProperty("TerminalIssuanceType")]
        [DataMember]
        public string TerminalIssuanceType { get; set; }

        [JsonProperty("SBUTypeId")]
        [DataMember]
        public int SBUTypeId { get; set; }

        [JsonProperty("SBUName")]
        [DataMember]
        public string SBUName { get; set; }
    }
    public class TerminalDetailOutput
    {
        [JsonProperty("SrNumber")]
        [DataMember]
        public string SrNumber { get; set; }

        [JsonProperty("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

        [JsonProperty("LastMonthSpends")]
        [DataMember]
        public decimal LastMonthSpends { get; set; }

        [JsonProperty("Status")]
        [DataMember]
        public string Status { get; set; }
    }
}
