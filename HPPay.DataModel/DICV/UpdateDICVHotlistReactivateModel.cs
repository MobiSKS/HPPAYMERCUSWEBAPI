using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.DICV
{
    public class UpdateDICVHotlistReactivateModelInput : BaseClass
    {
        
        [JsonPropertyName("EntitytypeId")]
        [DataMember]
        public string EntitytypeId { get; set; }

        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("CardNo")]
        [DataMember]

        public string CardNo { get; set; }

        [JsonPropertyName("ReasonId")]
        [DataMember]

        public string ReasonId { get; set; }

        [JsonPropertyName("Remarks")]
        [DataMember]

        public string Remarks { get; set; }

        [JsonPropertyName("RemarksOthers")]
        [DataMember]

        public string RemarksOthers { get; set; }
        [JsonPropertyName("ActionId")]
        [DataMember]

        public int ActionId { get; set; }
       
        [JsonPropertyName("ModifiedBy")]
        [DataMember]

        public string ModifiedBy { get; set; }


    }
    public class UpdateDICVHotlistReactivateModelOutput : BaseClassOutput
    {

    }
}