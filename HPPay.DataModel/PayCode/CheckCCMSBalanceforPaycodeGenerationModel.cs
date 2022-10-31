using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.PayCode
{
    public class CheckCCMSBalanceforPaycodeGenerationModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("Customerid")]
        [DataMember]
        public string Customerid { get; set; }
       
        [Required]
        [JsonPropertyName("NoOfPaycode")]
        [DataMember]
        public int NoOfPaycode { get; set; }


        [Required]
        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

    }

    public class CheckCCMSBalanceforPaycodeGenerationModelOutput : BaseClassOutput
    {

    }
}
