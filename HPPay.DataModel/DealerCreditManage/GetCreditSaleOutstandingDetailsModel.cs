using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.DealerCreditManage
{
    public class GetCreditSaleOutstandingDetailsModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }
    }

    public class GetCreditSaleOutstandingDetailsModelOutput
    {
        [JsonProperty("MerchantDetails")]

        public List<GetMerchantDetails> MerchantDetails { get; set; }

        [JsonProperty("MerchantCustomerMappedDetails")]

        public List<GetMerchantCustomerMappedDetails> MerchantCustomerMappedDetails { get; set; }

    }

    public class GetMerchantDetails :BaseClassOutput
    {
        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }


        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }

        


    }

    public class GetMerchantCustomerMappedDetails
    {
        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonProperty("IndividualOrgName")]
        [DataMember]
        public string IndividualOrgName { get; set; }

        [JsonProperty("Outstanding")]
        [DataMember]
        public string Outstanding { get; set; }

      
        [JsonProperty("CreditCloseLimit")]
        [DataMember]
        public string CreditCloseLimit { get; set; }

        [JsonProperty("LimitBalance")]
        [DataMember]
        public string LimitBalance { get; set; }

        [JsonProperty("CCMSBalanceStatus")]
        [DataMember]
        public string CCMSBalanceStatus { get; set; }

    }


}
