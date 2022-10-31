using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.DealerCreditManage
{
    public class GetDealerCreditMappingDetailsModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }

    public class GetDealerCreditMappingDetailsModelOutput 
    {
        [JsonProperty("CustomerCCMSBalanceDetails")]

        public List<GetCustomerCCMSBalanceDetails> CustomerCCMSBalanceDetails { get; set; }


        [JsonProperty("CustomerDetails")]

        public List<GetCustomerDetails> CustomerDetails { get; set; }

        [JsonProperty("CustomerMerchantMappedDetails")]

        public List<GetCustomerMerchantMappedDetails> CustomerMerchantMappedDetails { get; set; }
    }

    public class GetCustomerCCMSBalanceDetails :BaseClassOutput
    {
        [JsonProperty("CCMSBalance")]
        [DataMember]
        public decimal CCMSBalance { get; set; }


    }


    public class GetCustomerDetails 
    {
        [JsonProperty("IndividualOrgName")]
        [DataMember]
        public string IndividualOrgName { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }

        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }

        [JsonProperty("CustomerAddress")]
        [DataMember]
        public string CustomerAddress { get; set; }


    }

    public class GetCustomerMerchantMappedDetails 
    {
        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonProperty("OutletNameAndLocation")]
        [DataMember]
        public string OutletNameAndLocation { get; set; }

        [JsonProperty("Outstanding")]
        [DataMember]
        public string Outstanding { get; set; }

        [JsonProperty("CreditCloseLimitType")]
        [DataMember]
        public string CreditCloseLimitType { get; set; }

        [JsonProperty("CreditCloseLimit")]
        [DataMember]
        public string CreditCloseLimit { get; set; }

        [JsonProperty("CreditCloseLimitBalance")]
        [DataMember]
        public string CreditCloseLimitBalance { get; set; }

        [JsonProperty("Action")]
        [DataMember]
        public string Action { get; set; }

    }




}


