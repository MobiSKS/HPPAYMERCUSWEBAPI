using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.AshokLeyland
{

    public class InsertDealerWiseALOTCCardRequestModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("DealerCode")]
        [DataMember]
        public string DealerCode { get; set; }

        [Required]
        [JsonPropertyName("NoofCards")]
        [DataMember]
        public Int32 NoofCards { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }
    }
    public class InsertDealerWiseALOTCCardRequestModelOutput : BaseClassOutput
    {

    }
}
