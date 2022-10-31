using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Hotlist
{
    public class HotlistUpdatePermanentlyHotlistCardsModel
    {

        public class HotlistUpdatePermanentlyHotlistCardsModelInput : BaseClass
        {


            [Required]
            [JsonPropertyName("ModifiedBy")]
            [DataMember]
            public string ModifiedBy { get; set; }

      
            //[JsonPropertyName("CustomerId")]
            //[DataMember]
            //public string CustomerId { get; set; }


            
            //[JsonPropertyName("CardNo")]
            //[DataMember]
            //public string CardNo { get; set; }


            [JsonPropertyName("TypePermanentlyHotlistCards")]
            [DataMember]
            public List<TypePermanentlyHotlistCards> TypePermanentlyHotlistCards { get; set; }
        }

        public class TypePermanentlyHotlistCards
        {

           
            //[JsonPropertyName("CustomerId")]
            //[DataMember]
            //public string? CustomerId { get; set; }

            [Required]
            [JsonPropertyName("CardNo")]
            [DataMember]
            public string CardNo { get; set; }


            [Required]
            [JsonPropertyName("StatusId")]
            [DataMember]
            public int StatusId { get; set; }
        }

        public class HotlistUpdatePermanentlyHotlistCardsModelOutput : BaseClassOutput
        {
            [JsonProperty("CardNo")]
            [DataMember]
            public string CardNo { get; set; }
        }

    }
}
