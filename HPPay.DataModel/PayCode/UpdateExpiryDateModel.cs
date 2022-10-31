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
    public class UpdateExpiryDateModelInput: BaseClass
    {
        
        [JsonPropertyName("ObjUpdatePaycodeExpiryDate")]
        [DataMember]
        public List<UpdatePaycodeExpiryDate> ObjUpdatePaycodeExpiryDate { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

    }

    public class UpdatePaycodeExpiryDate
    {

        [JsonPropertyName("PayCode")]
        [DataMember]
        public string PayCode { get; set; }


        [JsonPropertyName("ExpiryDate")]
        [DataMember]
        public string ExpiryDate { get; set; }

    }

    public class UpdateExpiryDateModelOutput : BaseClassOutput

    {


    }
}
