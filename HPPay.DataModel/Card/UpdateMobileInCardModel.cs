using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Card
{
    public class UpdateMobileInCardModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("Cardno")]
        [DataMember]
        public string Cardno { get; set; }

        [Required]
        [JsonPropertyName("Mobileno")]
        [DataMember]
        public string Mobileno { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }
    }

    public class UpdateMobileInCardModelOutput : BaseClassOutput
    {

    }

    public class UpdateMobileandFastagNoInCardModelInput : BaseClass
    {
        [JsonPropertyName("ObjUpdateMobileandFastagNoInCard")]
        [DataMember]
        public List<UpdateMobileandFastagNoInCard> ObjUpdateMobileandFastagNoInCard { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }
    }

    public class UpdateMobileandFastagNoInCard
    {
        [Required]
        [JsonPropertyName("Cardno")]
        [DataMember]
        public string Cardno { get; set; }


        [JsonPropertyName("Mobileno")]
        [DataMember]
        public string Mobileno { get; set; }


        [JsonPropertyName("FastagNo")]
        [DataMember]
        public string FastagNo { get; set; }


    }



    public class UpdateMobileandFastagNoInCardModelOutput : BaseClassOutput
    {

        [JsonProperty("APIRefNo")]
        [DataMember]
        public string APIRefNo { get; set; }
    }
}
