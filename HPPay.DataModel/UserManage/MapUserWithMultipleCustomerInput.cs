using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.UserManage
{
    public class MapUserWithMultipleCustomerInput:BaseClass
    {
        [Required]
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }


        public List<string> CustomerId { get; set; }
    }

    public class MapUserWithMultipleCustomerOutput:BaseClassOutput
    {
    }
}
