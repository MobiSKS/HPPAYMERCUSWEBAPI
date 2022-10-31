using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.TMFL
{
    public  class GetCardDetailsModelInput
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }


        [Required]
        [JsonPropertyName("ClientCode")]
        [DataMember]
        public string ClientCode { get; set; }


        [Required]
        [JsonPropertyName("TMFLCustomerID")]
        [DataMember]
        public string TMFLCustomerID { get; set; }



        [Required]
        [JsonPropertyName("LimitType")]
        [DataMember]
        public string LimitType { get; set; }


        [JsonPropertyName("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }


    }
    public class GetCardDetailsModelOutPut:BaseClassOutput
    {
        [JsonProperty("CardNumber")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonProperty("VehicleNo")]
        [DataMember]
        public string VehicleNo { get; set; }


        [JsonProperty("ccmsLimit")]
        [DataMember]
        public string CCMSLimitValue { get; set; }


        [JsonProperty("typeofLimit")]
        [DataMember]
        public string typeofLimit { get; set; }


        [JsonProperty("availableCCMSLimit")]
        [DataMember]
        public string availableCCMSLimit { get; set; }


        [JsonProperty("Mobileno")]
        [DataMember]
        public string Mobileno { get; set; }


        [JsonProperty("CardBalance")]
        [DataMember]
        public string CardBalance { get; set; }

        [JsonProperty("responseMessage")]
        [DataMember]
        public string responseMessage { get; set; }


    }
}
