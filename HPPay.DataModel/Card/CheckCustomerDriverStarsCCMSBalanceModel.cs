using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Card
{
    public class CheckCustomerDriverStarsCCMSBalanceModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("PaymentMethod")]
        [DataMember]
        public int PaymentMethod { get; set; }

        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }

    public class CheckCustomerDriverStarsCCMSBalanceModelOutput : BaseClassOutput
    {
    }
}
