using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.SFLAPI
{
    public class SFLAPIGetHotlistReactivateReasonModelInput
    {

        [Required]
        [JsonPropertyName("flag")]
        [DataMember]
        public string flag { get; set; }
    }

    public class SFLAPIGetHotlistReactivateReasonModelOutput : SFLAPIBaseClassOutput
    {
        [JsonProperty("lstReasonInfo")]
        [DataMember]
        public List<GetlstReasonInfo> lstReasonInfo { get; set; }
    }

    public class GetRespCodeMessage : SFLAPIBaseClassOutput
    {

    }

    public class GetlstReasonInfo
    {
        [JsonProperty("id")]
        [DataMember]
        public int id { get; set; }

        [JsonProperty("name")]
        [DataMember]
        public string name { get; set; }
    }
}
