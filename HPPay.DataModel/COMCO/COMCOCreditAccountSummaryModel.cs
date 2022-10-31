using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.COMCO
{
    public class COMCOCreditAccountSummaryModelInput:BaseClass
    {



    }

    public class COMCOCreditAccountSummaryModelOutput 
    {
        [Required]
        [JsonProperty("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

        [Required]
        [JsonProperty("ZO")]
        [DataMember]
        public string ZO { get; set; }

        [Required]
        [JsonProperty("RO")]
        [DataMember]
        public string RO { get; set; }

        [Required]
        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }

        [Required]
        [JsonProperty("CreditLimit")]
        [DataMember]
        public decimal CreditLimit { get; set; }

        [Required]
        [JsonProperty("CautionLimit")]
        [DataMember]
        public double CautionLimit { get; set; }


    }
}
