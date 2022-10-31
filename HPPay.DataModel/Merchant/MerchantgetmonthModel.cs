using Newtonsoft.Json;
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
    public class MerchantgetmonthModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("StatmentId")]
        [DataMember]
        public int StatmentId { get; set; }
    }

    public class MerchantgetmonthModelOutput 
    {
        [JsonProperty("MonthId")]
        [DataMember]
        public string MonthId { get; set; }

        [JsonProperty("Month")]
        [DataMember]
        public string Month { get; set; }
    }
}
