using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.CustomerAPI
{
    public class CustomerAPIGetCardLimitModelInput: CustomerAPIBaseClassInput
    {
        [Required]
        [JsonPropertyName("customerID")]
        [DataMember]
        public string customerID { get; set; }

        
        [JsonPropertyName("cardNumber")]
        [DataMember]
        public string cardNumber { get; set; }


        [JsonPropertyName("limitType")]
        [DataMember]
        public string limitType { get; set; }
    }

    public class CustomerAPIGetCardLimitModelOutput:CustomerAPIBaseClassOutput
    {
        [JsonProperty("cardNumber")]
        [DataMember]
        public string cardNumber { get; set; }

        [JsonProperty("vehicleNo")]
        [DataMember]
        public string vehicleNo { get; set; }


        [JsonProperty("dailySaleLimit")]
        [DataMember]
        public decimal dailySaleLimit { get; set; }


        [JsonProperty("dailySaleBalance")]
        [DataMember]
        public decimal dailySaleBalance { get; set; }

        [JsonProperty("monthlySaleLimit")]
        [DataMember]
        public decimal monthlySaleLimit { get; set; }

        [JsonProperty("monthlySaleBalance")]
        [DataMember]
        public decimal monthlySaleBalance { get; set; }


        [JsonProperty("ccmsLimit")]
        [DataMember]
        public decimal ccmsLimit { get; set; }


        [JsonProperty("typeofLimit")]
        [DataMember]
        public string typeofLimit { get; set; }

        [JsonProperty("availableCCMSLimit")]
        [DataMember]
        public decimal availableCCMSLimit { get; set; }
    }
}
