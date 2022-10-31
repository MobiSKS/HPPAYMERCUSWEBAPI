using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace HPPay.DataModel.HLFL
{
    public class HLFLCardLimitModelInput
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
        [JsonPropertyName("LimitType")]
        [DataMember]
        public string LimitType { get; set; }

        [Required]
        [Range(1.00, 5000000.00, ErrorMessage = "Limit value should be between 1 to 50 Lac")]
        [RegularExpression("^[0-9]{1,8}([.][0-9]{1,2})?$", ErrorMessage = "Limit Value should be upto 2 decimal places only")]
        [JsonPropertyName("LimitValue")]
        [DataMember]
        public string LimitValue { get; set; }
    

    }

    public class HLFLCardLimitModelOutPut
    {
        
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

        [JsonProperty("Status")]
        [DataMember]
        public int Status { get; set; }
    }
}
