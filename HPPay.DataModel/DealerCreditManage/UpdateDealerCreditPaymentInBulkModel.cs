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
    public class UpdateDealerCreditPaymentInBulkModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }


        [Required]
        [JsonPropertyName("TypeUpdateDealerCreditPaymentInBulk")]
        [DataMember]

        public List<TypeUpdateDealerCreditPaymentInBulk> TypeUpdateDealerCreditPaymentInBulk { get; set; }
    }

    public class TypeUpdateDealerCreditPaymentInBulk
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
        [JsonPropertyName("Outstanding")]
        [DataMember]
        public decimal Outstanding { get; set; }

        [Required]
        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }
    }

    public class UpdateDealerCreditPaymentInBulkModelOutput : BaseClassOutput
    {
     
        [JsonProperty("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

    
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

       
        [JsonProperty("Outstanding")]
        [DataMember]
        public decimal Outstanding { get; set; }

       
        [JsonProperty("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

    }
}
