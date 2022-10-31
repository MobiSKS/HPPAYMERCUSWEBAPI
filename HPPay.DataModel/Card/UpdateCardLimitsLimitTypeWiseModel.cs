using Newtonsoft.Json;
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
   

    public class UpdateCardLimitsLimitTypeWiseModelInput : BaseClass
    {
       

        [JsonPropertyName("ObjCardLimits")]
        [DataMember]
        public List<CardLimitModelInput> ObjCardLimits { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }
    }


    public class CardLimitModelInput
    {
        [Required]
        [JsonPropertyName("Cardno")]
        [DataMember]
        public string Cardno { get; set; }

        [Required]
        [JsonPropertyName("LimitType")]
        [DataMember]
        public int LimitType { get; set; }

        [Required]
        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

        //[Required]
        //[JsonPropertyName("DailySaleLimit")]
        //[DataMember]
        //public decimal DailySaleLimit { get; set; }


        //[Required]
        //[JsonPropertyName("MonthlySaleLimit")]
        //[DataMember]
        //public decimal MonthlySaleLimit { get; set; }

    }

    public class UpdateCardLimitsLimitTypeWiseModelOutput : BaseClassOutput
    {
        [Required]
        [JsonProperty("Cardno")]
        [DataMember]
        public string Cardno { get; set; }
    }
}
