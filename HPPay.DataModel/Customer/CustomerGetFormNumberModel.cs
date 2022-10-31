using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{

    public class GetFormNumberModelInput : BaseClass
    {

    }
    public class GetFormNumberModelOutput
    {
        [JsonProperty("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }
    }


    public class CheckFormNumberModelInput : BaseClass
    {
        [JsonPropertyName("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }
    }
    public class CheckFormNumberModelOutput :BaseClassOutput
    {
       
    }

    
}
