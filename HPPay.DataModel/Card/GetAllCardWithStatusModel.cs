using Newtonsoft.Json;
using System;
//using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Card
{
   
    public class GetAllCardWithStatusModelInput : BaseClass
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
         

    }

    public class GetAllCardWithStatusModelOutput
    {
        [JsonProperty("SrNumber")]
        [DataMember]
        public int SrNumber { get; set; }

        [JsonProperty("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }


        [JsonProperty("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }


        [JsonProperty("MobileNumber")]
        [DataMember]
        public string MobileNumber { get; set; }

        [JsonProperty("CardStatus")]
        [DataMember]
        public Int32 CardStatus { get; set; }

        [JsonProperty("Status")]
        [DataMember]
        public string Status { get; set; }



        
    }
}
