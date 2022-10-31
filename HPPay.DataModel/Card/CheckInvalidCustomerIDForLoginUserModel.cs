using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Card
{
    public class CheckInvalidCustomerIDForLoginUserModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
    }
    public class CheckInvalidCustomerIDForLoginUserModelOutput : BaseClassOutput
    {

    }
}
