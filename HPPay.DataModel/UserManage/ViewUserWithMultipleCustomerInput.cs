using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.UserManage
{
    public class ViewUserWithMultipleCustomerInput: BaseClass
    {
        [Required]
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }
    }

    public class ViewUserWithMultipleCustomerOutput 
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [Required]
        [JsonPropertyName("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }

        [Required]
        [JsonPropertyName("CustomereName")]
        [DataMember]
        public string CustomereName { get; set; }

        [Required]
        [JsonPropertyName("ZonalOffice")]
        [DataMember]
        public string ZonalOffice { get; set; }

        [Required]
        [JsonPropertyName("RegionalOffice")]
        [DataMember]
        public string RegionalOffice { get; set; }
    }
}
