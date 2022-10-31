using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.RegionalOffice
{
    public class GetRegionalOfficeModelInput : BaseClass
    {
        [JsonPropertyName("ZonalID")]
        [DataMember]
        public int ZonalID { get; set; }
    }
    public class GetRegionalOfficeOnlyRetailModelInput : BaseClass
    {
        [JsonPropertyName("ZonalID")]
        [DataMember]
        public int ZonalID { get; set; }
    }

    public class GetRegionalOfficebyMultipleZoneModelInput : BaseClass
    {
        [JsonPropertyName("ZonalID")]
        [DataMember]
        public string ZonalID { get; set; }
    }
    public class GetRegionalOfficeModelOutput
    {
        [JsonProperty("ZonalID")]
        [DataMember]
        public int ZonalID { get; set; }

        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }


        [JsonProperty("RegionalOfficeID")]
        [DataMember]
        public int RegionalOfficeID { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }

        [JsonProperty("RegionalOfficeCode")]
        [DataMember]
        public string RegionalOfficeCode { get; set; }

        [JsonProperty("RegionalOfficeShortName")]
        [DataMember]
        public string RegionalOfficeShortName { get; set; }

        [JsonProperty("RegionalOfficeERPCode")]
        [DataMember]
        public string RegionalOfficeERPCode { get; set; }
    }

    public class DeleteRegionalOfficeModelInput : BaseClass
    {
        [JsonPropertyName("RegionalOfficeID")]
        [DataMember]
        public int RegionalOfficeID { get; set; }

        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }


    }

    public class DeleteRegionalOfficeModelOutput : BaseClassOutput
    {

    }

    public class GetRegionalOfficeOnlyRetailModelOutput
    {
        [JsonProperty("ZonalID")]
        [DataMember]
        public int ZonalID { get; set; }

        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }


        [JsonProperty("RegionalOfficeID")]
        [DataMember]
        public int RegionalOfficeID { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }

        [JsonProperty("RegionalOfficeCode")]
        [DataMember]
        public string RegionalOfficeCode { get; set; }

        [JsonProperty("RegionalOfficeShortName")]
        [DataMember]
        public string RegionalOfficeShortName { get; set; }

        [JsonProperty("RegionalOfficeERPCode")]
        [DataMember]
        public string RegionalOfficeERPCode { get; set; }
    }
}
