using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HPPay.DataModel.HLFL
{
    public  class HLFLMapDriverMobileModelInput 
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
        [JsonPropertyName("HLFLCustomerID")]
        [DataMember]
        public string HLFLCustomerID { get; set; }

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



    public class HLFLMapDriverMobileModelOutPut
    {
        [JsonProperty("ClientCode")]
        [DataMember]
        public string ClientCode { get; set; }


        [JsonProperty("CustomerID")]
        [DataMember]
        public string customerID { get; set; }


        [JsonProperty("HLFLCustomerID")]
        [DataMember]
        public string HLFLCustomerID { get; set; }



        [JsonProperty("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }

   
        [JsonProperty("responseMessage")]
        [DataMember]
        public string responseMessage { get; set; }

        [JsonProperty("Status")]
        [DataMember]
        public int Status { get; set; } 
    }
}
