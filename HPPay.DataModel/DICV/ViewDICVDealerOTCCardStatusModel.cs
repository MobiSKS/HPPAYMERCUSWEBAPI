using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.DICV
{
    public class ViewDICVDealerOTCCardStatusModelInput : BaseClass
    {

        [Required]
        [JsonPropertyName("DealerCode")]
        [DataMember]
        public string DealerCode { get; set; }

       
    }
    public class ViewDICVDealerOTCCardStatusModelOutput : BaseClassOutput
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
