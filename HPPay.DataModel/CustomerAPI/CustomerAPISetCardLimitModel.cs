using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.CustomerAPI
{
    public class CustomerAPISetCardLimitModelInput
    {
        [Required]
        [JsonPropertyName("customerID")]
        [DataMember]
        public string customerID { get; set; }

    
        [JsonPropertyName("cardNumber")]
        [DataMember]
        public string cardNumber{ get; set; }

   
        [JsonPropertyName("mobile")]
        [DataMember]
        public string mobile { get; set; }

        [Required]
        [JsonPropertyName("limitType")]
        [DataMember]
        public string limitType { get; set; }

        [Required]
        [Range(1.00, 10000000.00, ErrorMessage = "Limit value should be between 1 to 1 Cr")]
        [RegularExpression("^[0-9]{1,8}([.][0-9]{1,2})?$", ErrorMessage = "Limit Value should be upto 2 decimal places only")]
        [JsonPropertyName("limitValue")]
        [DataMember]
        public string limitValue { get; set; }

        [Required]
        [JsonPropertyName("Username")]
        [DataMember]
        public string Username { get; set; }

        [Required]
        [JsonPropertyName("Password")]
        [DataMember]
        public string Password { get; set; }

        [Required]
        [StringLength(20)]
        [JsonPropertyName("TransactionId")]
        [DataMember]
        public string TransactionId { get; set; }

    }


    public class CustomerAPISetCardLimitModelOutput:CustomerAPIBaseClassOutput
    {

        [JsonProperty("cardNumber")]
        [DataMember]
        public string cardNumber { get; set; }

        [JsonProperty("limitType")]
        [DataMember]
        public string limitType { get; set; }

        [JsonProperty("limitValue")]
        [DataMember]
        public decimal limitValue { get; set; }

        [StringLength(20)]
        [JsonProperty("transactionId")]
        [DataMember]
        public string transactionId { get; set; }

        [JsonProperty("mobileNo")]
        [DataMember]
        public string mobileNo { get; set; }
    }
}
