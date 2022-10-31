using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    public class MerchantCheckAvailityCardInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        //[JsonPropertyName("RegionalId")]
        //[DataMember]
        //public Int32 RegionalId { get; set; }
    }

    public class MerchantCheckAvailityCardOutput  
    {
        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }
    }


    public class MerchantGetAvailityCardInput : BaseClass
    {
        [Required]
        [JsonPropertyName("RegionalOfficeId")]
        [DataMember]
        public Int32 RegionalOfficeId { get; set; }

        //[Required]
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }
    }

    public class MerchantGetAvailityCardOutput : BaseClassOutput
    {
        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }
    }


   

}
