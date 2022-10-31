using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.DealerCreditManage
{
    public class UpdateDealerCreditMappingModelInput:BaseClass
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
        [JsonPropertyName("TypeUpdateDealerCreditMapping")]
        [DataMember]
        
        public List<TypeUpdateDealerCreditMapping> TypeUpdateDealerCreditMapping { get; set; }


    }

    public class TypeUpdateDealerCreditMapping
    {
        [Required]
        [JsonPropertyName("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

        [Required]
        [JsonPropertyName("CreditCloseLimitType")]
        [DataMember]
        public string CreditCloseLimitType { get; set; }

        [Required]
        [JsonPropertyName("LimitAmount")]
        [DataMember]
        public decimal LimitAmount { get; set; }
    }
    public class UpdateDealerCreditMappingModelOutput : BaseClassOutput
    {
        [Required]
        [JsonProperty("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }
    }
 }
