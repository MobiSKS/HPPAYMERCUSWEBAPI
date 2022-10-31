using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.DealerCreditManage
{

    public class GenerateOTPCreditClosePaymentModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }


        [Required]
        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [Required]
        [JsonPropertyName("SourceofPayment")]
        [DataMember]
        public string SourceofPayment { get; set; }
       

    }
    public class GenerateOTPCreditClosePaymentModelOutput : BaseClassOutput
    {

        [JsonProperty("OTP")]
        [DataMember]
        public string OTP { get; set; }

        [JsonProperty("CTID")]
        [DataMember]
        public string CTID { get; set; }

        [JsonProperty("Mobileno")]
        [DataMember]
        public string Mobileno { get; set; }

        [JsonProperty("OutletName")]
        [DataMember]
        public string OutletName { get; set; }



    }
}
