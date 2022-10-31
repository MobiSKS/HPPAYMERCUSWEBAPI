using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.STFCAPI
{
    public class STFCUpdateCardLimitinBulkModelInput:STFCAPIBaseClassInput
    {
        [Required]
        [JsonPropertyName("lstCardLimitDetails")]
        [DataMember]
        public List<TypeCardLimitDetails> lstCardLimitDetails { get; set; }
    }

    public class TypeCardLimitDetails
    {
        [Required]
        [RegularExpression(@"\d{16}", ErrorMessage = "Invalid CardNumber/CardNumber should be length of 16 digits.")]
        [JsonPropertyName("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }

        [Required]
        [Range(1.00, 1000000.00, ErrorMessage = "Credit Daily sale Limit should be between 1 to 10 Lac.")]
        [JsonPropertyName("CreditDailySaleLimit")]
        [DataMember]
        public decimal CreditDailySaleLimit { get; set; }
    }

    public class STFCUpdateCardLimitinBulkModelOutput 
    {
        [JsonProperty("lstCardLimitDetails")]
        [DataMember]
        public List<CardLimitDetails> lstCardLimitDetails { get; set; }

        [JsonProperty("responseCode")]
        [DataMember]
        public string responseCode { get; set; }

        [JsonProperty("responseMessage")]
        [DataMember]
        public string responseMessage { get; set; }
    }

    public class CardLimitDetailsresponse
    {
        [JsonProperty("responseCode")]
        [DataMember]
        public string responseCode { get; set; }

        [JsonProperty("responseMessage")]
        [DataMember]
        public string responseMessage { get; set; }
    }
    public class CardLimitDetails
    {

        [JsonProperty("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }


        [Required]
        [JsonProperty("CreditDailySaleLimit")]
        [DataMember]
        public decimal CreditDailySaleLimit { get; set; }
    }
}
