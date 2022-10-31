using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.PayCode
{
    public class PayCodeGeneratePayCodeDetailsForEGVModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("Customerid")]
        [DataMember]
        public string Customerid { get; set; }

        [Required]
        [JsonPropertyName("NoOfPaycode")]
        [DataMember]
        public int NoOfPaycode { get; set; }

        [Required]
        [JsonPropertyName("Validitiy")]
        [DataMember]
        public int Validitiy { get; set; }

        //[Required]
        //[JsonPropertyName("EffectiveDate")]
        //[DataMember]
        //public string EffectiveDate { get; set; }
        [Required]
        [JsonPropertyName("EffectiveDate")]
        [DataMember]
        public DateTime EffectiveDate { get; set; }


        [Required]
        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

       // [Required]
        [JsonPropertyName("Merchantid")]
        [DataMember]
        public string Merchantid { get; set; }

        [JsonPropertyName("ObjPayCodeForEGVTypeDespetachDetails")]
        [DataMember]
        public List<PayCodeForTypeDespetachDetailsForEGV> ObjPayCodeForEGVTypeDespetachDetails { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

    }

    public class PayCodeForTypeDespetachDetailsForEGV
    {
        
        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

       
        [JsonPropertyName("Email")]
        [DataMember]
        public string Email { get; set; }

    }

    public class PayCodeGeneratePayCodeDetailsForEGVModelOutput :BaseClassOutput
    {

        [JsonProperty("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

        [JsonProperty("PayCode")]
        [DataMember]
        public string PayCode { get; set; }

        [JsonProperty("CreatedTime")]
        [DataMember]
        public string CreatedTime { get; set; }


        [JsonProperty("ExpiryDate")]
        [DataMember]
        public string ExpiryDate { get; set; }

        [JsonProperty("EffectiveStartDate")]
        [DataMember]
        public string EffectiveStartDate { get; set; }


        [JsonProperty("Email")]
        [DataMember]
        public string Email { get; set; }

        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }


    }

}
