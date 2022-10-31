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
    public class HLFLCheckCustomerStatusModelInput
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
        [JsonPropertyName("ControlCardNumber")]
        [DataMember]
        public string ControlCardNumber { get; set; }


        [Required]
        [JsonPropertyName("HLFLCustomerID")]
        [DataMember]
        public string HLFLCustomerID { get; set; }


        [Required]
        [RegularExpression(@"^([FCfc]){2}([0-9]){7}$", ErrorMessage = "Invalid Facility Number.")]
        [JsonPropertyName("FacilityNumber")]
        [DataMember]
        public string FacilityNumber { get; set; }

    }

    public class HLFLCheckCustomerStatusModelOutPut
    {
        [JsonProperty("ClientCode")]
        [DataMember]
        public string ClientCode { get; set; }



        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }


        [JsonProperty("ControlCardNumber")]
        [DataMember]
        public string ControlCardNumber { get; set; }


        [JsonProperty("HLFLCustomerID")]
        [DataMember]
        public string HLFLCustomerID { get; set; }

        [JsonProperty("FacilityNumber")]
        [DataMember]
        public string FacilityNumber { get; set; }


        [JsonProperty("ResponseMessage")]
        [DataMember]
        public string ResponseMessage { get; set; }

        [JsonProperty("Status")]
        [DataMember]
        public int Status { get; set; } 


    }
}
