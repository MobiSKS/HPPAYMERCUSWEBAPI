using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Card
{
    public class UpdateCCMSLimitsModelInput : BaseClass
    {

        //[Required]
        //[JsonPropertyName("Cardno")]
        //[DataMember]
        //public string Cardno { get; set; }

        //[Required]
        //[JsonPropertyName("Limittype")]
        //[DataMember]
        //public int Limittype { get; set; }

        //[Required]
        //[JsonPropertyName("Amount")]
        //[DataMember]
        //public decimal Amount { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("ObjCCMSLimits")]
        [DataMember]
        public List<CCMSLimitsModelInput> ObjCCMSLimits { get; set; }
    }

    public class CCMSLimitsModelInput 
    {

        [Required]
        [JsonPropertyName("Cardno")]
        [DataMember]
        public string Cardno { get; set; }

        //[Required]
        [JsonPropertyName("Limittype")]
        [DataMember]
        public int Limittype { get; set; }

        //[Required]
        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

        //[Required]
        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

    }

    public class UpdateCCMSLimitsModelOutput : BaseClassOutput
    {
        [JsonProperty("RecordNumber")]
        [DataMember]
        public int RecordNumber { get; set; }
        
    }

    public class UpdateCCMSLimitsCardWiseModelInput : BaseClass
    {



        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [JsonPropertyName("ObjCCMSLimitsCardWise")]
        [DataMember]
        public List<CCMSLimitsCardWiseModelInput> ObjCCMSLimitsCardWise { get; set; }
    }

    public class CCMSLimitsCardWiseModelInput
    {

        [Required]
        [JsonPropertyName("Cardno")]
        [DataMember]
        public string Cardno { get; set; }

        //[Required]
        [JsonPropertyName("Limittype")]
        [DataMember]
        public int Limittype { get; set; }

        //[Required]
        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }


    }

    public class UpdateCCMSLimitsCardWiseModelOutput : BaseClassOutput
    {

    }

}
