using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.ConfigureAlert
{
    public class UpdateSmsAlertForMultipleMobileDetailModelinput:BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerDetailForSmsAlert")]
        [DataMember]
        public List<SmsAlertForMultipleMobile> CustomerDetailForSmsAlert { get; set; }
    }

    public class SmsAlertForMultipleMobile
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; } 

        [Required]
        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonPropertyName("Name")]
        [DataMember]
        public string Name { get; set; }

        [JsonPropertyName("Designation")]
        [DataMember]
        public string Designation { get; set; }
    }

    public class UpdateSmsAlertForMultipleMobileDetailModelOutput:BaseClassOutput 
    {



    }
}
