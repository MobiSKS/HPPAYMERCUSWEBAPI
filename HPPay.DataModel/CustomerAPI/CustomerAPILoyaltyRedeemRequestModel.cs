using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
namespace HPPay.DataModel.CustomerAPI
{
    public class CustomerAPILoyaltyRedeemRequestModelInput:CustomerAPIBaseClassInput
    {
        [Required]
        [RegularExpression(@"\d{10}", ErrorMessage = "Invalid UserName")]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [RegularExpression("^[0-9]{1,8}?$", ErrorMessage = "Please enter an integer value for Drivestars.")]
        [JsonPropertyName("DriveStars")]
        [DataMember]
        public string DriveStars { get; set; }
    }

    public class CustomerAPILoyaltyRedeemRequestModelOutput : CustomerAPIBaseClassOutput
    {
        [JsonProperty("CCMSBalance")]
        [DataMember]
        public decimal CCMSBalance { get; set; }

        [JsonProperty("DrivestarBalance")]
        [DataMember]
        public decimal DrivestarBalance { get; set; }
    }
}
