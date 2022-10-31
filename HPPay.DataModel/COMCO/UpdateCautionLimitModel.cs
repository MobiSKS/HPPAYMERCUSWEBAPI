using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.COMCO
{
    public class UpdateCautionLimitModelInput:BaseClass
    {

        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [JsonPropertyName("CautionLimit")]
        [DataMember]
        public decimal CautionLimit { get; set; }


    }
    public class UpdateCautionLimitModelOutput : BaseClassOutput
    {
    }
}
