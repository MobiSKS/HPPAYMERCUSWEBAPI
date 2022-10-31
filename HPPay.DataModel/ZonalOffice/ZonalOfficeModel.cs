using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.ZonalOffice
{
    public class GetZonalOfficeModelInput : BaseClass
    {
        [JsonPropertyName("SBUTypeId")]
        [DataMember]
        public int SBUTypeId { get; set; }
    }
    public class GetZonalOfficeModelOutput
    {
        [JsonProperty("HQID")]
        [DataMember]
        public int HQID { get; set; }
        
        [JsonProperty("ZoneID")]
        [DataMember]
        public int ZoneID { get; set; }

        [JsonProperty("ZonalOfficeID")]
        [DataMember]
        public int ZonalOfficeID { get; set; }


        [JsonProperty("ZonalOfficeCode")]
        [DataMember]
        public string ZonalOfficeCode { get; set; }


        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }


        [JsonProperty("ZonalOfficeShortName")]
        [DataMember]
        public string ZonalOfficeShortName { get; set; }


        [JsonProperty("ZonalOfficeERPCode")]
        [DataMember]
        public string ZonalOfficeERPCode { get; set; }

        
    }

    public class DeleteZonalOfficeModelInput : BaseClass
    {
        [JsonPropertyName("ZonalOfficeID")]
        [DataMember]
        public int ZonalOfficeID { get; set; }

        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }


    }

    public class DeleteZonalOfficeModelOutput : BaseClassOutput
    {

    }
}
