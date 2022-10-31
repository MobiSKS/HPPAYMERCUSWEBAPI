using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.STFCAPI
{
    public class STFCGetHotlistReactivateReasonModelInput
    {
        [Required]
        [JsonPropertyName("flag")]
        [DataMember]
        public string flag { get; set; }
    }

    public class STFCGetHotlistReactivateReasonModelOutput 

    {

        //[JsonProperty("responseCode")]
        //[DataMember]
        //public string responseCode { get; set; }

        //[JsonProperty("responseMessage")]
        //[DataMember]
        //public string responseMessage { get; set; }

        [JsonProperty("lstResponse")]
        [DataMember]
        public List<GetResponse> lstResponse { get; set; }

        [JsonProperty("lstReasonInfo")]
        [DataMember]
        public List<ReasonInfo> lstReasonInfo { get; set; }
    }

    public class GetResponse
    {
        [JsonProperty("responseCode")]
        [DataMember]
        public string responseCode { get; set; }

        [JsonProperty("responseMessage")]
        [DataMember]
        public string responseMessage { get; set; }
    }
    public class ReasonInfo
    {
        [JsonProperty("id")]
        [DataMember]
        public int id { get; set; }

        [JsonProperty("name")]
        [DataMember]
        public string name { get; set; }
    }
}
