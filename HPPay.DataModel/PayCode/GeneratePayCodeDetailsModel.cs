using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.PayCode
{
    public class PayCodeGeneratePayCodeDetailsModelInput : BaseClass
    {

        [Required]
        [JsonPropertyName("Customerid")]
        [DataMember]
        public string Customerid { get; set; }

        [Required]
        [JsonPropertyName("ProductId")]
        [DataMember]
        public int ProductId { get; set; }

        //[Required]
        //[JsonPropertyName("Validitiy")]
        //[DataMember]
        //public string Validitiy { get; set; }

        //[Required]
        //[JsonPropertyName("EffectiveDate")]
        //[DataMember]
        //public string EffectiveDate { get; set; }


        [Required]
        [JsonPropertyName("Cardno")]
        [DataMember]
        public string Cardno { get; set; }

        //[Required]
        [JsonPropertyName("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }

        //[Required]
        [JsonPropertyName("Mobileno")]
        [DataMember]
        public string Mobileno { get; set; }

        //[Required]
        //[JsonPropertyName("EffectiveDate")]
        //[DataMember]
        //public DateTime EffectiveDate { get; set; }


        [Required]
        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

        //[Required]
        [JsonPropertyName("Merchantid")]
        [DataMember]
        public string Merchantid { get; set; }

        [JsonPropertyName("ObjPayCodeForTypeDespetachDetails")]
        [DataMember]
        public List<PayCodeForTypeDespetachDetails> ObjPayCodeForTypeDespetachDetails { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }
    }

    public class PayCodeForTypeDespetachDetails
    {
        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonPropertyName("Email")]
        [DataMember]
        public string Email { get; set; }

    }

    public class PayCodeGeneratePayCodeDetailsModelOutput : BaseClassOutput
    {
        [JsonProperty("ExpiryDate")]
        [DataMember]
        public string ExpiryDate { get; set; }

    }

}
