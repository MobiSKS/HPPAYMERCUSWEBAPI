using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Card
{

    public class CardSearchMappingDetailModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("Customerid")]
        [DataMember]
        public string Customerid { get; set; }


        //[Required]
        [JsonPropertyName("Cardno")]
        [DataMember]
        public string Cardno { get; set; }

        //[Required]
        [JsonPropertyName("Mobileno")]
        [DataMember]
        public string Mobileno { get; set; }

        //[Required]
        [JsonPropertyName("Vehiclenumber")]
        [DataMember]
        public string Vehiclenumber { get; set; }

        [JsonPropertyName("Type")]
        [DataMember]
        public int Type { get; set; }

    }

    public class CardSearchMappingDetailModelOutput: BaseClassOutput
    {
        

        [JsonProperty("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }

        [JsonProperty("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }


        [JsonProperty("MobileNumber")]
        [DataMember]
        public string MobileNumber { get; set; }

        [JsonProperty("CardIdentifier")]
        [DataMember]
        public string CardIdentifier { get; set; }

        [JsonProperty("FastagNo")]
        [DataMember]
        public string FastagNo { get; set; }


        [JsonProperty("MappingDate")]
        [DataMember]
        public string MappingDate { get; set; }


    }
}
