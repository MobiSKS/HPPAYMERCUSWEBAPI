using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Card
{
    public class EmergencyReplacementCardModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [Required]
        [JsonPropertyName("RegionalOfficeId")]
        [DataMember]
        public string RegionalOfficeId { get; set; }

    }

    public class EmergencyReplacementCardModelOutput :BaseClassOutput
    {      
        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

    }

    // for update 
    public class UpdateEmergencyReplacementCardsModelInput : BaseClass
    {       
        [JsonPropertyName("objEmergencyReplacementCards")]
        [DataMember]
        public List<EmergencyReplacementCardsModelInput> objEmergencyReplacementCards { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        
    }


    public class EmergencyReplacementCardsModelInput  
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [Required]
        [JsonPropertyName("OldCardNo")]
        [DataMember]
        public string OldCardNo { get; set; }

        [Required]
        [JsonPropertyName("NewCardNo")]
        [DataMember]
        public string NewCardNo { get; set; }

        
        

    }

    public class EmergencyReplacementCardsModelOutput : BaseClassOutput
    {

    }



}
