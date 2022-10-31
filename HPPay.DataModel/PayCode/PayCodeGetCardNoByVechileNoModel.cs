using Newtonsoft.Json;
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
    public class PayCodeGetCardNoByVechileNoModelInput:BaseClass
    {

        [Required]
        [JsonPropertyName("Customerid")]
        [DataMember]
        public string Customerid { get; set; }

        [Required]
        [JsonPropertyName("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }
    }


    public class PayCodeGetCardNoByVechileNoModelOutput : BaseClassOutput
    {
        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

    }

}
