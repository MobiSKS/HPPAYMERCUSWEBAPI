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
    public class GetCreditClosePaymentModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [JsonPropertyName("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

    }
    public class GetCreditClosePaymentModelOutput 
    {
       
        [JsonProperty("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }

        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonProperty("IndividualOrgName")]
        [DataMember]
        public string IndividualOrgName { get; set; }

        [JsonProperty("Outstanding")]
        [DataMember]
        public double Outstanding { get; set; }

        [JsonProperty("Limit")]
        [DataMember]
        public double Limit { get; set; }

        [JsonProperty("LimitBalance")]
        [DataMember]
        public double LimitBalance { get; set; }

        [JsonProperty("Amount")]
        [DataMember]
        public double Amount { get; set; }
    }
}
