using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.Merchant
{
    public class MerchantGetTerminalStatusModelInput:BaseClass
    {
        
        [JsonPropertyName("MobileDispenserId")]
        [DataMember]
        public string MobileDispenserId { get; set; }
    }

    public class MerchantGetTerminalStatusModelOutput
    {
      
        [JsonProperty("MobileDispenserId")]
        [DataMember]
        public string MobileDispenserId { get; set; }


        [JsonProperty("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }


    }
}
