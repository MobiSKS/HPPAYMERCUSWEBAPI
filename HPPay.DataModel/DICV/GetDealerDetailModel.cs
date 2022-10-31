using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.DICV
{
    

    public class GetDealerDetailModelInput : BaseClass
    {
        [JsonPropertyName("OfficerType")]
        [DataMember]
        public int OfficerType { get; set; }

        [JsonPropertyName("DealerCode")]
        [DataMember]
        public string DealerCode { get; set; }

        [JsonPropertyName("DTPDealerCode")]
        [DataMember]
        public string DTPDealerCode { get; set; }
    }

    public class GetDealerDetailModelOutput
    {

        [JsonProperty("DealerCode")]
        [DataMember]
        public string DealerCode { get; set; }

        [JsonProperty("DealerName")]
        [DataMember]
        public string DealerName { get; set; }

        [JsonProperty("ZonalOfficeID")]
        [DataMember]
        public int ZonalOfficeID { get; set; }

        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }

        [JsonProperty("RegionalOfficeID")]
        [DataMember]
        public int RegionalOfficeID { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }

        [JsonProperty("Address1")]
        [DataMember]
        public string Address1 { get; set; }

        [JsonProperty("Address2")]
        [DataMember]
        public string Address2 { get; set; }

        [JsonProperty("Address3")]
        [DataMember]
        public string Address3 { get; set; }

        [JsonProperty("CityName")]
        [DataMember]
        public string CityName { get; set; }

        [JsonProperty("StateId")]
        [DataMember]
        public int StateId { get; set; }

        [JsonProperty("StateName")]
        [DataMember]
        public string StateName { get; set; }

        [JsonProperty("DistrictId")]
        [DataMember]
        public int DistrictId { get; set; }

        [JsonProperty("DistrictName")]
        [DataMember]
        public string DistrictName { get; set; }

        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonProperty("Pin")]
        [DataMember]
        public string Pin { get; set; }


        [JsonProperty("EmailId")]
        [DataMember]
        public string EmailId { get; set; }

        [JsonProperty("SBUId")]
        [DataMember]
        public int SBUId { get; set; }

        [JsonProperty("SBUName")]
        [DataMember]
        public string SBUName { get; set; }

        [JsonPropertyName("OfficerType")]
        [DataMember]
        public int OfficerType { get; set; }

        [JsonProperty("UserName")]
        [DataMember]
        public string UserName { get; set; }

        [JsonProperty("DealerStatus")]
        [DataMember]
        public string DealerStatus { get; set; }

        [JsonProperty("OEMRegionalOffice")]
        [DataMember]
        public string OEMRegionalOffice { get; set; }
    }

    public class CheckDealerCodeModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("DealerCode")]
        [DataMember]
        public string DealerCode { get; set; }


    }

    public class CheckDealerCodeModelOutput : BaseClassOutput
    {

    }

    public class EnableDisableDICVDealerModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("DealerCode")]
        [DataMember]
        public string DealerCode { get; set; }

        [JsonPropertyName("OfficerType")]
        [DataMember]
        public int OfficerType { get; set; }

        [JsonPropertyName("IsDisable")]
        [DataMember]
        public bool IsDisable { get; set; }

    }

    public class EnableDisableDICVDealerModelOutput : BaseClassOutput
    {
    }
}
