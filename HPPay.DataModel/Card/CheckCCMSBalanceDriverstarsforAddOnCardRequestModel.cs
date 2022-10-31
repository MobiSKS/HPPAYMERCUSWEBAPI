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
    public class CheckCCMSBalanceDriverstarsforAddOnCardRequestModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("Customerid")]
        [DataMember]
        public string Customerid { get; set; }

        [Required]
        [JsonPropertyName("NoOfCards")]
        [DataMember]
        public int NoOfCards { get; set; }


        [Required]
        [JsonPropertyName("PaymentMethod")]
        [DataMember]
        public int PaymentMethod { get; set; }

        
        [JsonPropertyName("CardPreference")]
        [DataMember]
        public string CardPreference { get; set; }
    }
    public class CheckCCMSBalanceDriverstarsforAddOnCardRequestModelOutput : BaseClassOutput
    {
    }
}
