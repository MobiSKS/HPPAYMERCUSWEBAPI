using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace HPPay.DataModel.TMFL
{
    public  class LoyaltyRedeemRequestModelInput
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
        [Range(1.00, 5000000.00, ErrorMessage = "Limit value should be between 1 to 50 Lac")]
        [RegularExpression("^[0-9]{1,9}([.][0-9]{1,2})?$", ErrorMessage = "Limit Value should be upto 2 decimal places only")]
        [JsonPropertyName("DriveStars")]
        [DataMember]
        public string DriveStars { get; set; }

        [JsonPropertyName("TransactionId")]
        [DataMember]
        public string TransactionId { get; set; }

        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }
        
    }


    public class LoyaltyRedeemRequestModelOutPut : BaseClassOutput
    {
        [JsonProperty("CCMSBalance")]
        [DataMember]
        public string CCMSBalance { get; set; }

        [JsonProperty("DrivestarBalance")]
        [DataMember]
        public string DrivestarBalance { get; set; }

        [JsonProperty("ResponseMessage")]
        [DataMember]
        public string ResponseMessage { get; set; }
    }
}
