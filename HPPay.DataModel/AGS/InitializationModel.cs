using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.AGS
{
    public class InitializationModelInput//:BaseClass
    {
        [Required(AllowEmptyStrings = false)]
        [JsonPropertyName("MobileNumber")]
        [DataMember]
        public string MobileNumber { get; set; }

        [Required]
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        //[Required]
        //[JsonPropertyName("CreatedBy")]
        //[DataMember]
        //public string CreatedBy { get; set; }


        [Required]
        [JsonPropertyName("APIKey")]
        [DataMember]
        public string APIKey { get; set; }

        //[Required]
        //[JsonPropertyName("APIReferenceNo")]
        //[DataMember]
        //public string APIReferenceNo { get; set; }


    }

    public class InitializationModelOutput : AGSBaseClassOutput
    {

    }
}
