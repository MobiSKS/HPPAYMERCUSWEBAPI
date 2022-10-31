using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Card
{
    public class UpdateCardLimitsModelInput : BaseClass
    {
        //[Required]
        //[JsonPropertyName("Cardno")]
        //[DataMember]
        //public string Cardno { get; set; }

        //[Required]
        //[JsonPropertyName("Cashpurse")]
        //[DataMember]
        //public decimal Cashpurse { get; set; }

        //[Required]
        //[JsonPropertyName("Saletxn")]
        //[DataMember]
        //public int Saletxn { get; set; }

        //[Required]
        //[JsonPropertyName("Dailysale")]
        //[DataMember]
        //public int Dailysale { get; set; }


        //[Required]
        //[JsonPropertyName("Monthlysale")]
        //[DataMember]
        //public int Monthlysale { get; set; }

        [JsonPropertyName("ObjCardLimits")]
        [DataMember]
        public List<CardLimitsModelInput> ObjCardLimits { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }
    }


    public class CardLimitsModelInput 
    {
        [Required]
        [JsonPropertyName("Cardno")]
        [DataMember]
        public string Cardno { get; set; }

        //[Required]
        //[JsonPropertyName("Cashpurse")]
        //[DataMember]
        //public decimal Cashpurse { get; set; }

        [Required]
        [JsonPropertyName("SaleTxnLimit")]
        [DataMember]
        public decimal SaleTxnLimit { get; set; }

        [Required]
        [JsonPropertyName("DailySaleLimit")]
        [DataMember]
        public decimal DailySaleLimit { get; set; }


        [Required]
        [JsonPropertyName("MonthlySaleLimit")]
        [DataMember]
        public decimal MonthlySaleLimit { get; set; }
        
    }

    public class UpdateCardLimitsModelOutput : BaseClassOutput
    {
        [Required]
        [JsonProperty("Cardno")]
        [DataMember]
        public string Cardno { get; set; }


        [JsonProperty("RecordNumber")]
        [DataMember]
        public string RecordNumber { get; set; }
    }
}
