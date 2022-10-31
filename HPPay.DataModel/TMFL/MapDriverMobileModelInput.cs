using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HPPay.DataModel.TMFL
{
    public  class MapDriverMobileModelInput 
    {
        [Required]
        [JsonPropertyName("ClientCode")]
        [DataMember]
        public string ClientCode { get; set; }

        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [JsonPropertyName("TMFLCustomerID")]
        [DataMember]
        public string TMFLCustomerID { get; set; }

        [Required]
        [JsonPropertyName("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }

        [Required]
        [JsonPropertyName("Mobile")]
        [DataMember]
        public string Mobile { get; set; }

        [Required]
        [JsonPropertyName("ManipulationType")]
        [DataMember]
        public string ManipulationType { get; set; }


    }

    public class MapDriverMobileModelOutPut : BaseClassOutput
    {
        [JsonProperty("ClientCode")]
        [DataMember]
        public string ClientCode { get; set; }


        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }


        [JsonProperty("TMFLCustomerID")]
        [DataMember]
        public string TMFLCustomerID { get; set; }



        [JsonProperty("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }


        [JsonProperty("responseMessage")]
        [DataMember]
        public string responseMessage { get; set; }

        
    }
}
