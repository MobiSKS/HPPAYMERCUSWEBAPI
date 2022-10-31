using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Card
{
    public class UpdateHotlistReissueCardRequestModelInput : BaseClass
    {

        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [Required]
        [JsonPropertyName("TypeHotlistReissueCardRequest")]
        [DataMember]
        public List<TypeHotlistReissueCardRequest> TypeHotlistReissueCardRequest { get; set; }
    }

    public class TypeHotlistReissueCardRequest
    {
        [Required]
        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonPropertyName("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }

        
        [JsonPropertyName("ReasonId")]
        [DataMember]
        public int ReasonId { get; set; }
    }

    public class UpdateHotlistReissueCardRequestModelOutput : BaseClassOutput
    {
        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

    }

}
