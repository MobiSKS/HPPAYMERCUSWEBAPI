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
    public  class UpdateCardLimitModelInput
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
        [JsonPropertyName("LimitType")]
        [DataMember]
        public string LimitType { get; set; }

        [Required]
        [Range(1.00, 5000000.00, ErrorMessage = "Limit value should be between 1 to 50 Lac")]
        [RegularExpression("^[0-9]{1,9}([.][0-9]{1,2})?$", ErrorMessage = "Limit Value should be upto 2 decimal places only")]
        [JsonPropertyName("LimitValue")]
        [DataMember]
        public string LimitValue { get; set; }
    }


    public class UpdateCardLimitModelOutPut:BaseClassOutput
    {
        //    [JsonProperty("ClientCode")]
        //    [DataMember]
        //    public string ClientCode { get; set; }



        //    [JsonProperty("CustomerID")]
        //    [DataMember]
        //    public string CustomerID { get; set; }

        [JsonProperty("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }


        [JsonProperty("LimitType")]
        [DataMember]
        public string ccmslimittype { get; set; }



        [JsonProperty("LimitValue")]
        [DataMember]
        public decimal ccmsLimit { get; set; }


        [JsonProperty("responseMessage")]
        [DataMember]
        public string responseMessage { get; set; }

        

    }
}
