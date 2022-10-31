using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Customer
{
    public class CustomerPostAuthForCreditPouchParentCustomerModelInput : BaseClass
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

    public class CustomerPostAuthForCreditPouchParentCustomerModelOutput : BaseClassOutput
    {

    }
}
