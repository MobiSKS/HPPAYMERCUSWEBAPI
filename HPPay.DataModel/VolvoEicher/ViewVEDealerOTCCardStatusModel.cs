using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.VolvoEicher
{
    public class ViewVEDealerOTCCardStatusModelInput:BaseClass
    {

       
        [JsonPropertyName("DealerCode")]
        [DataMember]
        public string DealerCode { get; set; }

        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }
    }
    public class ViewVEDealerOTCCardStatusModelOutput:BaseClassOutput
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
    }
}
