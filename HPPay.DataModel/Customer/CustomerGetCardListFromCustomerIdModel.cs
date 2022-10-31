using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{
    public class CustomerGetCardListFromCustomerIdModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }

    public class CustomerGetCardListFromCustomerIdModelOutput  
    {
        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }
    }
}
