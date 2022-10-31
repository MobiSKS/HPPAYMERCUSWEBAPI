using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.AshokLeyland
{
    public class AlAddOnOTCCardModelInput : BaseClass
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
        public List<AlAddOnOTCCardDetails> ObjCardDetail { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [Required]
        [JsonPropertyName("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }
    }

    public class AlAddOnOTCCardDetails
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

    public class AlAddOnOTCCardModelOutput : BaseClassOutput
    {

    }
}
