using System.Collections.Generic;
using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Card
{

    public class CardUpdateCardRenewalRequestModelInput : BaseClass
        {


        //[Required]
             [JsonPropertyName("TypeCardRenewalRequest")]
            [DataMember]
            public List<TypeCardRenewalRequest> TypeCardRenewalRequest { get; set; }

            [Required]
            [JsonPropertyName("CustomerId")]
            [DataMember]
            public string CustomerId { get; set; }

            [Required]
            [JsonPropertyName("ModifiedBy")]
            [DataMember]
            public string ModifiedBy { get; set; }

    }

        public class TypeCardRenewalRequest
        {
            [Required]
            [JsonPropertyName("CardNo")]
            [DataMember]
            public string CardNo { get; set; }

             [JsonPropertyName("VechileNo")]
            [DataMember]
            public string VechileNo { get; set; }
       
    }

        public class CardUpdateCardRenewalRequestModelOutput : BaseClassOutput
        {

        }


        
    }
