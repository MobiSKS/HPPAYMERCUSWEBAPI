using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Card
{

    public class GetGenericAttachedVehicleModelInput : BaseClass
    {
        //[Required]
        [JsonPropertyName("Customerid")]
        [DataMember]
        public string Customerid { get; set; }


        //[Required]
        [JsonPropertyName("Cardno")]
        [DataMember]
        public string Cardno { get; set; }

        //[Required]
        [JsonPropertyName("Mobileno")]
        [DataMember]
        public string Mobileno { get; set; }

        //[Required]
        [JsonPropertyName("Vehiclenumber")]
        [DataMember]
        public string Vehiclenumber { get; set; }


        //[Required]
        [JsonPropertyName("Statusflag")]
        [DataMember]
        public int Statusflag { get; set; }

    }
    public class GetGenericAttachedVehicleModelOutput:BaseClassOutput
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
