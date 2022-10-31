using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{
    public class CustomerPostAuthorizationForCreditPouchModelInput: BaseClass
    {
        [Required]
        [JsonPropertyName("ObjCustomerDetail")]
        [DataMember]
        public List<CustomerIdForPostAuthorization> ObjCustomerDetail { get; set; }

        [Required]
        [JsonPropertyName("CreditPouchType")]
        [DataMember]
        public string CreditPouchType { get; set; }
    }
    public class CustomerIdForPostAuthorization
    {
        [JsonPropertyName("CustomerID")]
        public string CustomerID { get; set; }
    }

    public class CustomerPostAuthorizationForCreditPouchModelOutput : BaseClassOutput
    {

    }
}
