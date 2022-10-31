using Newtonsoft.Json;
using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
namespace HPPay.DataModel.DealerCreditManage
{
    public class DCMInsertMapDealerForCreditSaleModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }


        [Required]
        [JsonPropertyName("TypeMapDealerForCreditSale")]
        [DataMember]
        public List<TypeMapDealerForCreditSale> TypeMapDealerForCreditSale { get; set; }
    }

    public class TypeMapDealerForCreditSale 
    {
        [Required]
        [JsonPropertyName("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

        [Required]
        [JsonPropertyName("CreditPeriod")]
        [DataMember]
        public string CreditPeriod { get; set; }

        [Required]
        [JsonPropertyName("EffectiveDate")]
        [DataMember]
        public string EffectiveDate { get; set; }
    }

    public class DCMInsertMapDealerForCreditSaleModelOutput : BaseClassOutput
    {
        [Required]
        [JsonProperty("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

    }
}
