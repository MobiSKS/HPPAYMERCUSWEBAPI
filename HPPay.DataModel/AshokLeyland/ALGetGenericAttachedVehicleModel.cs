using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.AshokLeyland
{
    public class ALGetGenericAttachedVehicleModelInput : BaseClass
    {
        [JsonPropertyName("Customerid")]
        [DataMember]
        public string Customerid { get; set; }


        [JsonPropertyName("Cardno")]
        [DataMember]
        public string Cardno { get; set; }

        [JsonPropertyName("Mobileno")]
        [DataMember]
        public string Mobileno { get; set; }

        [JsonPropertyName("Vehiclenumber")]
        [DataMember]
        public string Vehiclenumber { get; set; }


        [JsonPropertyName("Statusflag")]
        [DataMember]
        public int Statusflag { get; set; }

    }
    public class ALGetGenericAttachedVehicleModelOutput : BaseClassOutput
    {
        [JsonProperty("CardNumber")]
        [DataMember]
        public string CardNo { get; set; }


        [JsonProperty("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }

        [JsonProperty("VehicleMake")]
        [DataMember]
        public string VehicleMake { get; set; }

        [JsonProperty("VehicleType")]
        [DataMember]
        public string VehicleType { get; set; }


        [JsonProperty("YearOfRegistration")]
        [DataMember]
        public Int32 YearOfRegistration { get; set; }


    }
}
