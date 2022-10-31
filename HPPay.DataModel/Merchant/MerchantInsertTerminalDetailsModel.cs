using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
namespace HPPay.DataModel.Merchant
{
    public class MerchantInsertTerminalDetailsModelInput:BaseClass
    {

        [Required]
        [JsonPropertyName("TerminalId  ")]
        [DataMember]
        public string TerminalId { get; set; }

        [Required]
        [JsonPropertyName("MobileDispenserId")]
        [DataMember]
        public string MobileDispenserId { get; set; }

        [Required]
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        //[Required]
        //[JsonPropertyName("TermainalIssuanceType")]
        //[DataMember]
        //public string TermainalIssuanceType { get; set; }

        [Required]
        [JsonPropertyName("ServiceCharge")]
        [DataMember]
        public decimal ServiceCharge { get; set; }

        [Required]
        [JsonPropertyName("RouteId")]
        [DataMember]
        public string RouteId { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        //[Required]
        //[JsonPropertyName("Remarks")]
        //[DataMember]
        //public string Remarks { get; set; }
    }

    public class MerchantInsertTerminalDetailsModelOutput:BaseClassOutput
    {

    }
}
