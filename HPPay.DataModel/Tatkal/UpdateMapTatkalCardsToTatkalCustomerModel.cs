using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Tatkal
{
    public class UpdateMapTatkalCardsToTatkalCustomerModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("Customerid")]
        [DataMember]
        public string Customerid { get; set; }

        [JsonPropertyName("RegionalOfcId")]
        [DataMember]
        public string RegionalOfcId { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [JsonPropertyName("ObjCardMap")]
        [DataMember]
        public List<CardMapModelInput> ObjCardMap { get; set; }
    }

    public class CardMapModelInput
    {
        [Required]
        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }
    }

    public class UpdateMapTatkalCardsToTatkalCustomerModelOutput : BaseClassOutput
    {

        [JsonProperty("ActionName")]
        [DataMember]
        public string ActionName { get; set; }

        [JsonProperty("Customerid")]
        [DataMember]
        public string Customerid { get; set; }

        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }
    }
}
