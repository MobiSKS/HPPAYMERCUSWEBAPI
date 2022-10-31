using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.JCB
{
    public class JCBAddOnOTCCardModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [Required]
        [JsonPropertyName("NoOfCards")]
        [DataMember]
        public Int32 NoOfCards { get; set; }

        [JsonPropertyName("ObjCardDetail")]
        [DataMember]
        public List<JCBAddOnOTCCardDetails> ObjCardDetail { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }
    }

    public class JCBAddOnOTCCardDetails
    {
        [JsonPropertyName("CardNo")]
        public string CardNo { get; set; }

        [JsonPropertyName("VechileNo")]
        public string VechileNo { get; set; }

        [JsonPropertyName("VehicleType")]
        public string VehicleType { get; set; }

        [JsonPropertyName("VINNumber")]
        public string VINNumber { get; set; }

        [JsonPropertyName("MobileNo")]
        public string MobileNo { get; set; }
    }

    public class JCBAddOnOTCCardModelOutput : BaseClassOutput
    {

    }
}
