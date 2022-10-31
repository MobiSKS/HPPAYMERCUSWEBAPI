
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.JCB
{
    public class ViewJCBDealerOTCCardStatusModelInput : BaseClass
    {

        [Required]
        [JsonPropertyName("DealerCode")]
        [DataMember]
        public string DealerCode { get; set; }

        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }
    }
    public class ViewJCBDealerOTCCardStatusModelOutput : BaseClassOutput
    {
        [JsonProperty("TotalAllocatedCards")]
        [DataMember]
        public int TotalAllocatedCards { get; set; }

        [JsonProperty("TotalMappedCards")]
        [DataMember]
        public int TotalMappedCards { get; set; }


        [JsonProperty("TotalUnmappedCards")]
        [DataMember]
        public int TotalUnmappedCards { get; set; }

        [JsonProperty("DealerCode")]
        [DataMember]
        public string DealerCode { get; set; }

        [JsonProperty("DealerName")]
        [DataMember]
        public string DealerName { get; set; }

        [JsonProperty("RequestID")]
        [DataMember]
        public string RequestID { get; set; }

        [JsonProperty("NoofCards")]
        [DataMember]
        public int NoofCards { get; set; }

        [JsonProperty("RequestedDate")]
        [DataMember]
        public string RequestedDate { get; set; }
    }
}
