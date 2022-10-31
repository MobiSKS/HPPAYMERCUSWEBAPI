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
    public class GetDealerCreditPaymentStatusModelInput : BaseClass
    {
        
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        
        [JsonPropertyName("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

        [Required]
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [Required]
        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }
    }

    public class GetDealerCreditPaymentStatusModelOutput : BaseClassOutput
    {
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }


        [JsonProperty("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

        [JsonProperty("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

        [JsonProperty("Outstanding")]
        [DataMember]
        public decimal Outstanding { get; set; }


        [JsonProperty("RequestedDate")]
        [DataMember]
        public string RequestedDate { get; set; }

        [JsonProperty("ProcessingDate")]
        [DataMember]
        public string ProcessingDate { get; set; }


        [JsonProperty("Remarks")]
        [DataMember]
        public string Remarks { get; set; }

        [JsonProperty("Status1")]
        [DataMember]
        public string Status1 { get; set; }

    }
}
