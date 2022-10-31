using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.CustomerAPI
{
    public class CustomerAPIGetCustomerBalanceModelInput: CustomerAPIBaseClassInput
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }
    public class CustomerAPIGetCustomerBalanceModelOutput : CustomerAPIBaseClassOutput
    {

       
        [JsonProperty("cashBalance")]
        [DataMember]
        public decimal cashBalance { get; set; }


        [JsonProperty("ccmsBalance")]
        [DataMember]
        public decimal ccmsBalance { get; set; }

        [RegularExpression("^[0-9]{1,8}?$", ErrorMessage = "Please enter an integer value for drivestar.")]
        [JsonProperty("drivestars")]
        [DataMember]
        public int drivestars { get; set; }

        [RegularExpression("^[0-9]{1,8}?$", ErrorMessage = "Please enter an integer value for  expired drivestar.")]
        [JsonProperty("expiredDrivestars")]
        [DataMember]
        public int expiredDrivestars { get; set; }

        [RegularExpression("^[0-9]{1,8}?$", ErrorMessage = "Please enter an integer value for expiring drivestar.")]
        [JsonProperty("expiringDrivestars")]
        [DataMember]
        public int expiringDrivestars { get; set; }


        [JsonProperty("dailyCashLimit")]
        [DataMember]
        public decimal dailyCashLimit { get; set; }


        [JsonProperty("dailyCashLimitBalance")]
        [DataMember]
        public decimal dailyCashLimitBalance { get; set; }


        [JsonProperty("nonAllocatedCCMSBalance")]
        [DataMember]
        public decimal nonAllocatedCCMSBalance { get; set; }

    }
}
