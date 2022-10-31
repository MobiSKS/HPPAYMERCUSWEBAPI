using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Merchant
{
    public class GetStatusMobileDispenserRetailOutletMappingModelInput:BaseClass
    {
        [JsonPropertyName("Status")]
        [DataMember]
        public string Status { get; set; }
    }
    public class GetStatusMobileDispenserRetailOutletMappingModelOutPut : BaseClassOutput
    {
        [JsonProperty("MobileDispenserId")]
        [DataMember]
        public string MobileDispenserId { get; set; }

        [JsonProperty("MappedMerchantId")]
        [DataMember]
        public string MappedMerchantId { get; set; }

        [JsonProperty("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonProperty("CreatedTime")]
        [DataMember]
        public string CreatedTime { get; set; }

        //[JsonProperty("Status")]
        //[DataMember]
        //public string Status { get; set; }

        [JsonProperty("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [JsonProperty("ModifiedTime")]
        [DataMember]
        public string ModifiedTime { get; set; }

        [JsonProperty("Remarks")]
        [DataMember]
        public string Remarks { get; set; }


    }

}
