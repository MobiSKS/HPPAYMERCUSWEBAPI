using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Merchant
{
    public class CheckMerchantIdStatusModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }
    }
    public class CheckMerchantIdStatusModelOutput : BaseClassOutput
    {
    }
}
