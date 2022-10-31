using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.AshokLeyland
{
    public class GetALCheckVinNumberModelInput : BaseClass
    {

        [Required]
        [JsonPropertyName("VinNumber")]
        [DataMember]
        public string VinNumber { get; set; }



    }

    public class GetALCheckVinNumberModelOutput : BaseClassOutput
    {

    }





}
    

        
    

