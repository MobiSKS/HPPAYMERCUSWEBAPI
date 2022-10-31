using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.CustomerAPI
{
    public class CustomerAPICheckLoyaltyRedeemStatusModelInput 
    {
        [Required]
        [RegularExpression(@"\d{10}", ErrorMessage = "Invalid UserName")]
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }


        [Required]
        [JsonPropertyName("Password")]
        [DataMember]
        public string Password { get; set; }


        [Required]
        [JsonPropertyName("TransactionId")]
        [DataMember]
        public string TransactionId { get; set; }
    }

    public class CustomerAPICheckLoyaltyRedeemStatusModelOutput : CustomerAPIBaseClassOutput
    {
        [JsonProperty("PointsRedeemed")]
        [DataMember]
        public decimal PointsRedeemed { get; set; }

        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

    }
}
