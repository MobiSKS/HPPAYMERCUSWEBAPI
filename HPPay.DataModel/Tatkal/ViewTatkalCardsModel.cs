using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Tatkal
{
    public class ViewTatkalCardsModelInput : BaseClass
    {
        [JsonPropertyName("ZonalOfficeID")]
        [DataMember]
        public string ZonalOfficeID { get; set; }

        [JsonPropertyName("RegionalOfficeID")]
        [DataMember]
        public string RegionalOfficeID { get; set; }

        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

        [JsonPropertyName("StatusId")]
        [DataMember]
        public string StatusId { get; set; }

        [JsonPropertyName("SBUTypeId")]
        [DataMember]
        public int SBUTypeId { get; set; }
    }

    public class ViewTatkalCardsModelOutput
    {
        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }

        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonProperty("RequestedBy")]
        [DataMember]
        public string RequestedBy { get; set; }

        [JsonProperty("CardProcessDate")]
        [DataMember]
        public string CardProcessDate { get; set; }

        [JsonProperty("MappingStatus")]
        [DataMember]
        public string MappingStatus { get; set; }

        [JsonProperty("SBUName")]
        [DataMember]
        public string SBUName { get; set; }

        [JsonProperty("SBUTypeId")]
        [DataMember]
        public int SBUTypeId { get; set; }
    }
}
