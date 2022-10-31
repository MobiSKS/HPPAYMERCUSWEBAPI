using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.CustomerAPI
{
    public class CustomerAPISetCardAllLimitModelInput:CustomerAPIBaseClassInput

    {
        [Required]
        [JsonPropertyName("customerID")]
        [DataMember]
        public string customerID { get; set; }

        [Required]
        [RegularExpression(@"\d{16}", ErrorMessage = "Invalid cardNumber/cardNumber should be length of 16 digits. ")]
        [JsonPropertyName("cardNumber")]
        [DataMember]
        public string cardNumber { get; set; }

        [Required]
        [RegularExpression("^[0-9]{1,8}([.][0-9]{1,2})?$", ErrorMessage = "Sale Transaction Limit Value should be upto 2 decimal places only")]
        [Range(1.00, 10000000.00, ErrorMessage = "Sale Transaction Limit value should be between 1 to 1 Cr")]
        [JsonPropertyName("saleTransactionLimit")]
        [DataMember]
        public string saleTransactionLimit { get; set; }

        [Required]
        [Range(1.00, 10000000.00, ErrorMessage = "Daily Limit value should be between 1 to 1 Cr")]
        [RegularExpression("^[0-9]{1,8}([.][0-9]{1,2})?$", ErrorMessage = "Daily Limit Value should be upto 2 decimal places only")]
        [JsonPropertyName("dailyLimit")]
        [DataMember]
        public string dailyLimit { get; set; }

        [Required]
        [Range(1.00, 10000000.00, ErrorMessage = "Monthly Limit value should be between 1 to 1 Cr")]
        [RegularExpression("^[0-9]{1,8}([.][0-9]{1,2})?$", ErrorMessage = "Monthly Limit Value should be upto 2 decimal places only")]
        [JsonPropertyName("monthlyLimit")]
        [DataMember]
        public string monthlyLimit { get; set; }

   
        [JsonPropertyName("ccmslimittype")]
        [DataMember]
        public string ccmslimittype { get; set; }

        
        [Range(1.00, 5000000.00, ErrorMessage = "CCMS Limit value should be between 1 to 50 Lakhs")]
        [RegularExpression("^[0-9]{1,8}([.][0-9]{1,2})?$", ErrorMessage = "CCMS Limit Value should be upto 2 decimal places only")]
        [JsonPropertyName("CCMSlimitValue")]
        [DataMember]
        public string CCMSlimitValue { get; set; }

   
    }
    public class CustomerAPISetCardAllLimitModelOutput : CustomerAPIBaseClassOutput
    {
        [JsonProperty("cardNumber")]
        [DataMember]
        public string cardNumber { get; set; }

        [JsonProperty("saleTransactionLimit")]
        [DataMember]
        public string saleTransactionLimit { get; set; }

        [JsonProperty("dailySaleLimit")]
        [DataMember]
        public string dailySaleLimit { get; set; }

        [JsonProperty("monthlySaleLimit")]
        [DataMember]
        public string monthlySaleLimit { get; set; }

        [JsonProperty("ccmsLimitType")]
        [DataMember]
        public string ccmsLimitType { get; set; }

        [JsonProperty("ccmsLimit")]
        [DataMember]
        public string ccmsLimit { get; set; }

        
        [JsonProperty("transactionID")]
        [DataMember]
        public string transactionID { get; set; }
    }
}
