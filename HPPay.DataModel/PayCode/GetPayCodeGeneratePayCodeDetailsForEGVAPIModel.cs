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
    public class GetPayCodeGeneratePayCodeDetailsForEGVAPIModelInput

    {
        [Required]
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }

        [Required]
        [JsonPropertyName("PassWord")]
        [DataMember]
        public string PassWord { get; set; }


    }


    //public class GetPayCodeGeneratePayCodeDetailsForEGVAPIModelOutput:BaseClassOutput
    //{ 
    
    
    //}

}
